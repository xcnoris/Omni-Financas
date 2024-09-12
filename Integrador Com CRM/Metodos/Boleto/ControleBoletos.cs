using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Data.Map;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models;
using Integrador_Com_CRM.Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Integrador_Com_CRM.Metodos.Boleto
{
    internal class ControleBoletos
    {
        public string Message;
        public bool Status;

        private DAL<RelacaoBoletoCRMModel> dalBoleto;
        private readonly CrudBoleto _CrudBoleto;
        private readonly MetodosGeraisBoleto metodosGeraisBoleto;

        public ControleBoletos( )
        {
            dalBoleto = new DAL<RelacaoBoletoCRMModel>(new IntegradorDBContext());
            _CrudBoleto = new CrudBoleto();
            metodosGeraisBoleto = new MetodosGeraisBoleto();
        }

        public async Task VerificarNovosBoletos(Frm_DadosAPIUC DadosAPI)
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("BOLETO");
                // Busca Novos boletos no DB
                List<RetornoBoleto> boletoList = _CrudBoleto.BuscarBoletosInDB();
                List<RelacaoBoletoCRMModel> TableRelacaoBoleto = (await dalBoleto.ListarAsync()).ToList();

                string codigoJornada = "06AA9604D2";

                // Passa por cada Boleto que retornar no select
                foreach (var linha in boletoList)
                {
                    string numeroDocRec = linha.Num_DocReceber;
                    string id_DocReceber = linha.Id_DocReceber;
                    string idEntidade = linha.Id_Entidade;
                    string nomeCliente = linha.Nome;
                    string celular = linha.Celular;
                    string emailCLiente = linha.Email;
                    string identificadorCliente = linha.Identificador_Cliente;
                    string situacao1 = linha.Situacao;
                    DateTime datavencimento = linha.Data_Vencimento;

                    int situacao = Convert.ToInt32(situacao1);

                    // Verifica se a BOLETO já esta na tabela de relação, caso ele esteja, significa que já existe um cady/oportunidade criada no CRM
                    RelacaoBoletoCRMModel BoletoRelacao = TableRelacaoBoleto.FirstOrDefault(x => x.Id_DocumentoReceber == Convert.ToInt32(id_DocReceber));

                    DateTime dataVencimentoTBRel = BoletoRelacao.Data_Vencimento;
                    //string cod_oportunidade = Tb.Rows[0]["cod_oportunidade"].ToString();

                    // Log para verificação
                    MetodosGerais.RegistrarLog("BOLETO", $"Verificando Documento a receber {id_DocReceber}...");

                    if (BoletoRelacao is null)
                    {
                        if (!(situacao == 3))
                        {

                            // Converte a string para DateTime
                            //DateTime data = DateTime.ParseExact(datavencimento, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            //DateTime data = DateTime.ParseExact(datavencimento, "dd/MM/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture);

                            // Formata o DateTime no formato "dd/MM/yyyy"
                            string dataFormatada = datavencimento.ToString("dd/MM/yyyy");

                            // Log para verificação
                            MetodosGerais.RegistrarLog("BOLETO", $"Documento a receber {id_DocReceber} não encontrada na tabela de relação.");

                            // Instancia a classe para a Ordem de Serviço que não foi encontrada na tabela Relacao_OrdemServico_CRM
                            OrdemServiçoRequest oportunidade = new OrdemServiçoRequest
                            {
                                codigoApi = "2482929491",
                                codigoOportunidade = "",
                                origemOportunidade = "Lojamix - Consumo API",
                                lead = new Lead
                                {
                                    nomeLead = $"{dataFormatada} - {idEntidade} - {nomeCliente}",
                                    telefoneLead = celular,
                                    emailLead = emailCLiente,
                                    cnpjLead = "",
                                    origemLead = "Serviço de consumo de API",
                                    contatos = new List<Contato>
                                    {
                                        new Contato
                                        {
                                            nomeContato = nomeCliente,
                                            telefoneContato = celular,
                                            emailContato = emailCLiente
                                        }
                                    }
                                },
                                contato = new Contato
                                {
                                    nomeContato = nomeCliente,
                                    telefoneContato = celular,
                                    emailContato = emailCLiente
                                },
                                followups = new List<Followup>
                                {
                                    new Followup { textoFollowup = "Essa oportunidade foi criada a partir da API de integração da LeadFinder" }
                                }
                            };

                            BoletoRelacao.Id_DocumentoReceber = Convert.ToInt32(id_DocReceber);
                            BoletoRelacao.Numero_Documento = numeroDocRec;
                            BoletoRelacao.Id_Entidade = Convert.ToInt32(idEntidade);
                            BoletoRelacao.Nome_Entidade = nomeCliente;
                            BoletoRelacao.Celular_Entidade = celular;
                            BoletoRelacao.Email_Entidade = emailCLiente;
                            BoletoRelacao.CNPJ_CPF = identificadorCliente;
                            BoletoRelacao.Situacao = situacao;
                            BoletoRelacao.Data_Vencimento = datavencimento;
                            
                            // tenta criar a oportunidade no CRM
                            OportunidadeResponse response = await EnviarBoletoParaCRM.CriarOportunidade(oportunidade, DadosAPI.Token, dalBoleto, BoletoRelacao);

                            // Verifica se o boleto já esta pago, caso esteja muda o boleto para fase Pago/Aguardando Liberação
                            if (situacao == 2)
                            {
                                string cod_oportunidade = response.CodigoOportunidade.ToString();

                                string codAcao = "02820F32C84EAE405E5A";
                                string textoFolloup = "Boleto Pago";
                                //string textoFolloup = SelecionarMensagemAtualizacao(id_Categoria);

                                AtualizarAcaoRequest AtualizarAcao = new AtualizarAcaoRequest
                                {
                                    codigoOportunidade = cod_oportunidade,
                                    codigoAcao = codAcao,
                                    codigoJornada = codigoJornada,
                                    textoFollowup = textoFolloup
                                };

                                BoletoRelacao.Quitado = 1;
                                // Atualize para a etapa pago no CRM, e atualiza no banco
                                // Passa 1 no primeiro parametro para informar que esta quitado
                                metodosGeraisBoleto.AtualizarAcaoNoCRM(1,  codigoJornada, DadosAPI, dalBoleto, BoletoRelacao, true);


                            }

                            // Caso der certo a criação entra no try
                            try
                            {
                                    MetodosGerais.RegistrarLog("BOLETO", $"Oportunidade criada para o doc a receber {id_DocReceber}: {response} ");

                                    Status = true;
                            }
                            catch (Exception ex)
                            {
                                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                                Message = $"[ERROR]: {ex.Message}";
                                Status = false;
                            }
                        }
                    }
                    else
                    {

                        MetodosGerais.RegistrarLog("BOLETO", "Boleto já existe na tabela relação");

                        // Converte a string de data de vencimento para DateTime
                        DateTime dataVencimentoConvidta = DateTime.ParseExact(datavencimento, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dataAtual = DateTime.Now;

                        // Calcula a diferença em dias entre a data atual e a data de vencimento
                        int diasAtraso = (dataAtual - dataVencimentoConvidta).Days;
                        if (diasAtraso > 0)
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto em atraso por {diasAtraso} dias.");
                        }
                        else
                        {
                            MetodosGerais.RegistrarLog("BOLETO", $"Boleto não esta em atraso!");
                        }
                        string codOportunidade = string.Empty; // Inicializa com um valor padrão
                        string quitado = string.Empty;
                        foreach (DataRow row1 in Tb.Rows)
                        {
                            quitado = row1["quitado"].ToString();
                            codOportunidade = row1["cod_oportunidade"].ToString();
                        }

                        if (situacao == 3)
                        {
                            AtualizarAcaoNoCRM(3, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                        }
                        else
                        {

                            MetodosGerais.RegistrarLog("BOLETO", $"Verificando data de vencimento do documento a receber {id_DocReceber}");



                            /*
                                Verifica se a situação é 2, caso seja significa que o boleto esta pago/quitado
                            */
                            if (!string.IsNullOrEmpty(codOportunidade))
                            {
                                if (situacao == 2)
                                {
                                    if (quitado == "0")
                                    {
                                        AtualizarAcaoNoCRM(1, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, true);
                                    }
                                }
                                else
                                {
                                    if (diasAtraso == 2)
                                    {
                                        AtualizarAcaoNoCRM(diasAtraso, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                                    }
                                    else if (diasAtraso == 5)
                                    {
                                        AtualizarAcaoNoCRM(diasAtraso, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                                    }
                                    else if (diasAtraso == 6)
                                    {
                                        AtualizarAcaoNoCRM(diasAtraso, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                                    }
                                    else if (diasAtraso == 10)
                                    {
                                        AtualizarAcaoNoCRM(diasAtraso, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                                    }
                                    else if (diasAtraso == 35)
                                    {
                                        AtualizarAcaoNoCRM(diasAtraso, codOportunidade, codigoJornada, DadosAPI, id_DocReceber, situacao, false);
                                    }
                                }
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarInicioLog("BOLETO");
                MetodosGerais.RegistrarLog("BOLETO", $"[ERROR]: {ex.Message}");
                Message = $"[ERROR]: {ex.Message}";
                Status = false;
                MetodosGerais.RegistrarFinalLog("BOLETO");
            }
        }


    }
}
