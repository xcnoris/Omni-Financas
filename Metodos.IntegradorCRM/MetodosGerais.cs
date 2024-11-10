using NLog;

namespace Metodos.IntegradorCRM.Metodos
{
    public class MetodosGerais
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger(); // Configura o NLog

        public static void RegistrarInicioLog(string logType)
        {
            logger.Info($"======================================> Inicio do Log <======================================");
        }

        public static void RegistrarLog(string logType, string mensagem)
        {
            logger.Info(mensagem);
        }

        public static void RegistrarFinalLog(string logType)
        {
            logger.Info($"\n======================================>   Fim do Log  <======================================\n");
        }

        public static void RegistrarErroExcecao(string NomeLog, string MensagemLog,Exception ex)
        {
            RegistrarLog($"{NomeLog}", $"{MensagemLog}");
            RegistrarLog($"{NomeLog}", ex.Message);
        }
    }
}
