
using Aplication.IntegradorCRM.Metodos.Boleto;
using Aplication.IntegradorCRM.Metodos.OS;
using Aplication.IntegradorCRM.Servicos.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Metodos.IntegradorCRM;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM;
using Aplication.IntegradorCRM.Metodos.Envio__Email;
using System.Net;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_GeralUC : UserControl
    {
        private readonly ControleComissoes controlOrdemServico;
        private readonly ControleBoletos controlBoletos;
        private readonly CobrancasNaSegundaModel cobrancas;
        private readonly DadosAPIModels? DadosAPI;
        private readonly DAL<AcaoSituacao_Boleto_CRM> _dalAcaoSitBoleto;
        private readonly DAL<DadosAPIModels> _dalDadosAPI;
        private readonly Frm_BoletoAcoesCRM_UC BoletoAcoes;
        DAL<BoletoAcoesCRMModel> _dalBoletoAcoes;
        private readonly Frm_ConfigUC FrmConfigUC;
        public Frm_GeralUC(ControleComissoes controlOS, ControleBoletos controleBoletos, Frm_BoletoAcoesCRM_UC BoletosAcoes, Frm_ConfigUC FrmConfig)
        {
            InitializeComponent();

            controlOrdemServico = controlOS;
            BoletoAcoes = BoletosAcoes;
            _dalBoletoAcoes = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());
            _dalAcaoSitBoleto = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());
            _dalDadosAPI = new DAL<DadosAPIModels>(new IntegradorDBContext());
            controlBoletos = new ControleBoletos();
            cobrancas = new CobrancasNaSegundaModel();
            DadosAPI = (_dalDadosAPI.Listar()).FirstOrDefault();
            FrmConfigUC = FrmConfig;
        }

        private bool verificarLicenca(Frm_ConfigUC FrmConfigUC)
        {
            // Obter o MAC local
            string macAddress = HardwareInfo.GetMacAddress();
            string macAddressVM = HardwareInfo.GetMacAddressVM();

            // Obter o token fornecido pelo cliente
            string token = FrmConfigUC.Token;

            if (!LicenseManager.ValidateToken(token, macAddress, macAddressVM))
            {
                MessageBox.Show("Licença inválida. Entre em contato com o suporte.", "Erro de Licença",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                MetodosGerais.RegistrarLog("Geral", $"Licença inválida. Entre em contato com o suporte. Token = {token} | MAC: {macAddress}");
                EnviarEmail(macAddress, token);
                return false;
            }
            return true;
        }

        public async Task EnviarEmail(string macAddress, string token)
        {
            // Obter endereço IP local
            string localIpAddress = ObterEnderecoIpLocal();
            string hostname = Dns.GetHostName();
            string sistemaOperacional = Environment.OSVersion.ToString();
            string usuarioLogado = Environment.UserName;
            string ipExterno;
            using (HttpClient client = new HttpClient())
            {
               ipExterno = await client.GetStringAsync("https://api.ipify.org");
            }

            var emailRequest = new EmailRequest
            {
                TextoEmail = @$"Data: {DateTime.Now} - Verificação de Token inválida! 
                        Mac: {macAddress} - 
                        Token: {token} - 
                        IP: {localIpAddress} -
                        Host: {hostname}
                        Sistema Operacional - {sistemaOperacional}
                        Usuario Logado: {usuarioLogado}
                        IP Externo: {ipExterno}",
                TituloEmail = "Validação de Token Inválida",
                Destinatarios = new List<Destinatario>
                {
                    new Destinatario
                    {
                        NomeDestinatario = "CDI Software",
                        EmailDestinatario = "casainfosc@gmail.com"
                    }
                }
            };

            string tokenCDI = "F65F9082EE9DB13A464B5DC0A9F2B8D56840CA3A1178826B0DF17DA2CE7DD621";

            bool enviadoComSucesso = await EnvioEmail.EnviarEmail(emailRequest, tokenCDI);

        }

        // Método para obter o endereço IP local
        private string ObterEnderecoIpLocal()
        {
            try
            {
                // Obter todos os endereços IP associados ao host
                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ip = host.AddressList.FirstOrDefault(a => a.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

                return ip?.ToString() ?? "IP não encontrado";
            }
            catch (Exception ex)
            {
                // Logar ou tratar exceção, se necessário
                Console.WriteLine("Erro ao obter o IP local: " + ex.Message);
                return "Erro ao obter IP";
            }
        }

        public async Task ExecutarBuscaOSAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                MetodosGerais.RegistrarLog("OS", $"\n---------- Ordens de serviço consultadas manualmente ------------\n");

                bool deucerto = await VerificarOrdensDeServicos(FrmConfigUC);

                if (deucerto) MessageBox.Show("Consulta de Ordem de Serviço Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("OS", $"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async Task<bool> VerificarOrdensDeServicos(Frm_ConfigUC FrmConfigUC)
        {
            if (verificarLicenca(FrmConfigUC))
            {
                await controlOrdemServico.VerificarNovosServicos(DadosAPI, FrmConfigUC.DataSelectOS);
                return true;
            }
            return false;
        }

        public async Task<bool> VerificarBoletos(Frm_ConfigUC FrmConfigUC)
        {
          
            if (verificarLicenca(FrmConfigUC))
            {
                List<AcaoSituacao_Boleto_CRM> AcoesSituacaoBoleto = (await _dalAcaoSitBoleto.ListarAsync()).ToList();
                List<BoletoAcoesCRMModel> BoletoAcoesCRM = (await _dalBoletoAcoes.ListarAsync()).ToList();

                await controlBoletos.VerificarNovosBoletos(DadosAPI, AcoesSituacaoBoleto, BoletoAcoesCRM, FrmConfigUC.DataSelectBoleto, FrmConfigUC.ChBox_EnviarPDFa);
                return true;
            }
            return false;
        }
        public async Task<bool> VerificarCobrancas(Frm_ConfigUC FrmConfigUC)
        {
            if (verificarLicenca(FrmConfigUC))
            {
                List<BoletoAcoesCRMModel?> acoesCobrancaList = (await _dalBoletoAcoes.ListarAsync()).ToList();
                List<DadosAPIModels?> DadosAPI = (await _dalDadosAPI.ListarAsync()).ToList();
                CobrancaServicos CB = new CobrancaServicos();
                await CB.RealizarCobrancas(acoesCobrancaList, DadosAPI.First());
                return true;
            }
            return false;
        }


        public async Task ExecutarBuscarBoletoAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                MetodosGerais.RegistrarLog("BOLETO", $"\n----------------> Boletos consultados manualmente <-----------------\n");

                bool deucerto = await VerificarBoletos(FrmConfigUC);
                if (deucerto) MessageBox.Show("Consulta de Boletos Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("BOLETO", $"Error :{ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async Task RealizarCobrancasBoletoAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                MetodosGerais.RegistrarLog("COBRANCA", $"\n------------------> Cobrança consultadas manualmente <-------------------\n");

                bool deucerto = await VerificarCobrancas(FrmConfigUC);

                if (deucerto)  MessageBox.Show("Cobranças de Boletos Efetuada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possivel fazer a consulta. Mensagem: {ex.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MetodosGerais.RegistrarLog("COBRANCA", $"Error :{ex.Message}");
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("COBRANCA");
                Cursor = Cursors.Default;
            }
        }

        private async void Btn_BuscarOS_Click(object sender, EventArgs e)
        {
            await ExecutarBuscaOSAsync();
        }

        private async void Btn_BuscarBoletos_Click(object sender, EventArgs e)
        {
            await ExecutarBuscarBoletoAsync();
        }

        private async void Btn_RealizarCobrancas_Click(object sender, EventArgs e)
        {
            await RealizarCobrancasBoletoAsync();
        }
    }
}
