using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDI_OminiService.Formularios
{
    public partial class FrmEtapaBoletoUC : UserControl
    {
        private readonly DAL<BoletoAcoesModel> _dalAcoesBoleto;
        private List<RelacaoBoletoModel> BoletoAcaoList;

        public int DiaCobranca
        {
            get
            {
                return Convert.ToInt32(Cbox_DiaCobranca.Text);
            }
        }

        public FrmEtapaBoletoUC()
        {
            InitializeComponent();

            _dalAcoesBoleto = new DAL<BoletoAcoesModel>(new IntegradorDBContext());

            PopularCboxDiaCobranca();

            AddColumnDataGridView();
        }

        private async Task PopularCboxDiaCobranca()
        {
            List<BoletoAcoesModel> AcoesBoletoList = (await _dalAcoesBoleto.ListarAsync()).ToList();

            Cbox_DiaCobranca.DataSource = AcoesBoletoList;
            Cbox_DiaCobranca.DisplayMember = "Dias_Cobrancas";
            Cbox_DiaCobranca.ValueMember = "Dias_Cobrancas";
        }

        private void Btn_BuscarBoletos_Click(object sender, EventArgs e)
        {
            CarregarListaDeBoletoPorAcaoSelecionada();
        }


        private async Task CarregarListaDeBoletoPorAcaoSelecionada()
        {
            try
            {
                using DAL<RelacaoBoletoModel> dalBoletoRelacao = new DAL<RelacaoBoletoModel>(new IntegradorDBContext());
                if (BoletoAcaoList is not null)
                {
                    BoletoAcaoList.Clear();
                }
                BoletoAcaoList = (await dalBoletoRelacao.RecuperarTodosPorAsync(x => x.DiasEmAtraso.Equals(DiaCobranca) && x.Quitado.Equals(0))).ToList();
                await CarregarDados();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }

        }

        private async Task CarregarDados()
        {
            try
            {
                if (BoletoAcaoList is not null)
                {
                    DGV_Dados.Rows.Clear();
                    foreach (RelacaoBoletoModel boleto in BoletoAcaoList)
                    {
                        AddAcaoToDataGridView(boleto);
                    }
                
                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
            finally
            {
                AtualizarContadorDeItens();
            }
        }

        private void AtualizarContadorDeItens()
        {
            Txt_NumItens.Text = "";
            Txt_NumItens.Text = DGV_Dados.RowCount.ToString();
        }


        // Recebe um object e convert para uma linha do DataGridView
        private void AddAcaoToDataGridView(RelacaoBoletoModel Boleto)
        {
            try
            {
                AddColumnDataGridView();

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(
                    Boleto.Id_DocumentoReceber,
                    Boleto.Numero_Documento,
                    $"{Boleto.Id_Entidade} - {Boleto.Nome_Entidade}",
                    Boleto.Data_Atualizacao.ToString("dd/MM/yyyy")
                );
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private void AddColumnDataGridView()
        {
            try
            {
                if (DGV_Dados.Columns.Count == 0)
                {

                    DGV_Dados.Columns.Add("ID_DR", "Id DR");
                    DGV_Dados.Columns["ID_DR"].Width = 150;
                    DGV_Dados.Columns["ID_DR"].ReadOnly = true;

                    DGV_Dados.Columns.Add("Num_DR", "Num DR");
                    DGV_Dados.Columns["Num_DR"].Width = 400;
                    DGV_Dados.Columns["Num_DR"].ReadOnly = true;

                    DGV_Dados.Columns.Add("Cliente", "Cliente");
                    DGV_Dados.Columns["Cliente"].Width = 500;
                    DGV_Dados.Columns["Cliente"].ReadOnly = true;

                    DGV_Dados.Columns.Add("DT_Ven", "Vencimento");
                    DGV_Dados.Columns["DT_Ven"].Width = 150;
                    DGV_Dados.Columns["DT_Ven"].ReadOnly = true;




                    // Impede que a última coluna ocupe todo o espaço
                    DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }
    }
}
