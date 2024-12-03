using Modelos.IntegradorCRM.Models.Enuns;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class AcaoSituacao_OS_CRM
    {
        public int Id { get; set; }
        public Situacao_OS Situacao { get; set; }
        public string CodAcaoCRM { get; set; }
        public string Mensagem_Acao { get; set; }
        public DateTime Data_Cricao { get; set; }
        public DateTime Data_Atualizacao { get; set; }
    }
}
