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

        internal int TxtVerificaoOS
        {
            get
            {
                return Convert.ToInt32(Txt_TimerOS.Text);
            }
        }

        internal DateTime DataSelectOS
        {
            get
            {
                return DTP_SelectOS.Value.Date;
            }
        }

        internal DateTime HoraCobDiariaBoleto
        {
            get
            {
                return DTP_CobDiariaBoleto.Value;
            }
        }

        internal DateTime HoraCobSegundaBoleto
        {
            get
            {
                return DTP_CobSegundaBoleto.Value;
            }
        }

        internal DateTime DataSelectBoleto
        {
            get
            {
                return DTP_SelectBoleto.Value.Date;
            }
        }
        internal bool ChBox_EnviarPDFa
        {
            get
            {
                return ChBox_EnviarPDF.Checked;
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
              $"Txt_TimerOS|{Txt_TimerOS.Text}\n" +
              $"DTP_SelectOS|{DTP_SelectOS.Value.ToString("dd/MM/yyyy")}\n" +
              $"DTP_CobDiariaBoleto|{DTP_CobDiariaBoleto.Value.ToString("HH:mm")}\n" +
              $"DTP_CobSegundaBoleto|{DTP_CobSegundaBoleto.Value.ToString("HH:mm")}\n" +
              $"DTP_SelectBoleto|{DTP_SelectBoleto.Value.ToString("dd/MM/yyyy")}\n" +
              $"ChBox_EnviarPDF|{ChBox_EnviarPDF.Checked}";


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

                            case "Txt_TimerOS":
                                Txt_TimerOS.Text = valor;
                                break;

                            case "DTP_SelectOS":
                                if (DateTime.TryParseExact(valor, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataSelectOS))
                                {
                                    DTP_SelectOS.Value = dataSelectOS;
                                }
                                break;

                            case "DTP_CobDiariaBoleto":
                                if (DateTime.TryParseExact(valor, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime horaDiaria))
                                {
                                    DTP_CobDiariaBoleto.Value = DateTime.Today.Add(horaDiaria.TimeOfDay);
                                }
                                break;

                            case "DTP_CobSegundaBoleto":
                                if (DateTime.TryParseExact(valor, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime horaSegunda))
                                {
                                    DTP_CobSegundaBoleto.Value = DateTime.Today.Add(horaSegunda.TimeOfDay);
                                }
                                break;

                            case "DTP_SelectBoleto":
                                if (DateTime.TryParseExact(valor, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataSelectBoleto))
                                {
                                    DTP_SelectBoleto.Value = dataSelectBoleto;
                                }
                                break;

                            case "ChBox_EnviarPDF":
                                ChBox_EnviarPDF.Checked = Convert.ToBoolean(valor);
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
                   $"Txt_TimerOS|5\n" +
                   $"DTP_SelectOS|{DateTime.Now.ToString("dd/MM/yyyy")}\n" +
                   $"DTP_CobDiariaBoleto|10:30\n" +
                   $"DTP_CobSegundaBoleto|10:45\n" +
                   $"DTP_SelectBoleto|{DateTime.Now.ToString("dd/MM/yyyy")}\n" +
                   $"ChBox_EnviarPDF|False";

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
            if (int.TryParse(Txt_TimerOS.Text, out int valor))
            {
                if (valor < 5)
                {
                    MessageBox.Show("O valor mínimo permitido para verificação das OS é 5 minutos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt_TimerOS.Text = "5"; // Força o valor mínimo
                }
            }
            else
            {
                // Caso o valor não seja um número válido, reseta para 5
                Txt_TimerOS.Text = "5";
            }
        }
    }
}
