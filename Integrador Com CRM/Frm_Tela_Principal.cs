using Aplication.IntegradorCRM.Metodos.Boleto;
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using DataBase.IntegradorCRM.Data.DataBase;
using Integrador_Com_CRM.Formularios;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Metodos.IntegradorCRM;
using CDI_OminiService.Formularios;

namespace Integrador_Com_CRM
{
    public partial class Frm_Tela_Principal : Form
    {
        public string Mensagem;

        private System.Timers.Timer timer5Min;
        private System.Timers.Timer timerDaily;

        //Declando Variaveis dos Formularios
        private readonly Frm_GeralUC FrmGeralUC;
        private readonly Frm_BoletoAcoesCRM_UC BoletoAcoesCRM;
        private readonly FrmEtapaBoletoUC EtapasBoletos;
        private readonly Frm_OSAcoesCRM_UC FrmOSAcao;
        private readonly Frm_AcoesSituacoes FrmAcoesSit;
        private readonly Frm_ConexaoUC FrmConexaoUC;
        private readonly Frm_DadosAPIUC FrmDadosAPIUUC;
        private readonly Frm_ConfigUC FrmConfigUC;
        private readonly FrmConfigEmail frmConfigEmail;

        ControleOrdemDeServico ControlOS;
        private readonly DAL<DadosAPIModels> _dalDadosAPI;
        ControleBoletos ControlBoleto;

   

