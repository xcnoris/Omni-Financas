namespace Modelos.IntegradorCRMRM.Models
{
    public class RetornoOrdemServico
    {
        public string Id_Ordem_Servico { get; set; }
        public string NSU { get; set; }
        public string Identificador_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public string Celular { get; set; }
        public string? Email_Cliente { get; set; }
        public string Id_CategoriaOS { get; set; }
        public string Categoria { get; set; }
        public string Situacao { get; set; }
    }
}
