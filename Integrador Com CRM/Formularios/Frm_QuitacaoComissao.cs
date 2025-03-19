using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_QuitacaoComissao : Form
    {
        private readonly DAL<Controle_Liberacao_ComissaoModel> _dalControleComissao;


        public Frm_QuitacaoComissao(string nomevendedor, string dataInicio, string dataFim, string ValorTotal)
        {
            InitializeComponent();

            _dalControleComissao = new DAL<Controle_Liberacao_ComissaoModel>(new IntegradorDBContext());

            CarregarCampos(nomevendedor, dataInicio, dataFim, ValorTotal);
        }

        private void CarregarCampos(string nomevendedor, string dataInicio, string dataFim, string ValorTotal)
        {
            Lbl_VendedorNome.Text = nomevendedor;
            Lbl_DTInicio.Text = dataInicio;
            Lbl_DTFim.Text = dataFim;
            Lbl_ValorTotal.Text = ValorTotal;
        }

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_QuitarComis_Click(object sender, EventArgs e)
        {
            MarcaPagoComissoesPorPeriodoQuitacao();
        }

        private async Task MarcaPagoComissoesPorPeriodoQuitacao()
        {
            try
            {

                DateTime dataInicio = Convert.ToDateTime(Lbl_DTInicio.Text).Date; // Garante que começa no início do dia
                DateTime dataFim = Convert.ToDateTime(Lbl_DTFim.Text).Date.AddDays(1).AddTicks(-1); // Último milissegundo do dia


                await _dalControleComissao.AtualizarPorCondicaoAsync(
                    x => x.Data_Quitacao >= dataInicio &&
                         x.Data_Quitacao <= dataFim &&
                         x.Pago_para_Vendedor == 0,
                    x => x.SetProperty(
                        y => y.Pago_para_Vendedor, y => 1));
                MessageBox.Show("Comissões foram QUITADAS!", "Quitacao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("ComissaoOperacoes", $"Ocorreu um erro ao marcar como pagos as comissoes no perido: {Lbl_DTInicio.Text} até {Lbl_DTFim.Text}", ex);
                MessageBox.Show("Erro ao Quitar comissões", "Quitacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
