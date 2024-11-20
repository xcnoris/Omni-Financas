namespace Modelos.IntegradorCRM.Models.EF
{
    public class BoletoAcoesCRMModel
    {
        public int Id { get; set; }
        public int Dias_Cobrancas { get; set; }
        public string Codigo_Acao { get; set; }
        public string Mensagem_Atualizacao { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
