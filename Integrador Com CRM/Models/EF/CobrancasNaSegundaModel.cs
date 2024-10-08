using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Metodos.Boleto;
using Microsoft.Data.SqlClient;

namespace Integrador_Com_CRM.Models.EF
{
    public class CobrancasNaSegundaModel
    {
        internal DAL<RelacaoBoletoCRMModel> dalRelBoleto;
        internal DAL<CobrancasNaSegundaModel> dalCobrancas;
        private MetodosGeraisBoleto metodosBoleto;
        private readonly Frm_BoletoAcoesCRM_UC FrmBoletoAcao;

        public int Id { get; set; }
        public string CodigoJornada { get; set; }
        public int BoletoId { get; set; }
        public RelacaoBoletoCRMModel? Boleto { get; set; }
        public int NovoAtrasoBoleto { get; set; }
        public string Cod_Oportunidade { get; set; }

        public CobrancasNaSegundaModel()
        {
            dalCobrancas = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());
            dalRelBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
        }

        public CobrancasNaSegundaModel(string codigoJornada, RelacaoBoletoCRMModel boletoRelacao, Frm_BoletoAcoesCRM_UC FrmBoleto) : this()
        {
            FrmBoletoAcao = FrmBoleto;
            metodosBoleto = new MetodosGeraisBoleto(FrmBoletoAcao);
            CodigoJornada = codigoJornada; 
            BoletoId = boletoRelacao.Id;
            NovoAtrasoBoleto = boletoRelacao.DiasEmAtraso;
            Cod_Oportunidade = boletoRelacao.Cod_Oportunidade;
        }

        public CobrancasNaSegundaModel( Frm_BoletoAcoesCRM_UC FrmBoleto) : this()
        {
            FrmBoletoAcao = FrmBoleto;
            metodosBoleto = new MetodosGeraisBoleto(FrmBoletoAcao);
        }
       

        internal void SalvarDadosEmTableEspera()
        {
            dalCobrancas.AdicionarAsync(this);
        }

        internal async Task RealizarCobrancas(Frm_DadosAPIUC DadosAPI)
        {
            try
            {
                DAL<CobrancasNaSegundaModel> dalCobranca = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());
                DAL<RelacaoBoletoCRMModel> dalRelBoletos = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
                // Busca as cobranças que devem ser realiada
                List<CobrancasNaSegundaModel> ListCobrancas = (await dalCobranca.ListarAsync() ?? Enumerable.Empty<CobrancasNaSegundaModel>()).ToList();
                if (ListCobrancas is not null)
                {

                    foreach (CobrancasNaSegundaModel conbranca in ListCobrancas)
                    {
                        if (conbranca != null)
                        {
                            if (conbranca.NovoAtrasoBoleto != null && conbranca.CodigoJornada != null)
                            {
                                RelacaoBoletoCRMModel boletoRelacao = dalRelBoletos.BuscarPor(x => x.Id == conbranca.BoletoId);

                                if (metodosBoleto != null)
                                {
                                    if (DadosAPI != null && boletoRelacao != null)
                                    {
                                        boletoRelacao.DiasEmAtraso = conbranca.NovoAtrasoBoleto;
                                        metodosBoleto.AtualizarAcaoNoCRM(conbranca.NovoAtrasoBoleto, conbranca.CodigoJornada, DadosAPI, dalRelBoletos, boletoRelacao, false, true);
                                        await RemoverRegistro(conbranca.Id, false);
                                    }
                                    else
                                    {
                                        MetodosGerais.RegistrarLog("BOLETO", "DadosAPI ou boletoRelacao estão nulos.");
                                    }
                                }
                                else
                                {
                                    MetodosGerais.RegistrarLog("BOLETO", "metodosBoleto está nulo.");
                                }
                            }
                            else
                            {
                                MetodosGerais.RegistrarLog("BOLETO", "NovoAtrasoBoleto ou CodigoJornada estão nulos.");
                            }
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", "Objeto conbranca está nulo.");
                        }
                    }

                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"Nenhum Boleto para ser feita a cobrança!");

                }
            }
            catch (NullReferenceException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO",$"Ocorreu um [ERROR] na consulta: {ex.Message}");
                throw;
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR]: {ex.Message}");
                throw;
            }
        }

        internal async Task<bool> CobrarAtraso5Dias(string codigoJornada, Frm_DadosAPIUC DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel boleto)
        {
            try
            {
                metodosBoleto.AtualizarAcaoNoCRM(5, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
                await dalCobrancas.DeletarPorCondicaoAsync(x => x.Cod_Oportunidade == boleto.Cod_Oportunidade && x.NovoAtrasoBoleto == 5);
                return true;
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
                return false;
                throw;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR]: {ex.Message}");
                return false;
                throw;
            }
        }


        internal async Task RemoverRegistro(int cobrancaId, bool apagarTodos)
        {
            try
            {
                var cobrancaList = new List<CobrancasNaSegundaModel>();

                if (apagarTodos)
                {
                    cobrancaList = (await dalCobrancas.RecuperarTodosPorAsync(x => x.BoletoId == cobrancaId).ConfigureAwait(false)).ToList();
                }
                else
                {
                    cobrancaList = (await dalCobrancas.RecuperarTodosPorAsync(x => x.Id == cobrancaId).ConfigureAwait(false)).ToList();
                }

                if (cobrancaList.Any())
                {
                    foreach (var cobranca in cobrancaList)
                    {
                        await dalCobrancas.DeletarAsync(cobranca).ConfigureAwait(false);
                    }
                }

            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR]: {ex.Message}");
                throw;
            }
        }
    }
}
