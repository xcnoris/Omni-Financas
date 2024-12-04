using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_AcoesSituacoes : UserControl
    {
        private DAL<AcaoSituacao_Boleto_CRM> dalBoleto;
        private DAL<AcaoSituacao_OS_CRM> dalOS;

        internal string BoletoAtivo
        {
            get
            {
                return Txt_BolAtivo.Text;
            }
        }
        internal string Mensagem_BoletoAtivo
        {
            get
            {
                return Txt_MenBOLAberto.Text;
            }
        }
        internal string BoletoQuitado
        {
            get
            {
                return Txt_BolQuitado.Text;
            }
        }
        internal string Mensagem_BoletoQuitado
        {
            get
            {
                return Txt_MenBOLQuitado.Text;
            }
        }
        internal string BoletoCancelado
        {
            get
            {
                return Txt_BolCanEst.Text;
            }
        }
        internal string Mensagem_BoletoCancelado
        {
            get
            {
                return Txt_MenBOLCancelado.Text;
            }
        }
        internal string OSCancelada
        {
            get
            {
                return Txt_OSCancelada.Text;
            }
        }
        internal string Mensagem_OSCancelada
        {
            get
            {
                return Txt_MenOSCancelado.Text;
            }
        }


        public Frm_AcoesSituacoes()
        {
            InitializeComponent();

            var context = new IntegradorDBContext();

            dalBoleto = new DAL<AcaoSituacao_Boleto_CRM>(context);
            dalOS = new DAL<AcaoSituacao_OS_CRM>(context); 

            CarregarDadosAPI();
        }

        private async Task CarregarDadosAPI()
        {
            try
            {

                // Obter lista de dados da API de forma assíncrona e converter para lista
                List<AcaoSituacao_Boleto_CRM> AcoesSitBoleto = (await dalBoleto.ListarAsync()).ToList();
                List<AcaoSituacao_OS_CRM> AcoesSitOS = (await dalOS.ListarAsync()).ToList();

                if (AcoesSitBoleto is null)
                {
                    MetodosGerais.RegistrarLog("Config", "Nenhuma Ação de Situação dos Boleto Configurada");
                    return;
                }
                if (AcoesSitOS is null)
                {
                    MetodosGerais.RegistrarLog("Config", "Nenhuma Ação de Situação das OS Configurada");
                    return;
                }
                CarregarTxts(AcoesSitBoleto, AcoesSitOS);


            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("OS", $"ERROR: {ex.Message}");
                MessageBox.Show("Erro ao carregar dados da API de conexão: " + ex.Message);
            }
        }

        private void CarregarTxts(List<AcaoSituacao_Boleto_CRM> AcoesSitBoleto, List<AcaoSituacao_OS_CRM> AcoesSitOS)
        {
            

            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)) is null)
            {
                Txt_BolAtivo.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)).CodAcaoCRM;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)) is null)
            {
                Txt_MenBOLAberto.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)) is null)
            {
                Txt_BolQuitado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)).CodAcaoCRM;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)) is null)
            {
                Txt_MenBOLQuitado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)) is null)
            {
                Txt_BolCanEst.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)).CodAcaoCRM;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)) is null)
            {
                Txt_MenBOLCancelado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)) is null)
            {
                Txt_OSCancelada.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)).CodAcaoCRM;
            }
            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)) is null)
            {
                Txt_MenOSCancelado.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)).Mensagem_Acao;
            }

        }

    }
}
