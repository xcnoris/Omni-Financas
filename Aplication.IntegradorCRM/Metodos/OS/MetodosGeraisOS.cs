using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Models.EF;

namespace Integrador_Com_CRM.Metodos.OS
{
    internal class MetodosGeraisOS
    {
        Frm_OSAcoesCRM_UC FrmOSAcoes;
        public MetodosGeraisOS(Frm_OSAcoesCRM_UC frm)
        {
            FrmOSAcoes = frm;
        }
        internal OSAcoesCRMModel SelecionarCodAcao(int idCategoria)
        {
            OSAcoesCRMModel model = FrmOSAcoes.BuscarOSAcoes(idCategoria);
            return model;
        }
    }
}
