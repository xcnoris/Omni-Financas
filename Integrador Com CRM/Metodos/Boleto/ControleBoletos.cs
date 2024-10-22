using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    public class ControleBoletos
    {
        private DAL<RelacaoBoletoCRMModel> dalBoleto;
        private readonly CrudBoleto _CrudBoleto;
        private readonly MetodosGeraisBoleto metodosGeraisBoleto;
        private readonly Frm_BoletoAcoesCRM_UC FrmBoletoAcao;

        public ControleBoletos( Frm_BoletoAcoesCRM_UC BoletoAcoes)
        {
            dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            _CrudBoleto = new CrudBoleto();
            FrmBoletoAcao = BoletoAcoes;
            metodosGeraisBoleto = new MetodosGeraisBoleto(FrmBoletoAcao);
        }

        public async Task VerificarNovosBoletos(Frm_DadosAPIUC DadosAPI)
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("BOLETO");
                // Busca Novos boletos no DB
                List<RetornoBoleto> boletoList = _CrudBoleto.BuscarBoletosInDB();
                List<RelacaoBoletoCRMModel> TableRelacaoBoleto = (await dalBoleto.ListarAsync() ?? Enumerable.Empty<RelacaoBoletoCRMModel>()).ToList();

                string codigoJornada = "06AA9604D2";

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
                            if (situacao != 3)
                            {
                                // Log para verificação
                                MetodosGerais.RegistrarLog("BOLETO", $"Documento a receber {id_DocReceber} não encontrada na tabela de relação.");
                                ModeloOportunidadeRequest oportunidade = new ModeloOportunidadeRequest();

                                //Instancia dados das class
                                if (oportunidade != null)
                                {
                                    oportunidade = oportunidade.CriarOportunidade(linha);
                                }
                                else
                                {
                                    MetodosGerais.RegistrarLog("ERRO", "Falha ao instanciar ModeloOportunidadeRequest");
                                }
                                BoletoRelacao = new RelacaoBoletoCRMModel();
                                BoletoRelacao = BoletoRelacao.InstanciaDados(linha);

                                // tenta criar a oportunidade no CRM
                                OportunidadeResponse response = await EnviarBoletoParaCRM.CriarOportunidade(oportunidade, DadosAPI.Token, dalBoletoUsing, BoletoRelacao);
                                if (response is null)
                                {
                                    MetodosGerais.RegistrarLog("ERRO", "Falha ao criar Oportunidade");
                                }
                                // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
                                if (situacao == 2)
                                {
                                    BoletoRelacao.Quitado = 1;
                                    // Atualize para a etapa pago no CRM, e atualiza no banco
                                    // Passa -1 no primeiro parametro para informar que esta quitado
                                    metodosGeraisBoleto.AtualizarAcaoNoCRM(-1, codigoJornada, DadosAPI, dalBoletoUsing, BoletoRelacao, true, false);
                                }
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
