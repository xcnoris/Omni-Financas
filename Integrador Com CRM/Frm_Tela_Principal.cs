using Aplication.IntegradorCRM.Metodos.Boleto;
using Aplication.IntegradorCRM.Metodos.OS;
using DataBase.IntegradorCRM.Data;
using DataBase.IntegradorCRM.Data.DataBase;
using Integrador_Com_CRM.Formularios;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Metodos.IntegradorCRM;

namespace Integrador_Com_CRM
{
    public partial class Frm_Tela_Principal : Form
    {
        public string Mensagem;

        private System.Timers.Timer timer5Min;
        private System.Timers.Timer timerDaily;
        private System.Timers.Timer timerMonday;

        //Declando Variaveis dos Formularios
        private readonly Frm_GeralUC FrmGeralUC;
        private readonly Frm_ConexaoUC FrmConexaoUC;
        private readonly Frm_DadosAPIUC FrmDadosAPIUUC;
        private readonly Frm_BoletoAcoesCRM_UC BoletoAcoesCRM;
        private readonly Frm_OSAcoesCRM_UC FrmOSAcao;
        private readonly Frm_AcoesSituacoes FrmAcoesSit;
        private readonly Frm_ConfigUC FrmConfigUC;

        ControleOrdemDeServico ControlOS;
        private readonly DAL<DadosAPIModels> _dalDadosAPI;
        private readonly IntegradorDBContext context;
        private readonly CobrancasNaSegundaModel cobrancas;
        ControleBoletos ControlBoleto;

        DAL<OSAcoesCRMModel> dalOSACoes = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());
        List<OSAcoesCRMModel> modelList;

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

            context = new IntegradorDBContext();

            ControlOS = new ControleOrdemDeServico();
            ControlBoleto = new ControleBoletos();

            //Instanciando Variaveis dos Formularios
            FrmDadosAPIUUC = new Frm_DadosAPIUC();
            FrmConexaoUC = new Frm_ConexaoUC();
            cobrancas = new CobrancasNaSegundaModel();

            FrmGeralUC = new Frm_GeralUC(ControlOS, ControlBoleto, BoletoAcoesCRM, FrmConfigUC);


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


                // Timer para executar a função periodicamente a cada 5 minutos
                //timer5Min = new System.Timers.Timer(FrmConfigUC.TxtVerificaoOS * 60000); // 5 min
                //timer5Min.Elapsed += async (s, e) =>
                //{
                //    try
                //    {
                //        await FrmGeralUC.VerificarOrdensDeServicos(FrmConfigUC);

                //    }
                //    catch (Exception ex)
                //    {
                //        // Log de erro
                //        MetodosGerais.RegistrarLog("OS", $"[ERROR]: {ex.Message}");
                //    }
                //};
                //timer5Min.Start();

                // Timer para execulta a função periodica todo dia as 10:30h Brasília
                timerDaily = new System.Timers.Timer();
                timerDaily.Elapsed += async (s, e) =>
                {
                    try
                    {
                        await FrmGeralUC.VerificarBoletos(FrmConfigUC);
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
                timerMonday = new System.Timers.Timer();
                timerMonday.Elapsed += async (s, e) =>
                {
                    try
                    {
                        await FrmGeralUC.VerificarCobrancas(FrmConfigUC);
                    }
                    catch (Exception ex)
                    {
                        // Log de erro
                        MetodosGerais.RegistrarLog("Boleto", $"[ERROR]: {ex.Message}");
                    }
                    // Reconfigurar o timer para a próxima segunda às 10:30 AM
                    SetDailyTimerSegunda();
                };
                SetDailyTimerSegunda();
            }
        }




