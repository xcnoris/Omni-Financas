
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;
using Modelos.IntegradorCRM.Models.EF;
using System.ComponentModel.DataAnnotations;

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
                if (DGV_Dados.Columns.Count == 1)
                {

                    DGV_Dados.Columns.Add("ID", "ID");
                    DGV_Dados.Columns["ID"].Width = 30;
                    DGV_Dados.Columns["ID"].ReadOnly = true;

                    DGV_Dados.Columns.Add("Dia_Cobranca", "Dia Cobrança");
                    DGV_Dados.Columns["Dia_Cobranca"].Width = 300;

                    DGV_Dados.Columns.Add("Codigo_Acao", "Codigo Ação");
                    DGV_Dados.Columns["Codigo_Acao"].Width = 350;

                    DGV_Dados.Columns.Add("Mensagem", "Mensagem Ação");
                    DGV_Dados.Columns["Mensagem"].Width = 350;

                    DGV_Dados.Columns["CheckBox"].DisplayIndex = 3;



                    // Impede que a última coluna ocupe todo o espaço
                    DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

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
                    if (VerificaValoresRepetidos())
                    {
                        BoletoAcoesCRMModel boleto = new BoletoAcoesCRMModel() { Dias_Cobrancas = Convert.ToInt32(Txt_DiasCobrancas.Text), Codigo_Acao = Txt_CodAcao.Text, Mensagem_Atualizacao = Txt_Mensagem.Text, Data_Criacao = DateTime.Now };
                        AddAcaoToDataGridView(boleto);
                        BoletoAcaoList.Add(boleto);
                        LimparTXT();
                    }
                    else
                    {
                        MessageBox.Show($"Valores Repetidos De Dias de Cobranças não são permitidos!", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show($"Todos os Campos devem ser preenchidos!", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private bool VerificaValoresRepetidos()
        {
            try
            {
                BoletoAcoesCRMModel BAM = BoletoAcaoList.FirstOrDefault(x =>x.Dias_Cobrancas == Convert.ToInt32(Txt_DiasCobrancas.Text));
                if (BAM is null) 
                {
                    return true;
                }
                else
                {
                    return false;
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
                    BoletoAcao.EnviarPDF,
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
                    bool EnviarPDF = Convert.ToBoolean(row.Cells["CheckBox"].Value);

                    // Criar um objeto para representar o registro da linha
                    var boletoAcao = new BoletoAcoesCRMModel
                    {
                        Id = id ?? 0,  // Se o ID for nulo, inicialize com 0 para um novo registro
                        Dias_Cobrancas = diasCobrancas,
                        Codigo_Acao = codigoAcao,
                        Mensagem_Atualizacao = Mensagem,
                        EnviarPDF=EnviarPDF,
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
                            registroExistente.EnviarPDF = EnviarPDF;

                            await dalBoletoAcoes.AtualizarAsync(registroExistente);
                        }
                        else
                        {
                            // Se o registro não existe, adiciona um novo
                            boletoAcao.Data_Criacao = id.HasValue && id.Value > 0 ? registroExistente.Data_Criacao : DateTime.Now;
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

        private bool ValidarDiasCobrancasInDGV()
        {
            try
            {
                // Dicionário para rastrear valores únicos de Dia_Cobranca
                HashSet<int> diasCobrancaUnicos = new HashSet<int>();

                foreach (DataGridViewRow row in DGV_Dados.Rows)
                {
                    // Obter o valor de Dia_Cobranca da linha
                    var diaCobrancaValue = row.Cells["Dia_Cobranca"].Value;
                    if (diaCobrancaValue != null)
                    {
                        int diaCobranca = Convert.ToInt32(diaCobrancaValue);

                        // Verifica se já existe o valor de Dia_Cobranca
                        if (diasCobrancaUnicos.Contains(diaCobranca))
                        {
                            MessageBox.Show($"O valor do Dia de Cobrança '{diaCobranca}' está duplicado! Por favor, verifique.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false; // Para a execução se houver duplicatas
                        }

                        // Adiciona o valor ao HashSet se for único
                        diasCobrancaUnicos.Add(diaCobranca);
                    }
                }

                // Retorna verdadeiro se todos os valores forem válidos
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($" {ex.Message}", $"App Carrinho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                return false;
            }
        }

        private bool ValidarCamposNulos()
        {
            try
            {
                foreach (DataGridViewRow row in DGV_Dados.Rows)
                {
                    string codigoAcao = row.Cells["Codigo_Acao"].Value.ToString();
                    string Mensagem = row.Cells["Mensagem"].Value.ToString();
                    if ((row.Cells["Dia_Cobranca"].Value) is not null)
                    {
                        if (string.IsNullOrWhiteSpace(row.Cells["Dia_Cobranca"].Value.ToString()))
                        {
                            return false;
                        }
                    }
                    
                }

                // Retorna verdadeiro se todos os valores forem válidos
                return true;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                return false;
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
           
        }
 
    }
}
