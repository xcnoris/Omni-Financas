﻿
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using Modelos.IntegradorCRM.Models.EF;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_BoletoAcoesCRM_UC : UserControl
    {
        private readonly DAL<BoletoAcoesModel> dalBoletoAcoes;
        private List<BoletoAcoesModel> BoletoAcaoList;
        private List<Frm_CadastroAcoesBoletos> FrmAbertos;


        public Frm_BoletoAcoesCRM_UC()
        {
            InitializeComponent();

            dalBoletoAcoes = new DAL<BoletoAcoesModel>(new IntegradorDBContext());
            FrmAbertos = new List<Frm_CadastroAcoesBoletos>();

            AddColumnDataGridView();
            CarregarListaDeBoletoAcao();

        }

        private async Task CarregarListaDeBoletoAcao()
        {
            try
            {
                using DAL<BoletoAcoesModel> dalBoletoAcoe = new DAL<BoletoAcoesModel>(new IntegradorDBContext());
                if (BoletoAcaoList is not null)
                {
                    BoletoAcaoList.Clear();
                }
                BoletoAcaoList = (await dalBoletoAcoe.ListarAsync()).ToList();
                CarregarDados();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }

        }


        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            try
            {
                var resposta = MessageBox.Show("Você Realmente quer excluir o dado selecionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resposta == DialogResult.Yes)
                {
                    // Retrieve the selected row data
                    var selectedRow = DGV_Dados.CurrentRow;
                    int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    BoletoAcoesModel boleto = BoletoAcaoList.FirstOrDefault(x => x.Id == id);
                    if (boleto is not null)
                    {
                        dalBoletoAcoes.DeletarAsync(boleto);
                        BoletoAcaoList.Remove(boleto);
                        CarregarDados();
                    }

                    MetodosGerais.RegistrarLog("Geral", $"Dado Excluido: Id {boleto.Id} - Table: boletoAcoes_CRM");
                }
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
                if (DGV_Dados.Columns.Count == 3)
                {

                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns["ID"].Width = 10;
                    DGV_Dados.Columns["ID"].ReadOnly = true;

                    DGV_Dados.Columns.Add("Dia_Cobranca", "Dia Cobrança");
                    DGV_Dados.Columns["Dia_Cobranca"].Width = 350;

                    DGV_Dados.Columns.Add("Mensagem", "Mensagem Whats");
                    DGV_Dados.Columns["Mensagem"].Width = 200;


                    DGV_Dados.Columns.Add("MensagemEmail", "Mensagem Email");
                    DGV_Dados.Columns["MensagemEmail"].Width = 200;


                    DGV_Dados.Columns["CheckBox"].DisplayIndex = 6;
                    DGV_Dados.Columns["CheckBox"].Width = 50;

                    DGV_Dados.Columns["ChboxPDFEmail"].DisplayIndex = 6;
                    DGV_Dados.Columns["ChboxPDFEmail"].Width = 50;

                    DGV_Dados.Columns["ChboxEmailHTML"].DisplayIndex = 6;
                    DGV_Dados.Columns["ChboxEmailHTML"].Width = 50;

                    DGV_Dados.Columns["Mensagem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    DGV_Dados.Columns["CheckBox"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DGV_Dados.Columns["ChboxPDFEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DGV_Dados.Columns["ChboxEmailHTML"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


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



        // Recebe um object e convert para uma linha do DataGridView
        private void AddAcaoToDataGridView(BoletoAcoesModel BoletoAcao)
        {
            try
            {
                AddColumnDataGridView();

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(
                    BoletoAcao.EnviarPDFPorWhats,
                    BoletoAcao.EnviarPDFPorEmail,
                    BoletoAcao.MensagemEmailEmHTML,
                    BoletoAcao.Id,
                    BoletoAcao.Dias_Cobrancas,
                    BoletoAcao.MensagemAtualizacaoWhats,
                    BoletoAcao.MensagemAtualizacaoEmail

                );
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private async void Btn_Salvar_Click(object sender, EventArgs e)
        {
            Incluir();
        }


        private async Task Incluir()
        {

            Frm_CadastroAcoesBoletos FrmCadastroOS = new Frm_CadastroAcoesBoletos(true, new BoletoAcoesModel(), "Incluir", this);
            await FrmCadastroOS.MostrarFormulario();
            await CarregarListaDeBoletoAcao();
        }



        private async Task CarregarDados()
        {
            try
            {
                if (BoletoAcaoList is not null)
                {
                    DGV_Dados.Rows.Clear();
                    foreach (BoletoAcoesModel boleto in BoletoAcaoList)
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
        }


        private void DGV_Dados_DoubleClick(object sender, EventArgs e)
        {
            AtualizarAcao();
        }

        private async Task AtualizarAcao()
        {
            try
            {
                var selectedRow = DGV_Dados.CurrentRow;
                var idValue = selectedRow.Cells["ID"].Value;
                int? id = idValue != null ? Convert.ToInt32(idValue) : (int?)null;

                int diasCobrancas = Convert.ToInt32(selectedRow.Cells["Dia_Cobranca"].Value);
                string MensagemWhats = selectedRow.Cells["Mensagem"].Value.ToString();
                string MensagemEmail = selectedRow.Cells["MensagemEmail"].Value.ToString();
                bool EnviarPDFWhats = Convert.ToBoolean(selectedRow.Cells["CheckBox"].Value);
                bool EnviarPDFEmail = Convert.ToBoolean(selectedRow.Cells["ChboxPDFEmail"].Value);
                bool MensagemEmHTML = Convert.ToBoolean(selectedRow.Cells["ChboxEmailHTML"].Value);

                // Criar um objeto para representar o registro da linha
                BoletoAcoesModel boletoAcao = new BoletoAcoesModel
                {
                    Id = id ?? 0,  // Se o ID for nulo, inicialize com 0 para um novo registro
                    Dias_Cobrancas = diasCobrancas,
                    MensagemAtualizacaoWhats = MensagemWhats,
                    MensagemAtualizacaoEmail = MensagemEmail,
                    EnviarPDFPorWhats = EnviarPDFWhats,
                    EnviarPDFPorEmail = EnviarPDFEmail,
                    MensagemEmailEmHTML = MensagemEmHTML,

                };


                Frm_CadastroAcoesBoletos? Frm = FrmAberto(diasCobrancas);
                if (Frm is not null)
                {
                    MessageBox.Show($"Já existe uma tela de edição de mensagem para essa data de cobrança!", $"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Frm.Focus();
                    return;
                }


                Frm_CadastroAcoesBoletos FrmCadAcoesBoleto = new Frm_CadastroAcoesBoletos(false, boletoAcao, "Atualizar", this);
                FrmAbertos.Add(FrmCadAcoesBoleto);
                await FrmCadAcoesBoleto.MostrarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }


        // Verifica se já existe um formulario aberto de edição da cobrança X
        private Frm_CadastroAcoesBoletos? FrmAberto(int DiasCobrancas) 
        {
            return FrmAbertos.FirstOrDefault(x => x.DiaCobranca.Equals(DiasCobrancas));
        }

        internal void RemoverFrmDaListFrmAbertos(int DiasCobrancas)
        {
            Frm_CadastroAcoesBoletos? Frm = FrmAbertos.FirstOrDefault(x => x.DiaCobranca.Equals(DiasCobrancas));
            if (Frm is not null)
                FrmAbertos.Remove(Frm);
            CarregarListaDeBoletoAcao();
        }

        private void Btn_Salvar_MouseEnter(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Salvar_MouseLeave(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.Teal;
        }

        private void Btn_Remover_MouseEnter(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.Silver;
        }

        private void Btn_Remover_MouseLeave(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.DarkGray;
        }
    }
}