        private void SetDailyTimer()
        {
            DateTime now = DateTime.Now;

            // Pega o horário do campo HoraCobDiariaBoleto (ajuste conforme necessário)
            DateTime selectedTime = FrmConfigUC.HoraCobDiariaBoleto;

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




        private void SetDailyTimerSegunda()
        {
            DateTime now = DateTime.Now;

            // Calcula o próximo dia de segunda-feira
            int daysUntilMonday = ((int)DayOfWeek.Monday - (int)now.DayOfWeek + 7) % 7;

            // Pega o horário do campo DTP_CobSegundaBoleto (ajuste conforme necessário)
            DateTime selectedTime = FrmConfigUC.HoraCobSegundaBoleto;

            // Define o horário de execução na próxima segunda-feira, usando o horário do campo
            DateTime nextRun = now.AddDays(daysUntilMonday).Date.AddHours(selectedTime.Hour).AddMinutes(selectedTime.Minute);

            // Se já passou do horário de execução hoje, pula para a próxima segunda-feira
            if (now > nextRun)
            {
                nextRun = nextRun.AddDays(7); // Salta para a próxima segunda-feira
            }

            double intervalToNextRun = (nextRun - now).TotalMilliseconds;
            timerMonday.Interval = intervalToNextRun;
            timerMonday.Start();
        }



        private void AdicionarUserontrols()
        {
            FrmGeralUC.Dock = DockStyle.Fill;
            FrmConexaoUC.Dock = DockStyle.Fill;
            BoletoAcoesCRM.Dock = DockStyle.Fill;
            FrmOSAcao.Dock = DockStyle.Fill;
            FrmAcoesSit.Dock = DockStyle.Fill;
            FrmConfigUC.Dock = DockStyle.Fill;

            TabPage TB1 = new TabPage
            {
                Name = "geral",
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

            TabPage TB6 = new TabPage
            {
                Name = "Ações Situações",
                Text = "Ações Situações"
            };
            TB6.Controls.Add(FrmAcoesSit);

            TabPage TB7 = new TabPage
            {
                Name = "Configuração",
                Text = "Configuração"
            };
            TB7.Controls.Add(FrmConfigUC);


            TBC_Dados.TabPages.Add(TB1);
            TBC_Dados.TabPages.Add(TB2);
            TBC_Dados.TabPages.Add(TB3);
            TBC_Dados.TabPages.Add(TB4);
            TBC_Dados.TabPages.Add(TB5);
            TBC_Dados.TabPages.Add(TB6);
            TBC_Dados.TabPages.Add(TB7);
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
                // Instancia as class 
                ConexaoDB conexao = LeituraFrmConexaoDB();
                DadosAPIModels dadosAPI = LeituraFrmDadosAPI();

                List<AcaoSituacao_Boleto_CRM> AcoesSitBoleto = new List<AcaoSituacao_Boleto_CRM>();
                List<AcaoSituacao_OS_CRM> AcoesSitOS = new List<AcaoSituacao_OS_CRM>();
                if (conexao is not null && dadosAPI is not null)
                {
                    AcoesSitBoleto = FrmAcoesSit.RetornarListAcoesSitBoleto();

                    AcoesSitOS = FrmAcoesSit.RetornarListAcoesSitOS();
                }

                FrmConfigUC.SalvarConfiguracoes();

                if (conexao is not null)
                {
                    await CriarAtualDadosAPI(dadosAPI);
                    await SalvarSitBoleto(AcoesSitBoleto);
                    await SalvarSitOS(AcoesSitOS);
                }
                // Cria uma string com o caminho e nome do diretorio do arquivo de conexao
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(basePath, "conexao.json");

                // Salva um arquivo Json com os dados da conexão
                if (conexao is not null) conexao.SaveConnectionData(filePath);

                MessageBox.Show("Valores Salvos", "Envio de Ordem de Serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task SalvarSitBoleto(List<AcaoSituacao_Boleto_CRM> AcoesSitBoleto)
        {
            DAL<AcaoSituacao_Boleto_CRM> dalAcaoSItBol = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());
            foreach (var item in AcoesSitBoleto)
            {
                await dalAcaoSItBol.AtualizarAsync(item);
            }
        }

        private async Task SalvarSitOS(List<AcaoSituacao_OS_CRM> AcoesSitOS)
        {
            DAL<AcaoSituacao_OS_CRM> dalSitOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
            foreach (var item in AcoesSitOS)
            {
                await dalSitOS.AtualizarAsync(item);
            }
        }

        private async Task CriarAtualDadosAPI(DadosAPIModels dadosAPI)
        {
            DAL<DadosAPIModels> dal = new DAL<DadosAPIModels>(new IntegradorDBContext());
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
                primeiroDado.Cod_API_OrdemServico = dadosAPI.Cod_API_OrdemServico;
                primeiroDado.Cod_Jornada_OrdemServico = dadosAPI.Cod_Jornada_OrdemServico;
                primeiroDado.Cod_API_Boleto = dadosAPI.Cod_API_Boleto;
                primeiroDado.Cod_Jornada_Boleto = dadosAPI.Cod_Jornada_Boleto;
                primeiroDado.CodAPI_EnvioPDF = dadosAPI.CodAPI_EnvioPDF;

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
                    Cod_API_OrdemServico = FrmDadosAPIUUC.CodAPI_OS,
                    Cod_Jornada_OrdemServico = FrmDadosAPIUUC.CodJornada_OS,
                    Cod_API_Boleto = FrmDadosAPIUUC.CodAPI_Boleto,
                    Cod_Jornada_Boleto = FrmDadosAPIUUC.CodJornada_Boleto,
                    CodAPI_EnvioPDF = FrmDadosAPIUUC.CodAPI_EnvioPDF
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Envio de OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("OS", $"Erro: {ex.Message}");
                throw;
            }
        }

        private void botaoArredond2_Click(object sender, EventArgs e)
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

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            // Minimiza a janela
            this.WindowState = FormWindowState.Minimized;
            MinimizarParaBandeja();
        }
    }
}
