using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrador_Com_CRM.Models
{
    internal class OrdemServiçoRequest
    {
        public string codigoApi { get; set; }
        public string codigoOportunidade { get; set; }
        public string origemOportunidade { get; set; }
        public string nomeLead { get; set; }
        public Lead lead { get; set; }
        public Contato contato { get; set; }
        public List<Followup> followups { get; set; }


        internal  OrdemServiçoRequest CriarOportunidade(RetornoBoleto boleto)
        {
            string dataFormatada = boleto.Data_Vencimento.ToString("dd/MM/yyyy");

            return new OrdemServiçoRequest 
            {

                codigoApi = "2482929491",  // Define o código da API
                codigoOportunidade = "",   // O código da oportunidade será definido mais tarde
                origemOportunidade = "Lojamix - Consumo API", // Origem da oportunidade
                lead = new Lead
                {
                    nomeLead = $"{dataFormatada} - {boleto.Id_Entidade} - {boleto.Nome}",
                    telefoneLead = boleto.Celular,
                    emailLead = boleto.Email,
                    cnpjLead = boleto.Identificador_Cliente,  // Definir o CNPJ ou CPF do cliente
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
