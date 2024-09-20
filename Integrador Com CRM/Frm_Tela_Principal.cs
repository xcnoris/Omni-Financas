
using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.DataBase;
using Integrador_Com_CRM.Formularios;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Metodos.Boleto;
using Integrador_Com_CRM.Metodos.OS;
using Integrador_Com_CRM.Models.EF;

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
        private readonly Frm_BoletoAcoesCRM_UC BoletoAcoesCRM;
        private readonly Frm_OSAcoesCRM_UC FrmOSAcao;

        private readonly IntegradorDBContext context;
        private readonly ControleOrdemDeServico ControlOS;
        private readonly ControleBoletos ControlBoleto;
        private readonly CobrancasNaSegundaModel cobrancas;



        public Frm_Tela_Principal()
        {
            InitializeComponent();

            BoletoAcoesCRM = new Frm_BoletoAcoesCRM_UC();
            FrmOSAcao = new Frm_OSAcoesCRM_UC();

            context =new IntegradorDBContext();
            ControlOS = new ControleOrdemDeServico();
            ControlBoleto = new ControleBoletos(BoletoAcoesCRM);

            //Instanciando Variaveis dos Formularios
            FrmDadosAPIUUC = new Frm_DadosAPIUC();
            FrmConexaoUC = new Frm_ConexaoUC();
            cobrancas = new CobrancasNaSegundaModel(BoletoAcoesCRM);

            FrmGeralUC = new Frm_GeralUC(ControlOS, ControlBoleto, FrmDadosAPIUUC, BoletoAcoesCRM);


            AdicionarUserontrols();

            // Timer para executar a função periodicamente a cada 5 minutos
            timer5Min = new System.Timers.Timer(3000000); // 5 min
            timer5Min.Elapsed += async (s, e) =>
            {
                try
                {
                    //await ControlOS.VerificarNovosServicos(FrmDadosAPIUUC);
                
                }
                catch (Exception ex)
                {
                    // Log de erro
                    MetodosGerais.RegistrarLog("OS", $"[ERROR]: {ex.Message}");
                }
            };
            timer5Min.Start();

            // Timer para execulta a função periodica todo dia as 10:30h Brasília
            timerDaily = new System.Timers.Timer();
            timerDaily.Elapsed += async (s, e) =>
            {
                try
                {
                    await ControlBoleto.VerificarNovosBoletos(FrmDadosAPIUUC);
                }
                catch (Exception ex)
                {
                    // Log de erro
                    MetodosGerais.RegistrarLog("Boleto", $"[ERROR]: {ex.Message}");
                }
                // Reconfigurar o timer para o próximo dia às 10:30 AM
                SetDailyTimer();
            };
            SetDailyTimer();

            // Timer para execulta a função periodica toda segunda as 10:45h brasilia
            timerDaily = new System.Timers.Timer();
            timerDaily.Elapsed += async (s, e) =>
            {
                try
                {
                    await cobrancas.RealizarCobrancas(FrmDadosAPIUUC);
                }
                catch (Exception ex)
                {
                    // Log de erro
                    MetodosGerais.RegistrarLog("Boleto", $"[ERROR]: {ex.Message}");
                }
                // Reconfigurar o timer para o próximo dia às 10:30 AM
                SetDailyTimer();
            };
            SetDailyTimerSegunda();
        }


        private void SetDailyTimer()
        {
            DateTime now = DateTime.Now;
            DateTime nextRun = new DateTime(now.Year, now.Month, now.Day, 10, 30, 0, 0);

            if (now > nextRun)
            {
                nextRun = nextRun.AddDays(1);
            }

            double intervalToNextRun = (nextRun - now).TotalMilliseconds;
            timerDaily.Interval = intervalToNextRun;
            timerDaily.Start();
        }

        private void SetDailyTimerSegunda()
        {
            DateTime now = DateTime.Now;

            // Calcula o próximo dia de segunda-feira
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)now.DayOfWeek + 7) % 7;

            // Define o horário de execução na próxima segunda-feira às 10:45 AM
            DateTime nextRun = now.AddDays(daysUntilMonday).Date.AddHours(10).AddMinutes(45);

            // Se já passou do horário de execução hoje, pula para a próxima segunda-feira
            if (now > nextRun)
            {
                nextRun = nextRun.AddDays(7); // Salta para a próxima segunda-feira
            }

            double intervalToNextRun = (nextRun - now).TotalMilliseconds;
            timerDaily.Interval = intervalToNextRun;
            timerDaily.Start();
        }


        private void AdicionarUserontrols()
        {
            FrmGeralUC.Dock = DockStyle.Fill;
            FrmConexaoUC.Dock = DockStyle.Fill;
            BoletoAcoesCRM.Dock = DockStyle.Fill;
            FrmOSAcao.Dock = DockStyle .Fill;

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

            TabPage TB4 = new TabPage
            {
                Name = "Ações Boleto API",
                Text = "Ações Boleto API"
            };
            TB4.Controls.Add(BoletoAcoesCRM);


            TabPage TB5 = new TabPage
            {
                Name = "Ações Ordem de Serviço API",
                Text = "Ações Ordem de Serviço API"
            };
            TB5.Controls.Add(FrmOSAcao);



            TBC_Dados.TabPages.Add(TB1);
            TBC_Dados.TabPages.Add(TB2);
            TBC_Dados.TabPages.Add(TB3);
            TBC_Dados.TabPages.Add(TB4);
            TBC_Dados.TabPages.Add(TB5);
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

        private async void SalvarDados()
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
