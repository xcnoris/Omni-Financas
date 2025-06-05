using CDI_OminiService.Formularios.ACoesSituacoes;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_AcoesSituacoes : UserControl
    {
        private DAL<AcaoSituacao_Boleto> dalBoleto;
        private DAL<AcaoSituacao_OS> dalOS;
        List<AcaoSituacao_Boleto> AcoesSitBoleto;
        List<AcaoSituacao_OS> AcoesSitOS;
        private List<AcaoSituacao_Boleto?> FrmCadSitBoletoList = new List<AcaoSituacao_Boleto?>();

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
        internal string OSCanceladaNome
        {
            get
            {
                return Txt_OSCancelada.Text;
            }
        }

        internal string OSCriacaoNome
        {
            get
            {
                return Txt_OSCriacao.Text;
            }
        }


        public Frm_AcoesSituacoes()
        {
            InitializeComponent();

            var context = new IntegradorDBContext();

            dalBoleto = new DAL<AcaoSituacao_Boleto>(context);
            dalOS = new DAL<AcaoSituacao_OS>(context);

            CarregarMensagensSituacoes();
        }

        public async Task CarregarMensagensSituacoes()
        {
            try
            {
                using DAL<AcaoSituacao_Boleto> _dalBoleto = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
                using DAL<AcaoSituacao_OS> _dalOSnew = new DAL<AcaoSituacao_OS>(new IntegradorDBContext());

                // Obter lista de dados da API de forma assíncrona e converter para lista
                AcoesSitBoleto = (await _dalBoleto.ListarAsync()).ToList();
                AcoesSitOS = (await _dalOSnew.ListarAsync()).ToList();

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

        private void CarregarTxts(List<AcaoSituacao_Boleto> AcoesSitBoleto, List<AcaoSituacao_OS> AcoesSitOS)
        {

            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.AbertoOuABertura)) is not null)
            {
                Txt_BolCriacao.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.AbertoOuABertura)).Nome;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)) is not null)
            {
                Txt_BolQuitado.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Quitado)).Nome;
            }
            if (AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)) is not null)
            {
                Txt_BolCanEst.Text = AcoesSitBoleto.FirstOrDefault(x => x.Situacao.Equals(Situacao_Boleto.Cancelada_Ou_Estornado)).Nome;
            }
            //----------------------------

            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Criacao)) is not null)
            {
                Txt_OSCriacao.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Criacao)).Nome;
            }
            if (AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)) is not null)
            {
                Txt_OSCancelada.Text = AcoesSitOS.FirstOrDefault(x => x.Situacao.Equals(Situacao_OS.Cancelada)).Nome;
            }


        }



        private void Btn_EditarMenCricaoOS_Click(object sender, EventArgs e)
        {
            Frm_CadastroSituacoes FrmCadastroSit = new Frm_CadastroSituacoes(Situacao_OSBoleto.OS, Situacao_Campos.OS_Criacao, this);
            FrmCadastroSit.MostrarFormulario();
            CarregarMensagensSituacoes();
        }

        private void Btn_EditarMenCacelarOS_Click(object sender, EventArgs e)
        {
            //Frm_CadastroSituacoes FrmCadastroSit1 = new Frm_CadastroSituacoes(Situacao_OSBoleto.OS, Situacao_Campos.OS_Cancelamento);
            //FrmCadastroSit1.MostrarFormulario();
            //CarregarDadosAPI();

            //if (!(TemFrmAberto(Situacao_Boleto.Aberto)))
            //{
            //    if (Txt_BolCriacao is null)
            //    {
                    
            //    }
            //    Frm_CadastroAcoesBoletos FrmCadACoes = new Frm_CadastroAcoesBoletos()
            //}

        }

        private bool TemFrmAberto(Situacao_Boleto situacao)
        {
            AcaoSituacao_Boleto? frm = FrmCadSitBoletoList.FirstOrDefault(x => x.Situacao.Equals(situacao));
            if (frm is null)
            {
                return false;
            }
            return true;
        }  



        private void botaoArredond2_Click(object sender, EventArgs e)
        {
            FrmCadSituacoesBoleto FrmCadSitBOl;
            if (Txt_BolCriacao.Text == "")
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(true, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.AbertoOuABertura },"Salvar", this);
            }
            else
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(false, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.AbertoOuABertura }, "Atualizar", this);
            }
            FrmCadSitBOl.Show();
            //CarregarDadosAPI();
        }

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            FrmCadSituacoesBoleto FrmCadSitBOl;
            if (Txt_BolCriacao.Text == "")
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(true, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.Quitado }, "Salvar", this);
            }
            else
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(false, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.Quitado }, "Atualizar", this);
            }
            FrmCadSitBOl.Show();
            //CarregarDadosAPI();
        }

        private void botaoArredond3_Click(object sender, EventArgs e)
        {
            FrmCadSituacoesBoleto FrmCadSitBOl;
            if (Txt_BolCriacao.Text == "")
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(true, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.Cancelada_Ou_Estornado }, "Salvar", this);
            }
            else
            {
                FrmCadSitBOl = new FrmCadSituacoesBoleto(false, new AcaoSituacao_Boleto() { Situacao = Situacao_Boleto.Cancelada_Ou_Estornado }, "Atualizar", this);
            }
            FrmCadSitBOl.Show();
            //CarregarDadosAPI();
        }

        private void Btn_Editar1_MouseEnter(object sender, EventArgs e)
        {
            Btn_Editar1.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Editar1_MouseLeave(object sender, EventArgs e)
        {
            Btn_Editar1.BackColor = Color.Teal;
        }

        private void Btn_Editar2_MouseEnter(object sender, EventArgs e)
        {
            Btn_Editar2.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Editar2_MouseLeave(object sender, EventArgs e)
        {
            Btn_Editar2.BackColor = Color.Teal;
        }

        private void Btn_Editar3_MouseEnter(object sender, EventArgs e)
        {
            Btn_Editar3.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Editar3_MouseLeave(object sender, EventArgs e)
        {
            Btn_Editar3.BackColor = Color.Teal;
        }

        private void Btn_Editar4_MouseEnter(object sender, EventArgs e)
        {
            Btn_Editar4.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Editar4_MouseLeave(object sender, EventArgs e)
        {
            Btn_Editar4.BackColor = Color.Teal;
        }

        private void Btn_Editar5_MouseEnter(object sender, EventArgs e)
        {
            Btn_Editar5.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Editar5_MouseLeave(object sender, EventArgs e)
        {
            Btn_Editar5.BackColor = Color.Teal;
        }
    }
}
