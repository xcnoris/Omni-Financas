

using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_DadosAPIUC : UserControl
    {
        private DAL<DadosAPIModels> dal;


        internal string Token
        {
            get
            {
                return Txt_Token.Text;
            }
        }
        internal string Nome_Instancia
        {
            get
            {
                return Txt_NomeInstancia.Text;
            }
        }
      

        public Frm_DadosAPIUC()
        {
            InitializeComponent();

            var context = new IntegradorDBContext();
            dal = new DAL<DadosAPIModels>(context); // Inicializa a DAL

            CarregarDadosAPI();
        }


        private async Task CarregarDadosAPI()
        {
            try
            {

                // Obter lista de dados da API de forma assíncrona e converter para lista
                DadosAPIModels? DadosAPI = await dal.BuscarPorAsync(x => x.Id.Equals(1));

                if (DadosAPI is null)
                {
                    MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Token é nulo");
                    return;
                }

                CarregarTxts(DadosAPI);


            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("DadosAPI", $"ERROR: {ex.Message}");
                MessageBox.Show("Erro ao carregar dados da API de conexão: " + ex.Message);
            }
        }


        private void CarregarTxts(DadosAPIModels DadosAPI)
        {
            if (!string.IsNullOrEmpty(DadosAPI.Token))
            {
                Txt_Token.Text = DadosAPI.Token;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Token é nulo");
            }

            if (!string.IsNullOrEmpty(DadosAPI.Instancia))
            {
                Txt_NomeInstancia.Text = DadosAPI.Instancia;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Instancia é nulo");
            }

         
        }
    }
}
