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
        List<AcaoSituacao_Boleto_CRM> AcoesSitBoleto;
        List<AcaoSituacao_OS_CRM> AcoesSitOS;
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
                AcoesSitBoleto = (await dalBoleto.ListarAsync()).ToList();
                AcoesSitOS = (await dalOS.ListarAsync()).ToList();

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
            

            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)) is not null)
            {
                Txt_BolAtivo.Text = (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)).CodAcaoCRM).ToString();
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)) is not null)
            {
                Txt_MenBOLAberto.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Aberto)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)) is not null)
            {
                Txt_BolQuitado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)).CodAcaoCRM;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)) is not null)
            {
                Txt_MenBOLQuitado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)) is not null)
            {
                Txt_BolCanEst.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)).CodAcaoCRM;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)) is not null)
            {
                Txt_MenBOLCancelado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)).Mensagem_Acao;
            }
            //----------------------------
            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)) is not null)
            {
                Txt_OSCancelada.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)).CodAcaoCRM;
            }
            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)) is not null)
            {
                Txt_MenOSCancelado.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)).Mensagem_Acao;
            }

        }


        internal List<AcaoSituacao_Boleto_CRM> RetornarListAcoesSitBoleto()
        {
            // Atualizar ou adicionar elemento para 'Aberto'
            AtualizarOuAdicionarAcao(Situacao_Boleto.Aberto, Txt_BolAtivo.Text, Txt_MenBOLAberto.Text);

            // Atualizar ou adicionar elemento para 'Quitado'
            AtualizarOuAdicionarAcao(Situacao_Boleto.Quitado, Txt_BolQuitado.Text, Txt_MenBOLQuitado.Text);

            // Atualizar ou adicionar elemento para 'Cancelada_Ou_Estornado'
            AtualizarOuAdicionarAcao(Situacao_Boleto.Cancelada_Ou_Estornado, Txt_BolCanEst.Text, Txt_MenBOLCancelado.Text);

            return AcoesSitBoleto;
        }

        private void AtualizarOuAdicionarAcao(Situacao_Boleto situacao, string codAcao, string mensagemAcao)
        {
            // Localiza o elemento na lista baseado na situação
            var acaoExistente = AcoesSitBoleto.FirstOrDefault(a => a.Situacao == situacao);

            if (acaoExistente != null)
            {
                // Atualiza os valores se o elemento já existe
                acaoExistente.CodAcaoCRM = codAcao;
                acaoExistente.Mensagem_Acao = mensagemAcao;
                acaoExistente.Data_Atualizacao = DateTime.Now;
            }
            else
            {
                // Adiciona um novo elemento se não encontrado
                AcoesSitBoleto.Add(new AcaoSituacao_Boleto_CRM
                {
                    Situacao = situacao,
                    CodAcaoCRM = codAcao,
                    Mensagem_Acao = mensagemAcao,
                    Data_Cricao = DateTime.Now 
                });
            }
        }


        internal List<AcaoSituacao_OS_CRM> RetornarListAcoesSitOS()
        {

            // Localiza o elemento que você quer alterar
            var acaoExistente = AcoesSitOS.FirstOrDefault(a => a.Situacao == Situacao_OS.Cancelada);

            if (acaoExistente != null)
            {
                // Alterar os valores do elemento encontrado
                acaoExistente.CodAcaoCRM = Txt_OSCancelada.Text;
                acaoExistente.Mensagem_Acao = Txt_MenOSCancelado.Text;
                acaoExistente.Data_Atualizacao = DateTime.Now;
            }
            else
            {
                // Caso não exista, adiciona um novo elemento
                AcoesSitOS.Add(new AcaoSituacao_OS_CRM()
                {
                    Situacao = Situacao_OS.Cancelada,
                    CodAcaoCRM = Txt_OSCancelada.Text,
                    Mensagem_Acao = Txt_MenOSCancelado.Text,
                    Data_Cricao = DateTime.Now
                });
            }

            return AcoesSitOS;
        }
    }
}
