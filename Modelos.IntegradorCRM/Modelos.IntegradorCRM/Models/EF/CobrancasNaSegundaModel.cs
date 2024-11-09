namespace Modelos.IntegradorCRM.Models.EF
{
    public class CobrancasNaSegundaModel
    {

        public int Id { get; set; }
        public string CodigoJornada { get; set; }
        public int BoletoId { get; set; }
        public RelacaoBoletoCRMModel? Boleto { get; set; }
        public int NovoAtrasoBoleto { get; set; }
        public string Cod_Oportunidade { get; set; }
    }
}
