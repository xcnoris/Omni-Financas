
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using System.Windows.Forms;

namespace CDI_OminiService.Formularios
{
    public partial class FrmConfigEmail : UserControl
    {
        private DAL<ConfigEmail> dal;

        public string Server
        {
            get { return Txt_Server.Text; }
        }
        public string Port
        {
            get { return Txt_Port.Text; }
        }
        public string Email
        {
            get { return Txt_Email.Text; }
        }
        public string Senha
        {
            get { return Txt_Senha.Text; }
        }


        public FrmConfigEmail()
        {
            InitializeComponent();

            var context = new IntegradorDBContext();
            dal = new DAL<ConfigEmail>(context); // Inicializa a DAL

            CarregarConfigEmail();
        }

        private async Task CarregarConfigEmail()
        {
            try
            {

                // Obter lista de dados da API de forma assíncrona e converter para lista
                ConfigEmail? configEmail = await dal.BuscarPorAsync(x => x.Id.Equals(1));

                if (configEmail is null)
                {
                    MetodosGerais.RegistrarLog("ConfigEmail", "Nenhuma Configuração de Email definida!");
                    return;
                }

                CarregarTxts(configEmail);


            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("ConfigEmail", $"ERROR: {ex.Message}");
                MessageBox.Show("Erro ao carregar dados da API de conexão: " + ex.Message);
            }
        }


        private void CarregarTxts(ConfigEmail configEmail)
        {
            if (!string.IsNullOrEmpty(configEmail.SMTP_Server))
            {
                Txt_Server.Text = configEmail.SMTP_Server;
            }
            else
            {
                MetodosGerais.RegistrarLog("ConfigEmail", "ERROR: SMTP Server é nulo");
            }

            if (!(configEmail.SMTP_Port < 0 ))
            {
                Txt_Port.Text = configEmail.SMTP_Port.ToString();
            }
            else
            {
                MetodosGerais.RegistrarLog("ConfigEmail", "ERROR: SMPT Porta é nulo");
            }

            if (!string.IsNullOrEmpty(configEmail.Email))
            {
                Txt_Email.Text = configEmail.Email;
            }
            else
            {
                MetodosGerais.RegistrarLog("ConfigEmail", "ERROR: Email é nulo");
            }

            if (!string.IsNullOrEmpty(configEmail.Senha))
            {
                Txt_Senha.Text = configEmail.Senha;
            }
            else
            {
                MetodosGerais.RegistrarLog("ConfigEmail", "ERROR: Senha é nulo");
            }


        }
    }
}
