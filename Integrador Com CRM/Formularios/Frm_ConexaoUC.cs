using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Microsoft.Data.SqlClient;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_ConexaoUC : UserControl
    {
        public string Servidor
        {
            get { return Txt_Servidor.Text; }
        }
        public string IpHost
        {
            get { return Txt_IpHost.Text; }
        }
        public string DataBase
        {
            get { return Txt_DataBase.Text; }
        }
        public string Usuario
        {
            get { return Txt_Usuario.Text; }
        }
        public string Senha
        {
            get { return Txt_Senha.Text; }
        }

        public Frm_ConexaoUC()
        {
            InitializeComponent();

            CarregarDadosConexao();
        }

        internal bool TestarConexaoDB(bool exibirMensagemConfirmacao)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Cria uma instância de ConexaoDB com os dados fornecidos no formulário
                ConexaoDB conexao = new ConexaoDB
                {
                    Servidor = Txt_Servidor.Text,
                    IpHost = Txt_IpHost.Text,
                    DataBase = Txt_DataBase.Text,
                    Usuario = Txt_Usuario.Text,
                    Senha = Txt_Senha.Text
                };

                // Monta a string de conexão com os dados fornecidos
                string connectionString = $"Server={conexao.IpHost};Database={conexao.DataBase};User Id={conexao.Usuario};Password={conexao.Senha};TrustServerCertificate=True";
                MetodosGerais.RegistrarInicioLog("ConexãoDB");
                MetodosGerais.RegistrarLog("ConexãoDB", $"Testando conexão banco de dados {conexao.DataBase}...");

                // Tenta abrir a conexão
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    if (exibirMensagemConfirmacao)
                        MessageBox.Show("Conexão bem-sucedida!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MetodosGerais.RegistrarLog("ConexãoDB", $"Conexão bem-sucedida com o banco de dados {conexao.DataBase}!");
                    sqlConnection.Close();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MetodosGerais.RegistrarLog("ConexãoDB", $"Erro ao testar conexão: {ex.Message}. Verique a string de conexão!");
                if (exibirMensagemConfirmacao)
                    MessageBox.Show("Erro ao testar conexão: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("ConexãoDB", $"Erro ao testar conexão: {ex.Message}. Verique a string de conexão!");
                if (exibirMensagemConfirmacao)
                    MessageBox.Show("Erro ao testar conexão: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
                MetodosGerais.RegistrarFinalLog("ConexãoDB");
            }


        }

        private void Btn_TestarConexao_Click(object sender, EventArgs e)
        {
            TestarConexaoDB(true);
        }

        private void Frm_ConexaoUC_Load(object sender, EventArgs e)
        {

        }

        private void CarregarDadosConexao()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                ConexaoDB conexao = ConexaoDB.LoadConnectionData(filePath);
                if (conexao != null)
                {
                    Txt_Servidor.Text = conexao.Servidor;
                    Txt_IpHost.Text = conexao.IpHost;
                    Txt_DataBase.Text = conexao.DataBase;
                    Txt_Usuario.Text = conexao.Usuario;
                    Txt_Senha.Text = conexao.Senha;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados de conexão: " + ex.Message);
            }
        }

        private void Btn_TestarConexao_MouseEnter(object sender, EventArgs e)
        {
            Btn_TestarConexao.BackColor = Color.MediumTurquoise;
        }

        private void Btn_TestarConexao_MouseLeave(object sender, EventArgs e)
        {
            Btn_TestarConexao.BackColor = Color.Teal;
        }
    }
}
