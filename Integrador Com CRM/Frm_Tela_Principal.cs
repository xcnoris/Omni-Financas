
using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Integrador_Com_CRM
{
    public partial class Frm_Tela_Principal : Form
    {
        public string Mensagem;

        private System.Timers.Timer timer5Min;
        private System.Timers.Timer timerDaily;

        //Declando Variaveis dos Formularios
        private readonly Frm_GeralUC FrmGeralUC;
        private readonly Frm_ConexaoUC FrmConexaoUC;
        private readonly Frm_DadosAPIUC FrmDadosAPIUUC;

        private readonly IntegradorDBContext context;
        


        public Frm_Tela_Principal()
        {
            InitializeComponent();

            context =new IntegradorDBContext();

            //Instanciando Variaveis dos Formularios
            FrmGeralUC = new Frm_GeralUC(this);
            FrmConexaoUC = new Frm_ConexaoUC();
            FrmDadosAPIUUC = new Frm_DadosAPIUC();

            
            AdicionarUserontrols();
        }

        private void AdicionarUserontrols()
        {
            FrmGeralUC.Dock = DockStyle.Fill;
            FrmConexaoUC.Dock = DockStyle.Fill;

            TabPage TB1 = new TabPage
            {
                Name = "Geral",
                Text = "Geral"
            };
            TB1.Controls.Add(FrmGeralUC);

            TabPage TB2 = new TabPage
            {
                Name = "Conexão",
                Text = "Conexão"
            };
            TB2.Controls.Add(FrmConexaoUC);

            TabPage TB3 = new TabPage
            {
                Name = "Dados API",
                Text = "Dados API"
            };
            TB3.Controls.Add(FrmDadosAPIUUC);





            TBC_Dados.TabPages.Add(TB1);
            TBC_Dados.TabPages.Add(TB2);
            TBC_Dados.TabPages.Add(TB3);

        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            // Minimiza a janela
            this.WindowState = FormWindowState.Minimized;
            MinimizarParaBandeja();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        internal void MinimizarParaBandeja()
        {
            // Verifica se o ponteiro do mouse está na área de trabalho (não na barra de tarefas)
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (MousePointerNotOnTaskBar)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Seu programa está sendo minimizado para a bandeja do Windows";
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task SalvarDados()
        {
            try
            {
                // Instancia as class 
                ConexaoDB conexao = LeituraFrmConexaoDB();
                DadosAPIModels dadosAPI = LeituraFrmDadosAPI();

                DAL<DadosAPIModels> dal = new DAL<DadosAPIModels>(context);
                await dal.AdicionarAsync(dadosAPI);
                //dadosAPI.InserirCodigoInTable();



                // Cria uma string com o caminho e nome do diretorio do arquivo de conexao
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                // Salva um arquivo Json com os dados da conexão
                conexao.SaveConnectionData(filePath);

                MessageBox.Show("Valores Salvos", "Envio de Ordem de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private ConexaoDB LeituraFrmConexaoDB()
        {
            try
            {
                // Caso algum dado seja nulo ele retorna uma mensagem
                if (string.IsNullOrEmpty(FrmConexaoUC.Servidor) ||
                    string.IsNullOrEmpty(FrmConexaoUC.IpHost) ||
                    string.IsNullOrEmpty(FrmConexaoUC.DataBase) ||
                    string.IsNullOrEmpty(FrmConexaoUC.Usuario) ||
                    string.IsNullOrEmpty(FrmConexaoUC.Senha))
                {
                    throw new ArgumentException("Todos os campos de conexão são obrigatórios.");
                }

                return new ConexaoDB
                {
                    Servidor = FrmConexaoUC.Servidor,
                    IpHost = FrmConexaoUC.IpHost,
                    DataBase = FrmConexaoUC.DataBase,
                    Usuario = FrmConexaoUC.Usuario,
                    Senha = FrmConexaoUC.Senha
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Envio de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }

        private DadosAPIModels LeituraFrmDadosAPI()
        {
            try
            {
                // Caso algum dado seja nulo ele retorna uma mensagem
                if (string.IsNullOrEmpty(FrmDadosAPIUUC.Token))
                {
                    throw new ArgumentException("Todos os campos são obrigatórios.");
                }

                return new DadosAPIModels
                {
                    Token = FrmDadosAPIUUC.Token
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Envio de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }
    }
}
