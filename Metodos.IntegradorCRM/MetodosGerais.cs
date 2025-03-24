using Newtonsoft.Json;
using NLog;
using System.Reflection.Emit;
using System.Text;

namespace Metodos.IntegradorCRM.Metodos
{
    public class MetodosGerais
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger(); // Configura o NLog

        public static void RegistrarInicioLog(string nomeBaseLog)
        {
            var logEvent = new LogEventInfo(LogLevel.Info, logger.Name, $"======================================> Inicio do Log <======================================");
            logEvent.Properties["NomeLog"] = nomeBaseLog;
            logger.Log(logEvent);
            
        }

        public static void RegistrarLog(string nomeBaseLog, string mensagem)
        {
            string nomeLog = $"{nomeBaseLog}";
            var logEvent = new LogEventInfo(LogLevel.Info, logger.Name, $"{DateTime.Now} - {mensagem}");
            logEvent.Properties["NomeLog"] = nomeLog;
            logger.Log(logEvent);
        }


        public static void RegistrarFinalLog(string nomeBaseLog)
        {
            string nomeLog = $"{nomeBaseLog}";
            var logEvent = new LogEventInfo(LogLevel.Info, logger.Name, $"\n======================================>   Fim do Log  <======================================\n");
            logEvent.Properties["NomeLog"] = nomeLog;
            logger.Log(logEvent);
        }

        public static void RegistrarErroExcecao(string NomeLog, string MensagemLog,Exception ex)
        {
            RegistrarLog($"{NomeLog}", $"{MensagemLog}");
            RegistrarLog($"{NomeLog}", ex.Message);
        }

        public static HttpContent CriarConteudoJson(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}