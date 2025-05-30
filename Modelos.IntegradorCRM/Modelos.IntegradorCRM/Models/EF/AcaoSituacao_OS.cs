using Modelos.IntegradorCRM.Models.Enuns;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class AcaoSituacao_OS
    {
        public int Id { get; set; }
        public Situacao_OS Situacao { get; set; }
        public string Nome { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data_Cricao { get; set; }
        public DateTime Data_Atualizacao { get; set; }
    }
}
