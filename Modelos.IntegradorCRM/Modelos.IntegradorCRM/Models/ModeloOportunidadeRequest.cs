using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;

namespace Modelos.IntegradorCRMRM.Models
{
    public class ModeloOportunidadeRequest
    {
        public string Numero { get; set; }
        public string Mensagem { get; set; }
      

        public ModeloOportunidadeRequest CriarOportunidade(string celular, string Mensagem)
        {

            return new ModeloOportunidadeRequest 
            {
                Numero = $"55{celular}",
                Mensagem = Mensagem
            };
        }
    }
}
