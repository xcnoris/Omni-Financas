
using Aplication.IntegradorCRM.Metodos.Boleto;
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_GeralUC : UserControl
    {
        private readonly ControleOrdemDeServico controlOrdemServico;
        private readonly ControleBoletos controlBoletos;
        private readonly CobrancasNaSegundaModel cobrancas;
        private readonly DadosAPIModels DadosAPI;
        private readonly Frm_BoletoAcoesCRM_UC BoletoAcoes;
        DAL<BoletoAcoesCRMModel> osList;

        public Frm_GeralUC(ControleOrdemDeServico controlOS, ControleBoletos controleBoletos, DadosAPIModels dadosAPI, Frm_BoletoAcoesCRM_UC BoletosAcoes)
        {
            InitializeComponent();

            controlOrdemServico = controlOS;
            BoletoAcoes = BoletosAcoes;
            controlBoletos = new ControleBoletos(osList);
            cobrancas = new CobrancasNaSegundaModel();
            DadosAPI = dadosAPI;
        }

        private async void Btn_BuscarOS_Click(object sender, EventArgs e)
        {
            try
            {
                MetodosGerais.RegistrarLog("OS", $"\n---------- Ordens de serviço consultadas manualmente ------------\n");
                await controlOrdemServico.VerificarNovosServicos(DadosAPI);

                MessageBox.Show("Consulta de Ordem de Serviço Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("OS", $"Error :{ex.Message}");
            }
        }

        private async void Btn_BuscarBoletos_Click(object sender, EventArgs e)
        {
            try
            {
                MetodosGerais.RegistrarLog("BOLETO", $"\n----------------> Boletos consultados manualmente <-----------------\n");

                //await controlBoletos.VerificarNovosBoletos(DadosAPI);

                MessageBox.Show("Consulta de Boletos Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("BOLETO", $"Error :{ex.Message}");
            }
        }

        private async void Btn_RealizarCobrancas_Click(object sender, EventArgs e)
        {
            try
            {
                MetodosGerais.RegistrarLog("COBRANCA", $"\n------------------> Cobrança consultadas manualmente <-------------------\n");
                //await cobrancas(DadosAPI);

                MessageBox.Show("Cobranças de Boletos Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("COBRANCA", $"Error :{ex.Message}");
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("COBRANCA");
            }
        }
    }
}
