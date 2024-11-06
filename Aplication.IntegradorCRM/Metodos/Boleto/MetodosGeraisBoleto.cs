using Aplication.IntegradorCRM.Servicos;
using DataBase.IntegradorCRM.Data;
using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;
using Metodos.IntegradorCRM.Metodos;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class MetodosGeraisBoleto
    {
        public string Message;
        public bool Status;
        private readonly Frm_BoletoAcoesCRM_UC FrmboletoAcao;
        private readonly CobrancaServicos CobrancasNaSegunda;
        public MetodosGeraisBoleto(Frm_BoletoAcoesCRM_UC boleto)
        {
            FrmboletoAcao = boleto;
            CobrancasNaSegunda = new CobrancasNaSegundaModel();
        }

        public async Task AtualizarAcaoNoCRM(int diasAtraso,  string codigoJornada, DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, RelacaoBoletoCRMModel BoletoRelacao, bool foiQuitado, bool naTableRelacao)
        {
            try
            {
                BoletoAcoesCRMModel BoletoAcaoBuscado = FrmboletoAcao.BuscarBoletoAcoes(diasAtraso);
                if (BoletoAcaoBuscado is not null)
                {

                    string codAcao = BoletoAcaoBuscado.Codigo_Acao;
                    string textoFollowup = BoletoAcaoBuscado.Mensagem_Atualizacao;

                    AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                    {
                        codigoOportunidade = BoletoRelacao.Cod_Oportunidade,
                        codigoAcao = codAcao,
                        codigoJornada = codigoJornada,
                        textoFollowup = textoFollowup
                    };

                    /*
                        Verifica se o boleto já esta na tabela relação,caso já esteja, significa que não precisa fazer
                        uma consuta no banco para descobrir o Id, visto que a instancia que veio no parametro já tem o Id

                    */
                    if (foiQuitado)
                    {
                        BoletoRelacao.Quitado = 1;
                    }
                    if (naTableRelacao == true)
                    {
                        BoletoRelacao.Situacao = 2;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoRelacao, foiQuitado);
                    }
                    else
                    {
                        RelacaoBoletoCRMModel BoletoInTableRElacao = dalBoleto.BuscarPor(x => x.Id_DocumentoReceber == BoletoRelacao.Id_DocumentoReceber);
                        BoletoInTableRElacao.Situacao = BoletoRelacao.Situacao;
                        BoletoInTableRElacao.DiasEmAtraso = BoletoRelacao.DiasEmAtraso;
                        await EnviarBoletoParaCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, dalBoleto, BoletoInTableRElacao, foiQuitado);
                    }



                    MetodosGerais.RegistrarLog("BOLETO", $"Boleto {BoletoRelacao.Id_DocumentoReceber} atualizado para a etapa '{textoFollowup}'. CodOp: {BoletoRelacao.Cod_Oportunidade}");
                }
                else
                {
                    MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!");
                    Message = $"[ERROR]: Ao consultar Dados da Ação para o boleto: {BoletoRelacao.Id_DocumentoReceber}!";
                    Status = false;
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}.Para o boleto: {BoletoRelacao.Id_DocumentoReceber}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
            }
        }
        internal async void VerificarAtrasoEBoleto(RelacaoBoletoCRMModel boleto, int diasAtraso, string codigoJornada,DadosAPIModels DadosAPI, DAL<RelacaoBoletoCRMModel> dalBoleto, int DiasAtrasoRelBoleto)
        {
            //Busca as configurações de dias de cobranças no DGV no Frm_GeralUC
            BoletoAcoesCRMModel boletoAcaoBuscado = FrmboletoAcao.BuscarBoletoAcoes(diasAtraso);

            if (boletoAcaoBuscado is not null)
            {
                // Verifica se o dia de atraso está na lista e não é igual ao registrado
                if (DiasAtrasoRelBoleto != diasAtraso)
                {
                    boleto.DiasEmAtraso = diasAtraso;

                    // Verifica se hoje é final de semana, caso seja, não faz a cobrança dos boleto.
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday || DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
                    {
                        // Cria um registro na tabela Cobrancas_Na_Segunda_CRM. Toda Segunda os registro que estao nessa tabela são
                        // Lidos e enviado a mensagem de cobraça. No final e removido o registro
                        // Sim.Faça isso
                        CobrancaServicos CobrancasSegunda = new CobrancaServicos(codigoJornada, boleto, FrmboletoAcao);
                        await CobrancasSegunda.SalvarDadosEmTableEspera();
                    }
                    else
                    {
                        // Verifica se o dia de hoje é segunda-feira
                        var eSegunda = DateTime.Now.DayOfWeek == DayOfWeek.Monday;

                        //Verifica se o dia em atraso [e 6 e se é segunda, caso seja significa que ele tentou cobrar do dia 5 no fim de semana
                        // Então deve ser cobrado primeiro os do 5 dias e depois do dia 6
                        if (diasAtraso == 6 && eSegunda)
                        {
                            await CobrancasNaSegunda.CobrarAtraso5Dias(codigoJornada, DadosAPI, dalBoleto, boleto);
                            AtualizarAcaoNoCRM(diasAtraso, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
                        }
                        else
                        {
                            AtualizarAcaoNoCRM(diasAtraso, codigoJornada, DadosAPI, dalBoleto, boleto, false, true);
                            
                        }
                    }
                }
            }
            else
            {
                // Se o dia de atraso não é um dos significativos, registrar no log
                MetodosGerais.RegistrarLog("BOLETO", $"Boleto não está em atraso significativo.");
            }
        }
    }
}
