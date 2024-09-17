using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Metodos.Boleto;
using Microsoft.Data.SqlClient;

namespace Integrador_Com_CRM.Models.EF
{
    internal class CobrancasNaSegundaModel
    {
        internal DAL<RelacaoBoletoCRMModel> dalRelBoleto;
        internal DAL<CobrancasNaSegundaModel> dalCobrancas;
        private MetodosGeraisBoleto metodosBoleto;

        public int Id { get; set; }
        public string CodigoJornada { get; set; }
        public int BoletoId { get; set; }
        public RelacaoBoletoCRMModel? Boleto { get; set; }
        public int NovoAtrasoBoleto { get; set; }


        public CobrancasNaSegundaModel(string codigoJornada, RelacaoBoletoCRMModel boletoRelacao)
        {
            dalCobrancas = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());

            dalRelBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            metodosBoleto = new MetodosGeraisBoleto();

            CodigoJornada = codigoJornada; 
            BoletoId = boletoRelacao.Id;
            NovoAtrasoBoleto = boletoRelacao.DiasEmAtraso;
        }

        public CobrancasNaSegundaModel()
        {
            dalCobrancas = new DAL<CobrancasNaSegundaModel>(new IntegradorDBContext());
            dalRelBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            metodosBoleto = new MetodosGeraisBoleto();
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
                                        metodosBoleto.AtualizarAcaoNoCRM(conbranca.NovoAtrasoBoleto, conbranca.CodigoJornada, DadosAPI, dalRelBoletos, boletoRelacao, false, true);
                                        RemoverRegistro(boletoRelacao.Id);
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
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR]: {ex.Message}");
            }
        }

        internal async Task RemoverRegistro(int boletoID)
        {
            try
            {
                List<CobrancasNaSegundaModel> cobracaList = (await dalCobrancas.RecuperarTodosPorAsync(x => x.BoletoId == boletoID) ?? Enumerable.Empty<CobrancasNaSegundaModel>()).ToList();

                foreach (CobrancasNaSegundaModel cobranca in cobracaList)
                {
                    await dalCobrancas.DeletarAsync(cobranca);      
                }
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR] na consulta: {ex.Message}");
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"Ocorreu um [ERROR]: {ex.Message}");
            }
        }
    }
}
