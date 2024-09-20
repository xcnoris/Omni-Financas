using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace MigratorDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CarregarDadosConexao();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                ConexaoDB conexao = LeituraFrmConexaoDB();

                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                // Salva um arquivo Json com os dados da conexão
                conexao.SaveConnectionData(filePath);

                MessageBox.Show("Valores Salvos", "Envio de Ordem de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Erro: {ex.Message}");
                throw;
            }
        }

        private ConexaoDB LeituraFrmConexaoDB()
        {
            try
            {
                // Caso algum dado seja nulo ele retorna uma mensagem
                if (string.IsNullOrEmpty(Txt_Servidor.Text) ||
                    string.IsNullOrEmpty(Txt_IpHost.Text) ||
                    string.IsNullOrEmpty(Txt_DataBase.Text) ||
                    string.IsNullOrEmpty(Txt_Usuario.Text) ||
                    string.IsNullOrEmpty(Txt_Senha.Text))
                {
                    throw new ArgumentException("Todos os campos de conexão são obrigatórios.");
                }

                return new ConexaoDB
                {
                    Servidor = Txt_Servidor.Text,
                    IpHost = Txt_IpHost.Text,
                    DataBase = Txt_DataBase.Text,
                    Usuario = Txt_Usuario.Text,
                    Senha = Txt_Senha.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
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

        private void Btn_TestarConexao_Click(object sender, EventArgs e)
        {

        }

        private void Btn_CriarDB_Click(object sender, EventArgs e)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
                .AddDbContext<IntegradorDBContext>(options =>
                 options.UseSqlServer($"Server={Txt_IpHost.Text};Database={Txt_DataBase.Text};User Id={Txt_Usuario.Text};Password={Txt_Senha.Text}; TrustServerCertificate=True"))
                .BuildServiceProvider();

                using (var context = serviceProvider.GetService<IntegradorDBContext>())
                {
                    MessageBox.Show($"Aplicando migrações...", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Console.WriteLine("Aplicando migrações...");
                    context.Database.Migrate();
                    MessageBox.Show($"Migrações aplicadas com sucesso.", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Console.WriteLine("Migrações aplicadas com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "MigratorDB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
          
        }
    }
}
