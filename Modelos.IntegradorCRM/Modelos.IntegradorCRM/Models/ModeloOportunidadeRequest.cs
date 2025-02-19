using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Retornos;

namespace Modelos.IntegradorCRMRM.Models
{
    public class ModeloOportunidadeRequest
    {
        public string codigoApi { get; set; }
        public string codigoOportunidade { get; set; }
        public string origemOportunidade { get; set; }
        public string nomeLead { get; set; }
        public Lead lead { get; set; }
        public Contato contato { get; set; }
        public List<Followup> followups { get; set; }


        public ModeloOportunidadeRequest CriarOportunidade(RetornoBoleto boleto, DadosAPIModels DadosAPI)
        {
            string dataFormatada = boleto.Data_Vencimento.ToString("dd/MM/yyyy");

            return new ModeloOportunidadeRequest 
            {
                codigoApi = DadosAPI.Cod_API_Boleto,  // Define o código da API
                codigoOportunidade = "",   // O código da oportunidade será definido mais tarde
                origemOportunidade = "Lojamix - Boletos - Consumo API", // Origem da oportunidade
                lead = new Lead
                {
                    nomeLead = $"{dataFormatada} - {boleto.Id_Entidade} - {boleto.Nome}",
                    telefoneLead = boleto.Celular,
                    emailLead = boleto.Email,
                    cnpjLead = "",  // Definir o CNPJ ou CPF do cliente
                    origemLead = "Serviço de consumo de API",
                    contatos = new List<Contato>
                    {
                        new Contato
                        {
                            nomeContato = boleto.Nome,
                            telefoneContato = boleto.Celular,
                            emailContato = boleto.Email
                        }
                    }
                },
                contato = new Contato
                {
                    nomeContato = boleto.Nome,
                    telefoneContato = boleto.Celular,
                    emailContato = boleto.Email
                },
                followups = new List<Followup>
                {
                    new Followup { textoFollowup = "Essa oportunidade foi criada a partir da API de integração da LeadFinder" }
                }
            };

        }


    }
}
