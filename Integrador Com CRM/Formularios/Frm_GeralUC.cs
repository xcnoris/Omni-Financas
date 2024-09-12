using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Metodos.OS;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_GeralUC : UserControl
    {
        private readonly ControleOrdemDeServico controlOrdemServico;
        private readonly Frm_DadosAPIUC DadosAPI;

        public Frm_GeralUC(ControleOrdemDeServico controlOS,Frm_DadosAPIUC dadosAPI)
        {
            InitializeComponent();
            controlOrdemServico = controlOS;
            DadosAPI = dadosAPI;
        }

        private void Btn_BuscarOS_Click(object sender, EventArgs e)
        {
            try
            {
                controlOrdemServico.VerificarNovosServicos(DadosAPI);
              
                MetodosGerais.RegistrarLog("OS", $"=======>>> Ordens de serviço consultadas manualmente <<<=======\n");
                MessageBox.Show("Consulta de Ordem de Serviço Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("OS", $"Error :{ex.Message}");
            }
        }
    }
}
