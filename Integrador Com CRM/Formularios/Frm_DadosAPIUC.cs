using Integrador_Com_CRM.Data;
using Integrador_Com_CRM.Metodos;
using Integrador_Com_CRM.Models;

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
        //internal string CodigoAPI
        //{
        //    get
        //    {
        //        return Txt_CodigoAPI.Text;
        //    }
        //}

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
                List<DadosAPIModels> listaDadosAPI = (await dal.ListarAsync()).ToList();

                if (listaDadosAPI != null && listaDadosAPI.Count > 0)
                {
                    // Considerando que você quer o primeiro item da lista
                    var DadosApi = listaDadosAPI[0];

                    if (!string.IsNullOrEmpty(DadosApi.Token))
                    {
                        Txt_Token.Text = DadosApi.Token;
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("OS", "ERROR: Token é nulo");
                    }
                }
                else
                {
                    MetodosGerais.RegistrarLog("OS", "ERROR: Token é nulo");
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", $"ERROR: {ex.Message}");
                MessageBox.Show("Erro ao carregar dados da API de conexão: " + ex.Message);
            }
        }
        private void Frm_DadosAPIUC_Load(object sender, EventArgs e)
        {
           
        }
    }
}