        public Frm_Tela_Principal()
        {
            InitializeComponent();

            FrmConfigUC = new Frm_ConfigUC();

            // Obter o MAC local
            string macAddress = HardwareInfo.GetMacAddress();
            string macAddressVM = HardwareInfo.GetMacAddressVM();

            // Obter o token fornecido pelo cliente
            string token = FrmConfigUC.Token;

            _dalDadosAPI = new DAL<DadosAPIModels>(new IntegradorDBContext());
            List<DadosAPIModels?> DadosAPI = (_dalDadosAPI.Listar()).ToList();


            BoletoAcoesCRM = new Frm_BoletoAcoesCRM_UC();
            FrmOSAcao = new Frm_OSAcoesCRM_UC();
            FrmAcoesSit = new Frm_AcoesSituacoes();
            frmConfigEmail = new FrmConfigEmail();


            ControlOS = new ControleOrdemDeServico();
            ControlBoleto = new ControleBoletos();

            //Instanciando Variaveis dos Formularios
            FrmDadosAPIUUC = new Frm_DadosAPIUC();
            FrmConexaoUC = new Frm_ConexaoUC();
            EtapasBoletos = new FrmEtapaBoletoUC();

            FrmGeralUC = new Frm_GeralUC(ControlOS, ControlBoleto, BoletoAcoesCRM, FrmConfigUC, frmConfigEmail);


            AdicionarUserontrols();

            // Validar o token
            if (!LicenseManager.ValidateToken(token, macAddress, macAddressVM))
            {
                if (!(string.IsNullOrEmpty(FrmConfigUC.Token)))
                {
                    FrmGeralUC.EnviarEmail(macAddress, token);
                    MetodosGerais.RegistrarLog("Geral", "Licença inválida. Entre em contato com o suporte.");
                    MessageBox.Show("Licença inválida. Entre em contato com o suporte.", "Erro de Licença",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {


                //Timer para executar a função periodicamente a cada 5 minutos
                timer5Min = new System.Timers.Timer(FrmConfigUC.TxtOSVerificao * 60000); // 5 min
                timer5Min.Elapsed += async (s, e) =>
                {
                    try
                    {
                        //await FrmGeralUC.VerificarOrdensDeServicos(FrmConfigUC);

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
                        //await FrmGeralUC.VerificarBoletos(FrmConfigUC, InstanciarConfigEmail(frmConfigEmail));
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
            }
        }


        private ConfigEmail InstanciarConfigEmail(FrmConfigEmail Frm)
        {
            return new ConfigEmail()
            {
                SMTP_Server = Frm.Server,
                SMTP_Port = Convert.ToInt32(Frm.Port),
                Email = Frm.Email,
                Senha = Frm.Senha
            };
        }

        private void SetDailyTimer()
        {
            DateTime now = DateTime.Now;

            // Pega o horário do campo HoraCobDiariaBoleto (ajuste conforme necessário)
            DateTime selectedTime = FrmConfigUC.HoraBoletoCobDiaria;

            // Define o próximo horário de execução para hoje, usando o horário do campo
            DateTime nextRun = new DateTime(now.Year, now.Month, now.Day, selectedTime.Hour, selectedTime.Minute, 0);

            // Se já passou do horário de execução hoje, agenda para amanhã
            if (now > nextRun)
            {
                nextRun = nextRun.AddDays(1);
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
            FrmOSAcao.Dock = DockStyle.Fill;
            FrmAcoesSit.Dock = DockStyle.Fill;
            FrmConfigUC.Dock = DockStyle.Fill;
            EtapasBoletos.Dock = DockStyle.Fill;
            frmConfigEmail.Dock = DockStyle.Fill;


            TabPage Geral = new TabPage
            {
                Name = "geral",
                Text = "Geral"
            };
            Geral.Controls.Add(FrmGeralUC);

            TabPage Conexao = new TabPage
            {
                Name = "Conexão",
                Text = "Conexão"
            };
            Conexao.Controls.Add(FrmConexaoUC);

            TabPage DadosAPi = new TabPage
            {
                Name = "Dados API",
                Text = "Dados API"
            };
            DadosAPi.Controls.Add(FrmDadosAPIUUC);

            TabPage AcoesBoleto = new TabPage
            {
                Name = "Ações Boleto",
                Text = "Ações Boleto"
            };
            AcoesBoleto.Controls.Add(BoletoAcoesCRM);


            TabPage AcoesOS = new TabPage
            {
                Name = "Ações Ordem de Serviço",
                Text = "Ações Ordem de Serviço"
            };
            AcoesOS.Controls.Add(FrmOSAcao);

            TabPage AcoesSituaccoes = new TabPage
            {
                Name = "Ações Situações",
                Text = "Ações Situações"
            };
            AcoesSituaccoes.Controls.Add(FrmAcoesSit);

            TabPage ConfiguracaoGeral = new TabPage
            {
                Name = "Configuração",
                Text = "Configuração"
            };
            ConfiguracaoGeral.Controls.Add(FrmConfigUC);

            TabPage EtapasBoleto = new TabPage
            {
                Name = "Etapas Boleto",
                Text = "Etapas Boleto"
            };
            EtapasBoleto.Controls.Add(EtapasBoletos);

            TabPage Config_Email = new TabPage
            {
                Name = "Config Email",
                Text = "Config Emai"
            };
            Config_Email.Controls.Add(frmConfigEmail);

            TBC_Dados.TabPages.Add(Geral);
            TBC_Dados.TabPages.Add(AcoesBoleto);
            TBC_Dados.TabPages.Add(EtapasBoleto);
            TBC_Dados.TabPages.Add(AcoesOS);
            TBC_Dados.TabPages.Add(AcoesSituaccoes);
            TBC_Dados.TabPages.Add(Conexao);
            TBC_Dados.TabPages.Add(DadosAPi);
            TBC_Dados.TabPages.Add(Config_Email);
            TBC_Dados.TabPages.Add(ConfiguracaoGeral);
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
                //notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Seu programa está sendo minimizado para a bandeja do Windows";
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }



        private async void SalvarDados()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                // Instancia as class 
                ConexaoDB conexao = LeituraFrmConexaoDB();
                DadosAPIModels dadosAPI = LeituraFrmDadosAPI();
                ConfigEmail configEmail = LeituraFrmConfigEmail();

                List<AcaoSituacao_Boleto> AcoesSitBoleto = new List<AcaoSituacao_Boleto>();
                List<AcaoSituacao_OS> AcoesSitOS = new List<AcaoSituacao_OS>();
                if (conexao is not null && dadosAPI is not null)
                {
                }

                FrmConfigUC.SalvarConfiguracoes();
                SalvarArquivoConexao(conexao);

                if (FrmConexaoUC.TestarConexaoDB(false))
                {
                    if (conexao is not null)
                    {
                        await CriarAtualDadosAPI(dadosAPI);
                        await SalvarSitBoleto(AcoesSitBoleto);
                        await SalvarSitOS(AcoesSitOS);
                        await CriarAtualConfigEmail(configEmail);
                        MessageBox.Show("Valores Salvos", "Envio de Ordem de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Valores de configurações não serão salvos enquanto uma conexão valida com o banco de dados não for definida!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SalvarArquivoConexao(ConexaoDB conexao)
        {
            // Cria uma string com o caminho e nome do diretorio do arquivo de conexao
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(basePath, "conexao.json");

            // Salva um arquivo Json com os dados da conexão
            if (conexao is not null) conexao.SaveConnectionData(filePath);
        }


        private async Task SalvarSitBoleto(List<AcaoSituacao_Boleto> AcoesSitBoleto)
        {
            DAL<AcaoSituacao_Boleto> dalAcaoSItBol = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            foreach (var item in AcoesSitBoleto)
            {
                await dalAcaoSItBol.AtualizarAsync(item);
            }
        }

        private async Task SalvarSitOS(List<AcaoSituacao_OS> AcoesSitOS)
        {
            DAL<AcaoSituacao_OS> dalSitOS = new DAL<AcaoSituacao_OS>(new IntegradorDBContext());
            foreach (var item in AcoesSitOS)
            {
                await dalSitOS.AtualizarAsync(item);
            }
        }

        private async Task CriarAtualDadosAPI(DadosAPIModels dadosAPI)
        {
            using DAL<DadosAPIModels> dal = new DAL<DadosAPIModels>(new IntegradorDBContext());
            List<DadosAPIModels> ListDadosAPI = (await dal.ListarAsync()).ToList();

            if (ListDadosAPI.Count == 0)
            {
                // Se não existir nenhum dado, adiciona o novo
                await dal.AdicionarAsync(dadosAPI);
            }
            else
            {
                // Atualiza apenas o primeiro dado da lista
                DadosAPIModels primeiroDado = ListDadosAPI.First();
                primeiroDado.Token = dadosAPI.Token;
                primeiroDado.Instancia = dadosAPI.Instancia;

                // Atualiza o dado existente no banco
                await dal.AtualizarAsync(primeiroDado);
            }
        }

        private async Task CriarAtualConfigEmail(ConfigEmail configEmail)
        {
            using DAL<ConfigEmail> dal = new DAL<ConfigEmail>(new IntegradorDBContext());
            List<ConfigEmail> ListConfigEmail = (await dal.ListarAsync()).ToList();

            if (ListConfigEmail.Count == 0)
            {
                // Se não existir nenhum dado, adiciona o novo
                await dal.AdicionarAsync(configEmail);
            }
            else
            {
                // Atualiza apenas o primeiro dado da lista
                ConfigEmail primeiroDado = ListConfigEmail.First();
                primeiroDado.SMTP_Server = configEmail.SMTP_Server;
                primeiroDado.SMTP_Port = configEmail.SMTP_Port;
                primeiroDado.Email = configEmail.Email;
                primeiroDado.Senha = configEmail.Senha;

                // Atualiza o dado existente no banco
                await dal.AtualizarAsync(primeiroDado);
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
                    return null;
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

                return new DadosAPIModels
                {
                    Token = FrmDadosAPIUUC.Token,
                    Instancia = FrmDadosAPIUUC.Nome_Instancia
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Envio de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }

        private ConfigEmail LeituraFrmConfigEmail()
        {
            try
            {

                return new ConfigEmail
                {
                    SMTP_Server = frmConfigEmail.Server,
                    SMTP_Port = Convert.ToInt32(frmConfigEmail.Port),
                    Email = frmConfigEmail.Email,
                    Senha = frmConfigEmail.Senha
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Envio de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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

        // Design
        private void btnFechar_Click(object sender, EventArgs e)
        {
            // Minimiza a janela
            this.WindowState = FormWindowState.Minimized;
            MinimizarParaBandeja();
        }

        private void btnSalvar_MouseEnter(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.MediumTurquoise;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            btnSalvar.BackColor = Color.Teal;
        }

        private void btnFechar_MouseEnter(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.MediumTurquoise;
        }

        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.Teal;
        }
    }
}
