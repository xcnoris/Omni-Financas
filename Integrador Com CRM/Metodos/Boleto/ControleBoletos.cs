using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    public class ControleBoletos
    {
        public string Message;
        public bool Status;

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

                    // Verifica se a BOLETO já esta na tabela de relação, caso ele esteja, significa que já existe um cady/oportunidade criada no CRM
                    RelacaoBoletoCRMModel BoletoRelacao = TableRelacaoBoleto.FirstOrDefault(x => x.Id_DocumentoReceber == Convert.ToInt32(id_DocReceber));

                    // Log para verificação
                    MetodosGerais.RegistrarLog("BOLETO", $"Verificando Documento a receber {id_DocReceber}...");

                    if (BoletoRelacao is null)
                    {
                        if (situacao != 3)
                        {
                            // Log para verificação
                            MetodosGerais.RegistrarLog("BOLETO", $"Documento a receber {id_DocReceber} não encontrada na tabela de relação.");
                            ModeloOportunidadeRequest oportunidade = new ModeloOportunidadeRequest();

                            //Instancia dados das class
                            if (oportunidade != null )
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
                            OportunidadeResponse response = await EnviarBoletoParaCRM.CriarOportunidade(oportunidade, DadosAPI.Token, dalBoleto, BoletoRelacao);
                            if (response is null)
                            {
                                MetodosGerais.RegistrarLog("ERRO", "Falha ao criar Oportunidade");
                            }
                            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
                            if (situacao == 2)
                            {
                                //string cod_oportunidade = response.CodigoOportunidade.ToString(/*);*/
                                //BoletoAcoesCRMModel boletoBuscado = FrmBoletoAcao.BuscarBoletoAcoes(-1);
                                //AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                                //{
                                //    codigoOportunidade = cod_oportunidade,
                                //    codigoAcao = boletoBuscado.Codigo_Acao,
                                //    codigoJornada = codigoJornada,
                                //    textoFollowup = boletoBuscado.Mensagem_Atualizacao
                                //};

                                BoletoRelacao.Quitado = 1;

                                // Atualize para a etapa pago no CRM, e atualiza no banco
                                // Passa 1 no primeiro parametro para informar que esta quitado
                                metodosGeraisBoleto.AtualizarAcaoNoCRM(-1,  codigoJornada, DadosAPI, dalBoleto, BoletoRelacao, true, false);
                            }

                            //MetodosGerais.RegistrarLog("BOLETO", $"Oportunidade criada para o doc a receber {id_DocReceber}: {response.} ");
                            Status = true;
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

                        if (diasAtraso > 0)
                        {

                            if (!string.IsNullOrEmpty(BoletoRelacao.Cod_Oportunidade))
                            {
                                // Verifica se a situação é 3, caso seja o boleto foi cancelado/estornado

                                if (situacao == 3)
                                {
                                    if (DiasEmAtrasoBoleto != 3)
                                    {
                                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está cancelado/Estornado!");
                                        metodosGeraisBoleto.AtualizarAcaoNoCRM(-2, codigoJornada, DadosAPI, dalBoleto, BoletoRelacao, false, true);
                                    }
                                }
                                else
                                {
                                    /*
                                        Verifica se a situação é 2, caso seja significa que o boleto esta pago/quitado
                                    */

                                    if (situacao == 2)
                                    {
                                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está á quitado!");
                                        //Verifica se quitado é igual a 0, caso seja significa se ainda nao foi alterado a ação no CRM e nem atualizado na table relacao
                                        // Caso seja 1, significa que esse boleto já esta atualizado no CRM e no DB
                                        if (BoletoRelacao.Quitado == 0)
                                        {
                                            metodosGeraisBoleto.AtualizarAcaoNoCRM(-1, codigoJornada, DadosAPI, dalBoleto, BoletoRelacao, true, true);
                                        }
                                    }
                                    else
                                    {
                                        // Area de cobrança. Verifica a quantidadede dias em atraso e faz a cobrança
                                        MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Está á {diasAtraso} dias em atraso.");
                                        metodosGeraisBoleto.VerificarAtrasoEBoleto(BoletoRelacao, diasAtraso, codigoJornada, DadosAPI, dalBoleto, DiasEmAtrasoBoleto);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto já existe na tabela relação. Não esta em atraso!");
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR NullReference]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
            catch (Exception ex)
            {
                
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("BOLETO");
            }
        }


    }
}
