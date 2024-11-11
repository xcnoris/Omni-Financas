using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using Modelos.IntegradorCRM.Models.EF;

namespace Aplication.IntegradorCRM.Servicos
{
    internal class CobrancaServicos
    {

        internal DAL<RelacaoBoletoCRMModel> dalRelBoleto;
        internal DAL<CobrancasNaSegundaModel> dalCobrancas;
        private Boleto_Services metodosBoleto;
        private CobrancasNaSegundaModel cobrancasNaSegundaModel;
        

        //private readonly Frm_BoletoAcoesCRM_UC FrmBoletoAcao;


        public CobrancaServicos()
        {
            dalCobrancas = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());
            dalRelBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
        }

        public CobrancaServicos(string codigoJornada, RelacaoBoletoCRMModel boletoRelacao, BoletoAcoesCRMModel boelto) : this()
        {
            metodosBoleto = new Boleto_Services();
            cobrancasNaSegundaModel.CodigoJornada = codigoJornada;
            cobrancasNaSegundaModel.BoletoId = boletoRelacao.Id;
            cobrancasNaSegundaModel.NovoAtrasoBoleto = boletoRelacao.DiasEmAtraso;
            cobrancasNaSegundaModel.Cod_Oportunidade = boletoRelacao.Cod_Oportunidade;
        }

        //public CobrancaServicos( ) : this()
        //{
        //    //FrmBoletoAcao = FrmBoleto;
        //    //metodosBoleto = new Boleto_Services(FrmBoletoAcao);
        //}



        internal async Task SalvarDadosEmTableEspera()
        {
            try
            {
                await dalCobrancas.AdicionarAsync(cobrancasNaSegundaModel);
                //MetodosGerais.RegistrarLog("COBRANCA", $"Ação {cobrancasNaSegundaModel.NovoAtrasoBoleto} marcada para ser cobrado na segunda para o boletoBoleto {Boleto.Id_DocumentoReceber}. CodOp: {Cod_Oportunidade}");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("COBRANCA", $"[ERROR]: {ex.Message}");
                throw;
            }

        }

        //internal async Task RealizarCobrancas(Frm_DadosAPIUC DadosAPI)
        //{
        //    try
        //    {
        //        DAL<CobrancasNaSegundaModel> dalCobranca = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());
        //        DAL<RelacaoBoletoCRMModel> dalRelBoletos = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
        //        // Busca as cobranças que devem ser realiada
        //        List<CobrancasNaSegundaModel> ListCobrancas = (await dalCobranca.ListarAsync() ?? Enumerable.Empty<CobrancasNaSegundaModel>()).ToList();
        //        if (ListCobrancas is not null)
        //        {

        //            foreach (CobrancasNaSegundaModel conbranca in ListCobrancas)
        //            {
        //                if (conbranca != null)
        //                {
        //                    if (conbranca.NovoAtrasoBoleto != null && conbranca.CodigoJornada != null)
        //                    {
        //                        RelacaoBoletoCRMModel boletoRelacao = dalRelBoletos.BuscarPor(x => x.Id == conbranca.BoletoId);

        //                        if (metodosBoleto != null)
        //                        {
        //                            if (DadosAPI != null && boletoRelacao != null)
        //                            {
        //                                boletoRelacao.DiasEmAtraso = conbranca.NovoAtrasoBoleto;
        //                                metodosBoleto.AtualizarAcaoNoCRM(conbranca.NovoAtrasoBoleto, conbranca.CodigoJornada, DadosAPI, dalRelBoletos, boletoRelacao, false, true);
        //                                await RemoverRegistro(conbranca.Id, false);
        //                                MetodosGerais.RegistrarLog("COBRANCA", $"Boleto {boletoRelacao.Id_DocumentoReceber} removido da lista de cobrança. CodOp: {conbranca.Cod_Oportunidade}");
        //                            }
        //                            else
        //                            {
        //                                MetodosGerais.RegistrarLog("COBRANCA", "DadosAPI ou boletoRelacao estão nulos.");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            MetodosGerais.RegistrarLog("COBRANCA", "metodosBoleto está nulo.");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        MetodosGerais.RegistrarLog("COBRANCA", "NovoAtrasoBoleto ou CodigoJornada estão nulos.");
        //                    }
        //                }
        //                else
        //                {
        //                    MetodosGerais.RegistrarLog("COBRANCA", "Objeto conbranca está nulo.");
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MetodosGerais.RegistrarLog("COBRANCA", $"Nenhum Boleto para ser feita a cobrança!");

        //        }
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
        //        throw;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR]: {ex.Message}");
        //        throw;
        //    }
        //}

        //internal async Task<bool> CobrarAtraso5Dias(string codigoJornada, Frm_DadosAPIUC DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel boleto)
        //{
        //    try
        //    {
        //        int atraso5 = 5;
        //        metodosBoleto.AtualizarAcaoNoCRM(atraso5, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
        //        await dalCobrancas.DeletarPorCondicaoAsync(x => x.Cod_Oportunidade == boleto.Cod_Oportunidade && x.NovoAtrasoBoleto == atraso5);
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Atraso {atraso5} realizada para o boleto {boleto.Id_DocumentoReceber}. Boleto foi removido da lista de cobrança. CodOp: {boleto.Cod_Oportunidade}");
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
        //        return false;
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR]: {ex.Message}");
        //        return false;
        //        throw;
        //    }
        //}


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
                        MetodosGerais.RegistrarLog("COBRANCA", $"Oportunidade {cobranca.Cod_Oportunidade} removido da lista de cobrança. Boleto Id: {cobranca.BoletoId}");
                    }
                }

            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("COBRANCA", $"Ocorreu um [ERROR]: {ex.Message}");
                throw;
            }
        }
    }
}
