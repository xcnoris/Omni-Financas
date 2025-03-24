using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;

namespace Modelos.IntegradorCRMRM.Models
{
    public class ModeloOportunidadeRequest
    {
        public string Numero { get; set; }
        public string Mensagem { get; set; }
      

        public ModeloOportunidadeRequest CriarOportunidade(RetornoBoleto boleto, DadosAPIModels DadosAPI)
        {
            string dataFormatada = boleto.Data_Vencimento.ToString("dd/MM/yyyy");

            return new ModeloOportunidadeRequest 
            {
            //
            };
        }
    }
}
