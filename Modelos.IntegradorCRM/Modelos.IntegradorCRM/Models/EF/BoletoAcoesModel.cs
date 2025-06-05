namespace Modelos.IntegradorCRM.Models.EF
{
    public class BoletoAcoesModel
    {
        public int Id { get; set; }
        public int Dias_Cobrancas { get; set; }
        public string MensagemAtualizacaoWhats { get; set; }
        public string MensagemAtualizacaoEmail { get; set; }

        public bool EnviarPDFPorWhats{ get; set; }
        public bool EnviarPDFPorEmail { get; set; }
        public bool MensagemEmailEmHTML { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
