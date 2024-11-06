

namespace Integrador_Com_CRM.Models.EF
{
    public class RelacaoOrdemServicoModels
    {
        public int Id { get; set; }
        public int Id_OrdemServico { get; set; }
        public string Cod_Oportunidade { get; set; }
        public int Id_CategoriaOS { get; set; }
        public DateTime Data_Criacao { get; set; }
        public DateTime? Data_Alteracao { get; set; }
        public int Situacao { get; set; }


    }
}
