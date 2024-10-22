namespace Integrador_Com_CRM
{
    internal static class Program
    {
        private static Mutex mutex;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string mutexName = "Global\\Integrador_Com_CRM";

            // Tenta criar o Mutex e verifica se já existe uma instância.
            bool isNewInstance;
            mutex = new Mutex(true, mutexName, out isNewInstance);

            if (!isNewInstance)
            {
                // Se já houver uma instância, exibe uma mensagem e sai.
                MessageBox.Show("O programa já está em execução.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Frm_Tela_Principal());

            // Mantém o Mutex ativo para garantir que ele não seja liberado até o fechamento da aplicação.
            GC.KeepAlive(mutex);
        }
    }
}