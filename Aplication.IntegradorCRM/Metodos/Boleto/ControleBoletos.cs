using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.Boleto
{
    public class ControleBoletos
    {
        private readonly CrudBoleto _CrudBoleto;
        private readonly Situacao_Boleto SituacaoBoleto = new Situacao_Boleto();

        public ControleBoletos()
        {
            
            _CrudBoleto = new CrudBoleto();
            
            //metodosGeraisBoleto = new MetodosGeraisBoleto(FrmBoletoAcao);
        }

        public async Task VerificarNovosBoletos(DadosAPIModels DadosAPI, List<AcaoSituacao_Boleto_CRM> AcoesSituacaoBoleto, List<BoletoAcoesCRMModel> BoletoAcoesCRM, Configuracao_Geral FrmConfigUC)
        {
            DAL<BoletoAcoesCRMModel> _dalBoletoAcoes = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());
            DAL<DadosAPIModels> _dalDadosAPI = new DAL<DadosAPIModels>(new IntegradorDBContext());
            DAL<RelacaoBoletoCRMModel> dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());

            try
            {
                MetodosGerais.RegistrarInicioLog("BOLETO");
                // Busca Novos boletos no DB
                List<RetornoBoleto> boletoList = _CrudBoleto.BuscarBoletosInDB(FrmConfigUC.DataBoletoSelect);
                List<RelacaoBoletoCRMModel> TableRelacaoBoleto = (await dalBoleto.ListarAsync() ?? Enumerable.Empty<RelacaoBoletoCRMModel>()).ToList();

                MetodosGerais.RegistrarLog("BOLETO", $"Foram encontrados {boletoList.Count} Boletos.\n");

                // Passa por cada Boleto que retornar no select
                foreach (var linha in boletoList)
                {
                    string id_DocReceber = linha.Id_DocReceber;
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

                                await CriacaoService.RealizarProcessoCriacaoBoleto(DadosAPI,linha, FrmConfigUC.ChBox_BoletoEnviarPDFa);
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("BOLETO", $"Documento Cancelado/Estornado. Não consta na Tabela relação!");
                            }
                        }
                        else
                        {
                            int DiasEmAtrasoBoleto = BoletoRelacao.DiasEmAtraso;
                            int diasAtraso = (DateTime.Now.Date - linha.Data_Vencimento).Days;
                            int situacaTBRelacao = BoletoRelacao.Situacao;
                            BoletoRelacao.Celular_Entidade = linha.Celular;

                            MetodosGerais.RegistrarLog("BOLETO", $"DR  {BoletoRelacao.Id_DocumentoReceber} esta com a relação do vencimento em {diasAtraso}. Verificação foi iniciada...");
                            await Boleto_Services.VerificarBoletosCriados(BoletoRelacao, diasAtraso, situacao, situacaTBRelacao, DadosAPI, BoletoAcoesCRM, linha, FrmConfigUC);
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
