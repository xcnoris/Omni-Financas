namespace Modelos.IntegradorCRM.Models.EF
{
    public class Controle_Liberacao_ComissaoModel
    {
        public int Id { get; set; }
        public int Id_Usuario_Vendedor { get; set; }
        public string Nome_Vendedor { get; set; }
        public int? Id_Pedido_Venda { get; set; }
        public int? Id_Documento_Receber { get; set; }
        public string? Numero_Documento_Receber { get; set; }
        public DateTime? Data_Vencimento { get; set; }
        public DateTime? Data_Quitacao { get; set; }
        public int? Situacao { get; set; }
        public int DR_Total_Gerados { get; set; }
        public Decimal Valor_Comissao_Por_Parcela { get; set; }
        public int Pago_para_Vendedor { get; set; }
    }
}
