

namespace Integrador_Com_CRM.Metodos
{
    internal class MetodosGerais
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

        static MetodosGerais()
        {
            // Garantir que o diretório de logs exista
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }

        private static string GetLogFilePath(string logType)
        {
            return Path.Combine(LogDirectory, $"log-{logType}-{DateTime.Now:dd-MM-yyyy}.txt");
        }

        public static void RegistrarInicioLog(string logType)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetLogFilePath(logType), true))
                {
                    string logEntry = $"======================================> Inicio do Log <======================================";
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções relacionadas ao log
                MessageBox.Show($"Erro ao registrar log: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RegistrarLog(string logType, string mensagem)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetLogFilePath(logType), true))
                {
                    string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensagem}";
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções relacionadas ao log
                MessageBox.Show($"Erro ao registrar log: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RegistrarFinalLog(string logType)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetLogFilePath(logType), true))
                {
                    string logEntry = $"\n======================================>   Fim do Log  <======================================\n";
                    sw.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                // Tratar exceções relacionadas ao log
                MessageBox.Show($"Erro ao registrar log: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal static string SelecionarCodAcao(string idCategoria)
        {
            switch (idCategoria)
            {
                case "1":  // AGUARDANDO ANALISE
                    return "610728D401E283FA07FB";

                case "2":   // EM ANALISE
                    return "488A0F6E2D44B5516917";

                case "3":    // COTAÇÃO DE PEÇAS
                    return "99EA5272D06B15DABEC1";

                case "4":   // AGUARDANDO APROVAÇÃO DO CLIENTE
                    return "75B00E055610E6122A8F";

                case "5": // APROVADO PELO CLIENTE
                    return "8C9E3423809C14E52C0B";

                case "6":  //REJEITADO PELO  CLIENTE
                    return "4B9C182C13E7D5FD58FA";

                case "7":  // AGUARDANDO PEÇAS
                    return "FA5DF972949B8A7CFAB3";

                case "8": //AGUARDANDO SUBSTITUIÇÃO DE PEÇA
                    return "DA62CFF0FB010DE83E78";

                case "9": //AGUARDANDO SUBSTITUIÇÃO DE PEÇA
                    return "6133AF81ECA6CBB37D18";

                case "10":  // APROVADO PARA DESCARTE
                    return "88F9B12D58D6950B3C72";

                case "11": // SEM CONSERTO
                    return "75B00E055610E6122A8F";

                case "12":// EM SERVIÇO EXTERNO
                    return "88F9B12D58D6950B3C72";

                case "13": //BUSCAR SERVIÇO EXTERNO
                    return "88F9B12D58D6950B3C72";

                case "14": // ENCERRADA
                    return "88F9B12D58D6950B3C72";

                case "15":  // PRONTA
                    return "B76F652A3AFE943D944E";

                case "16": // DESCARTADA PELO CLIENTE
                    return "88F9B12D58D6950B3C72";

                case "17": // ENVIADO PARA DESCARTE
                    return "40F70529EC12C876748B";

                default:
                    MetodosGerais.RegistrarLog("OS", "Número inválido. Por favor, escolha um número de 1 a 5.");
                    return null;
            }
        }

        internal static string SelecionarMensagemAtualizacao(string idCategoria)
        {
            switch (idCategoria)
            {
                case "1":  // AGUARDANDO ANALISE
                    return "OS ENTROU NA ETAPA AGUARDANDO ANALISE";

                case "2":   // EM ANALISE
                    return "OS ENTROU NA ETAPA EM ANALISE";

                case "3":    // COTAÇÃO DE PEÇAS
                    return "OS ENTROU NA ETAPA COTAÇÃO DE PEÇAS";

                case "4":   // AGUARDANDO APROVAÇÃO DO CLIENTE
                    return "OS ENTROU NA ETAPA AGUARDANDO APROVAÇÃO DO CLIENTE";

                case "5": // APROVADO PELO CLIENTE
                    return "OS ENTROU NA ETAPA APROVADO PELO CLIENTE";

                case "6":  //REJEITADO PELO  CLIENTE
                    return "OS ENTROU NA ETAPA REJEITADO PELO  CLIENTE";

                case "7":  // AGUARDANDO PEÇAS
                    return "OS ENTROU NA ETAPA AGUARDANDO PEÇAS";

                case "8": //AGUARDANDO SUBSTITUIÇÃO DE PEÇA
                    return "OS ENTROU NA ETAPA AGUARDANDO SUBSTITUIÇÃO DE PEÇA";

                case "9": //AGUARDANDO SUBSTITUIÇÃO DE PEÇA
                    return "OS ENTROU NA ETAPA AGUARDANDO LIBERAÇÃO";

                case "10":  // APROVADO PARA DESCARTE
                    return "OS ENTROU NA ETAPA APROVADA PARA DESCARTE";

                case "11": // SEM CONSERTO
                    return "OS ENTROU NA ETAPA SEM CONSERTO";

                case "12":// EM SERVIÇO EXTERNO
                    return "OS ENTROU NA ETAPA EM SERVIÇO EXTERNO";

                case "13": //BUSCAR SERVIÇO EXTERNO
                    return "OS ENTROU NA ETAPA BUSCAR SERVIÇO EXTERNO";

                case "14": // ENCERRADA
                    return "OS ENTROU NA ETAPA ENCERRADA";

                case "15":  // PRONTA
                    return "OS ENTROU NA ETAPA PRONTA";

                case "16": // DESCARTADA PELO CLIENTE
                    return "OS ENTROU NA ETAPA DESCARTADA PELO CLIENTE";

                case "17": // ENVIADO PARA DESCARTE
                    return "OS ENTROU NA ETAPA ENVIADO PARA DESCARTE";

                default:
                    MetodosGerais.RegistrarLog("OS", "Número inválido. Por favor, escolha um número de 1 a 5.");
                    return null;
            }
        }
    }
}
