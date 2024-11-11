using Aplication.IntegradorCRM.Servicos;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    public class ControleBoletos
    {
        private DAL<RelacaoBoletoCRMModel> dalBoleto;
        private readonly CrudBoleto _CrudBoleto;
        private readonly Boleto_Services metodosGeraisBoleto;
        private readonly DAL<BoletoAcoesCRMModel> _dalBoletoAcoes;
        private readonly DAL<DadosAPIModels> _dalDadosAPI;
        private readonly Situacao_Boleto SituacaoBoleto = new Situacao_Boleto();

        public ControleBoletos(DAL<BoletoAcoesCRMModel> dalBoletoAcoes)
        {
            dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            _CrudBoleto = new CrudBoleto();
            _dalBoletoAcoes = dalBoletoAcoes;
            //metodosGeraisBoleto = new MetodosGeraisBoleto(FrmBoletoAcao);
        }

        public async Task VerificarNovosBoletos(DadosAPIModels DadosAPI, List<AcaoSituacao_Boleto_CRM> AcoesSituacaoBoleto)
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("BOLETO");
                // Busca Novos boletos no DB
                List<RetornoBoleto> boletoList = _CrudBoleto.BuscarBoletosInDB();
                List<RelacaoBoletoCRMModel> TableRelacaoBoleto = (await dalBoleto.ListarAsync() ?? Enumerable.Empty<RelacaoBoletoCRMModel>()).ToList();

                string codigoJornada = DadosAPI.Cod_Jornada_Boleto;

                MetodosGerais.RegistrarLog("BOLETO", $"Foram encontrados {boletoList.Count} Boletos.\n");

                // Passa por cada Boleto que retornar no select
                foreach (var linha in boletoList)
                {
                    string id_DocReceber = linha.Id_DocReceber;
                    string dataFormatada = linha.Data_Vencimento.ToString("dd/MM/yyyy");
                    int situacao = Convert.ToInt32(linha.Situacao);

                    using (var dalBoletoUsing = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext()))
                    {
                        // Verifica se a BOLETO já esta na tabela de relação, caso ele esteja, significa que já existe um cady/oportunidade criada no CRM
                        RelacaoBoletoCRMModel BoletoRelacao = TableRelacaoBoleto.FirstOrDefault(x => x.Id_DocumentoReceber == Convert.ToInt32(id_DocReceber));

                        // Log para verificação
                        MetodosGerais.RegistrarLog("BOLETO", $"Verificando Documento a receber {id_DocReceber}...");

                        if (BoletoRelacao is null)
                        {
                            // Verifica se o boleto não esta cancelado ou estornado
                            if ((Situacao_Boleto)situacao != Situacao_Boleto.Cancelada_Ou_Estornado)
                            {
                                // Log para verificação
                                MetodosGerais.RegistrarLog("BOLETO", $"Documento a receber {id_DocReceber} não encontrada na tabela de relação.");

                                ModeloOportunidadeRequest oportunidade = new ModeloOportunidadeRequest();
                                oportunidade = oportunidade.CriarOportunidade(linha, DadosAPI);
                               
                                BoletoRelacao = new RelacaoBoletoCRMModel();
                                BoletoRelacao = BoletoRelacao.InstanciaDados(linha);

                                // tenta criar a oportunidade no CRM
                                OportunidadeResponse response = await EnviarBoletoParaCRM.CriarOportunidade(oportunidade, DadosAPI.Token, dalBoletoUsing, BoletoRelacao);
                                if (response is null)
                                {
                                    MetodosGerais.RegistrarLog("ERRO", "Falha ao criar Oportunidade");
                                    return;
                                }

                                // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
                                metodosGeraisBoleto.VerificarQuitacao(situacao, BoletoRelacao, AcoesSituacaoBoleto, codigoJornada, DadosAPI);
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("BOLETO", $"Documento Cancelado/Estornado. Não consta na Tabela relação nem CRM!");
                            }
                        }
                        else
                        {
                            int DiasEmAtrasoBoleto = BoletoRelacao.DiasEmAtraso;
                            int diasAtraso = (DateTime.Now - linha.Data_Vencimento).Days;
                            int situacaTBRelacao = BoletoRelacao.Situacao;

                            if (!string.IsNullOrEmpty(BoletoRelacao.Cod_Oportunidade))
                            {
                                // Verifica se o boleto está em atraso
                                if (diasAtraso > 0)
                                {

                                    // Verifica a situação do boleto (3 = cancelado/estornado, 2 = quitado)
                                    switch (situacao)
                                    {
                                        case 3:
                                            if (situacaTBRelacao != 3)
                                            {
                                                BoletoRelacao.Situacao = 3;
                                                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está cancelado/Estornado!");
                                                metodosGeraisBoleto.AtualizarAcaoNoCRM(-2, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, false, true);
                                            }
                                            else
                                            {
                                                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Já está ajustado como Cancelado/Estornado.");
                                            }
                                            break;

                                        case 2:
                                            if (BoletoRelacao.Quitado == 0)
                                            {
                                                metodosGeraisBoleto.AtualizarAcaoNoCRM(-1, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, true, true);
                                                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Foi atualizado para etapa Pago!!");
                                            }
                                            else
                                            {
                                                MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está quitado!");
                                            }
                                            break;

                                        default:
                                            // Caso não seja quitado nem cancelado, faz a cobrança
                                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está com {diasAtraso} dias em atraso.");
                                            metodosGeraisBoleto.VerificarAtrasoEBoleto(BoletoRelacao, diasAtraso, codigoJornada, DadosAPI, dalBoletoUsing, DiasEmAtrasoBoleto);
                                            break;
                                    }
                                }
                                // Caso o boleto não esteja em atraso
                                else 
                                {
                                    if (situacao == 2)
                                    {
                                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está quitado!");
                                        if (BoletoRelacao.Quitado == 0)
                                        {
                                            metodosGeraisBoleto.AtualizarAcaoNoCRM(-1, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, true, true);
                                        }
                                    }
                                    else if (situacao == 3)
                                    {
                                        if (situacaTBRelacao != 3)
                                        {
                                            BoletoRelacao.Situacao = 3;
                                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está cancelado/Estornado!");
                                            metodosGeraisBoleto.AtualizarAcaoNoCRM(-2, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, false, true);
                                        }
                                        else
                                        {
                                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Já está ajustado como Cancelado/Estornado.");
                                        }
                                    }
                                    else
                                    {
                                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Não está em atraso!");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR NullReference]: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                throw;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("BOLETO");
            }
        }


    }
}
