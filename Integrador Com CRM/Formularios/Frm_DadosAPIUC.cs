

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
        internal string CodAPI_OS
        {
            get
            {
                return Txt_CodAPIOS.Text;
            }
        }
        internal string CodJornada_OS
        {
            get
            {
                return Txt_CodJornadaOS.Text;
            }
        }
        internal string CodAPI_Boleto
        {
            get
            {
                return Txt_CodAPIBoleto.Text;
            }
        }
        internal string CodJornada_Boleto
        {
            get
            {
                return Txt_CodJornadaBoleto.Text;
            }
        }

        internal string CodAPI_EnvioPDF
        {
            get
            {
                return Txt_CodAPIPDF.Text;
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

            if (!string.IsNullOrEmpty(DadosAPI.Cod_API_OrdemServico))
            {
                Txt_CodAPIOS.Text = DadosAPI.Cod_API_OrdemServico;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Cod_API_OrdemServico é nulo");
            }

            if (!string.IsNullOrEmpty(DadosAPI.Cod_Jornada_OrdemServico))
            {
                Txt_CodJornadaOS.Text = DadosAPI.Cod_Jornada_OrdemServico;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Cod_Jornada_OrdemServico é nulo");
            }

            if (!string.IsNullOrEmpty(DadosAPI.Cod_API_Boleto))
            {
                Txt_CodAPIBoleto.Text = DadosAPI.Cod_API_Boleto;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Cod_API_Boleto é nulo");
            }

            if (!string.IsNullOrEmpty(DadosAPI.Cod_Jornada_Boleto))
            {
                Txt_CodJornadaBoleto.Text = DadosAPI.Cod_Jornada_Boleto;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: Cod_Jornada_Boleto é nulo");
            }

            if (!string.IsNullOrEmpty(DadosAPI.CodAPI_EnvioPDF))
            {
                Txt_CodAPIPDF.Text = DadosAPI.CodAPI_EnvioPDF;
            }
            else
            {
                MetodosGerais.RegistrarLog("DadosAPI", "ERROR: CodAPI_EnvioPDF é nulo");
            }
        }
    }
}
