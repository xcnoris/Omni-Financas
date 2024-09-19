using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Models.EF;
using Microsoft.Data.SqlClient;
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

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_BoletoAcoesCRM_UC : UserControl
    {
        private readonly DAL<BoletoAcoesCRMModel> dalBoletoAcoes;
        private List<BoletoAcoesCRMModel> BoletoAcaoList;


        public Frm_BoletoAcoesCRM_UC()
        {
            InitializeComponent();

            dalBoletoAcoes = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());

            AddColumnDataGridView();
            CarregarListaDeBoletoAcao();

        }

        internal BoletoAcoesCRMModel BuscarBoletoAcoes(int DiaEmsAtraso)
        {
            try
            {
                return BoletoAcaoList.FirstOrDefault(x => x.Dias_Cobrancas == DiaEmsAtraso);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                return null;
            }
        }
        private async Task CarregarListaDeBoletoAcao()
        {
            try
            {
                if (BoletoAcaoList is not null)
                {
                    BoletoAcaoList.Clear();
                }
                BoletoAcaoList = (await dalBoletoAcoes.ListarAsync()).ToList();
                CarregarDados();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BoletoAcoesCRMModel boleto = BoletoAcaoList.FirstOrDefault(x => x.Id == id);
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
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private void AddColumnDataGridView()
        {
            try
            {
                // Se o DataGridView não tiver colunas, adicione-as
                if (DGV_Dados.Columns.Count == 0)
                {
                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns["ID"].ReadOnly = true;
                    DGV_Dados.Columns.Add("Dia_Cobranca", "Dia Cobrança");
                    DGV_Dados.Columns.Add("Codigo_Acao", "Codigo Ação");
                    DGV_Dados.Columns.Add("Mensagem", "Mensagem Ação");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }
        private void LimparTXT()
        {
            Txt_DiasCobrancas.Text = string.Empty;
            Txt_CodAcao.Text = string.Empty;
            Txt_Mensagem.Text = string.Empty;

        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                bool verificar = VerificaCamposNulos();
                if (verificar)
                {
                    BoletoAcoesCRMModel boleto = new BoletoAcoesCRMModel() { Dias_Cobrancas = Convert.ToInt32(Txt_DiasCobrancas.Text), Codigo_Acao = Txt_CodAcao.Text, Mensagem_Atualizacao = Txt_Mensagem.Text };
                    AddAcaoToDataGridView(boleto);
                    BoletoAcaoList.Add(boleto);
                    LimparTXT();
                }
                else
                {
                    MessageBox.Show($"Todos os Campos devem ser preenchidos!", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro de Sql: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }
        private bool VerificaCamposNulos()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Txt_DiasCobrancas.Text) 
                    || string.IsNullOrWhiteSpace(Txt_CodAcao.Text)
                    || string.IsNullOrWhiteSpace(Txt_Mensagem.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                return false;
            }
        }

        // Recebe um object e convert para uma linha do DataGridView
        private void AddAcaoToDataGridView(BoletoAcoesCRMModel BoletoAcao)
        {
            try
            {
                AddColumnDataGridView();

                // Adicionar a linha ao DataGridView
                DGV_Dados.Rows.Add(
                    BoletoAcao.Id,
                    BoletoAcao.Dias_Cobrancas,
                    BoletoAcao.Codigo_Acao,
                    BoletoAcao.Mensagem_Atualizacao
                );
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private async void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in DGV_Dados.Rows)
                {

                    // Obter o ID da linha
                    var idValue = row.Cells["ID"].Value;
                    int? id = idValue != null ? Convert.ToInt32(idValue) : (int?)null;

                    // Obter os dados da linha
                    int diasCobrancas = Convert.ToInt32(row.Cells["Dia_Cobranca"].Value);
                    string codigoAcao = row.Cells["Codigo_Acao"].Value.ToString();
                    string Mensagem = row.Cells["Mensagem"].Value.ToString();

                    // Criar um objeto para representar o registro da linha
                    var boletoAcao = new BoletoAcoesCRMModel
                    {
                        Id = id ?? 0,  // Se o ID for nulo, inicialize com 0 para um novo registro
                        Dias_Cobrancas = diasCobrancas,
                        Codigo_Acao = codigoAcao,
                        Mensagem_Atualizacao = Mensagem
                    };

                    if (id.HasValue && id.Value > 0)
                    {
                        // Verifica se o registro já existe no banco
                        BoletoAcoesCRMModel registroExistente = await dalBoletoAcoes.BuscarPorAsync(x => x.Id == id);

                        if (registroExistente != null)
                        {
                            // Atualiza os dados do registro existente
                            registroExistente.Dias_Cobrancas = diasCobrancas;
                            registroExistente.Codigo_Acao = codigoAcao;

                            await dalBoletoAcoes.AtualizarAsync(registroExistente);
                        }
                        else
                        {
                            // Se o registro não existe, adiciona um novo
                            await dalBoletoAcoes.AdicionarAsync(boletoAcao);
                        }
                    }
                    else
                    {
                        // Adiciona um novo registro se o ID for nulo ou 0
                        await dalBoletoAcoes.AdicionarAsync(boletoAcao);
                    }
                }

                MessageBox.Show("Dados salvos com sucesso!", "App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
            finally
            {
                CarregarListaDeBoletoAcao();
            }
        }

        private async Task CarregarDados()
        {
            try
            {
                if (BoletoAcaoList is not null)
                {
                    DGV_Dados.Rows.Clear();
                    foreach (BoletoAcoesCRMModel boleto in BoletoAcaoList)
                    {
                        AddAcaoToDataGridView(boleto);
                    }
                }

            }
            catch (ValidationException ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
            }
        }

        private void Txt_DiasCobrancas_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado não é um número e não é a tecla de backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancela o evento se o caractere não for válido (não numérico)
                e.Handled = true;
            }
        }
 
    }
}
