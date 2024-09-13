using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Metodos.Boleto;
using Integrador_Com_CRM.Metodos.OS;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_GeralUC : UserControl
    {
        private readonly ControleOrdemDeServico controlOrdemServico;
        private readonly ControleBoletos controlBoletos;
        private readonly Frm_DadosAPIUC DadosAPI;

        public Frm_GeralUC(ControleOrdemDeServico controlOS, ControleBoletos controleBoletos,Frm_DadosAPIUC dadosAPI)
        {
            InitializeComponent();

            controlOrdemServico = controlOS;
            controlBoletos = new ControleBoletos();
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

        private void Btn_BuscarBoletos_Click(object sender, EventArgs e)
        {
            try
            {
                controlBoletos.VerificarNovosBoletos(DadosAPI);

                MetodosGerais.RegistrarLog("OS", $"=======>>> Boletos consultados manualmente <<<=======\n");
                MessageBox.Show("Consulta de Boletos Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("OS", $"Error :{ex.Message}");
            }
        }
    }
}
