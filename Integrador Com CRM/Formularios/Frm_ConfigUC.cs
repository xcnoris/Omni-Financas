
using CDI_OminiService.Formularios;
using Metodos.IntegradorCRM;
using Metodos.IntegradorCRM.Metodos;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_ConfigUC : UserControl
    {
        internal string Token
        {
            get
            {
                return Txt_Token.Text;
            }
        }

        internal int TxtOSVerificao
        {
            get
            {
                return Convert.ToInt32(Txt_OSTimer.Text);
            }
        }

        internal DateTime DataOSSelect
        {
            get
            {
                return DTP_OSSelect.Value.Date;
            }
        }
        internal bool ChBox_OSEnviarMensCancel
        {
            get
            {
                return ChBox_OSMensCancel.Checked;
            }
        }

        internal DateTime HoraBoletoCobDiaria
        {
            get
            {
                return DTP_BoletoCobDiaria.Value;
            }
        }

        internal DateTime DataBoletoSelect
        {
            get
            {
                return DTP_BoletoSelect.Value.Date;
            }
        }
        internal bool ChBox_BoletoEnviarPDFa
        {
            get
            {
                return ChBox_BoletoEnviarPDF.Checked;
            }
        }
        internal bool ChBox_BoletoEnviarMensCancelamento
        {
            get
            {
                return ChBox_BoletoEnviarMensCancel.Checked;
            }
        }
        internal bool ChBox_BoletoMensFimdeSemana
        {
            get
            {
                return ChBox_BoletoEnviarMensFimdesem.Checked;
            }
        }


        public Frm_ConfigUC()
        {
            InitializeComponent();

            CarregarConfiguracoes();
        }


        internal void SalvarConfiguracoes()
        {
            string caminhoArquivo = "config_timers.txt";
            string conteudo = $"Token|{Txt_Token.Text}\n" +
              $"Txt_OSTimer|{Txt_OSTimer.Text}\n" +
              $"DTP_OSSelect|{DTP_OSSelect.Value.ToString("dd/MM/yyyy")}\n" +
              $"ChBox_OSEnvMensCanc|{ChBox_OSMensCancel.Checked}\n" +
              $"DTP_BoletoCobDiaria|{DTP_BoletoCobDiaria.Value.ToString("HH:mm")}\n" +
              $"DTP_BoletoSelect|{DTP_BoletoSelect.Value.ToString("dd/MM/yyyy")}\n" +
              $"ChBox_BoletoEnviarPDF|{ChBox_BoletoEnviarPDF.Checked}\n" +
              $"ChBox_BoletoMensCanc|{ChBox_BoletoEnviarMensCancel.Checked}\n" +
              $"ChBox_BoletoMensFds|{ChBox_BoletoEnviarMensFimdesem.Checked}";


            File.WriteAllText(caminhoArquivo, conteudo);
            MetodosGerais.RegistrarLog("Config", "Nova configuração definida!");

        }

        private void CarregarConfiguracoes()
        {
            string caminhoArquivo = "config_timers.txt";
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    string[] partes = linha.Split('|');
                    if (partes.Length == 2)
                    {
                        string chave = partes[0];
                        string valor = partes[1];

                        switch (chave)
                        {
                            case "Token":
                                Txt_Token.Text = valor;
                                break;

                            case "Txt_OSTimer":
                                Txt_OSTimer.Text = valor;
                                break;

                            case "DTP_OSSelect":
                                if (DateTime.TryParseExact(valor, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataSelectOS))
                                {
                                    DTP_OSSelect.Value = dataSelectOS;
                                }
                                break;

                            case "ChBox_OSEnvMensCanc":
                                ChBox_OSMensCancel.Checked = Convert.ToBoolean(valor);
                                break;

                            case "DTP_BoletoCobDiaria":
                                if (DateTime.TryParseExact(valor, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime horaDiaria))
                                {
                                    DTP_BoletoCobDiaria.Value = DateTime.Today.Add(horaDiaria.TimeOfDay);
                                }
                                break;
                            case "DTP_BoletoSelect":
                                if (DateTime.TryParseExact(valor, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataSelectBoleto))
                                {
                                    DTP_BoletoSelect.Value = dataSelectBoleto;
                                }
                                break;

                            case "ChBox_BoletoEnviarPDF":
                                ChBox_BoletoEnviarPDF.Checked = Convert.ToBoolean(valor);
                                break;

                            case "ChBox_BoletoMensCanc":
                                ChBox_BoletoEnviarMensCancel.Checked = Convert.ToBoolean(valor);
                                break;

                            case "ChBox_BoletoMensFds":
                                ChBox_BoletoEnviarMensFimdesem.Checked = Convert.ToBoolean(valor);
                                break;
                        }
                    }
                }
            }
            else
            {
                CarregarConfiguracaoBasica();
                MetodosGerais.RegistrarLog("Geral", "Arquivo de Configuração não encontrado, criando configuração padrão...");
                CarregarConfiguracoes();
            }
        }

        private void CarregarConfiguracaoBasica()
        {
            string caminhoArquivo = "config_timers.txt";

            string conteudo = $"Token|\n" +
                              $"Txt_OSTimer|5\n" +
                              $"DTP_OSSelect|{DateTime.Now.ToString("dd/MM/yyyy")}\n" +
                              $"ChBox_OSEnvMensCanc|False\n" +
                              $"DTP_BoletoCobDiaria|10:30\n" +
                              $"DTP_BoletoCobSegunda|10:45\n" +
                              $"DTP_BoletoSelect|{DateTime.Now.ToString("dd/MM/yyyy")}\n" +
                              $"ChBox_BoletoEnviarPDF|False\n" +
                              $"ChBox_BoletoMensCanc|False\n" +
                              $"ChBox_BoletoMensFds|False";

            File.WriteAllText(caminhoArquivo, conteudo);
        }


        private void Txt_TimerOS_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, tecla Backspace e Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloqueia a tecla pressionada
            }
        }

        private void Txt_TimerOS_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(Txt_OSTimer.Text, out int valor))
            {
                if (valor < 5)
                {
                    MessageBox.Show("O valor mínimo permitido para verificação das OS é 5 minutos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_OSTimer.Text = "5"; // Força o valor mínimo
                }
            }
            else
            {
                // Caso o valor não seja um número válido, reseta para 5
                Txt_OSTimer.Text = "5";
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_BuscarMAC_Click(object sender, EventArgs e)
        {
            string MAC = HardwareInfo.GetMacAddress();
            string MACVM = HardwareInfo.GetMacAddressVM();

            Frm_EnderecoMAC frm;
            if (MAC is null)
            {
                frm = new Frm_EnderecoMAC(MACVM);
            }
            else
            {
                frm = new Frm_EnderecoMAC(MAC);

                frm.ShowDialog();
            }
        }

        private void Btn_BuscarMAC_MouseEnter(object sender, EventArgs e)
        {
            Btn_BuscarMAC.BackColor = Color.MediumTurquoise;
        }

        private void Btn_BuscarMAC_MouseLeave(object sender, EventArgs e)
        {
            Btn_BuscarMAC.BackColor = Color.Teal;
        }
    }
}
