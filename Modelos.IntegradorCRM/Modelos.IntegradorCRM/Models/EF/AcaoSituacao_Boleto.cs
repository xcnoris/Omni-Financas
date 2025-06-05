using Modelos.IntegradorCRM.Models.Enuns;

namespace Modelos.IntegradorCRM.Models.EF
{
    public class AcaoSituacao_Boleto
    {
        public int Id { get; set; }
        public Situacao_Boleto Situacao { get; set; }
        public string Nome { get; set; }
        public string MensagemAtualizacaoWhats { get; set; }
        public string MensagemAtualizacaoEmail { get; set; }

        public bool EnviarPDFPorWhats { get; set; }
        public bool EnviarPDFPorEmail { get; set; }
        public bool MensagemEmailEmHTML { get; set; }
        public DateTime Data_Cricao { get; set; }
        public DateTime Data_Atualizacao { get; set; }

    }
}
