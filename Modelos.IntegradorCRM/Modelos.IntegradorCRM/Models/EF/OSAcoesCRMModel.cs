namespace Modelos.IntegradorCRM.Models.EF
{
    public class OSAcoesModel
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string? Mensagem_Atualizacao { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
