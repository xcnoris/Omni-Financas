using CDI_OminiService.Formularios.Boleto;
using DataBase.IntegradorCRM.Data;
using Integrador_Com_CRM.Formularios;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;

namespace CDI_OminiService.Formularios.ACoesSituacoes
{
    public partial class FrmCadSituacoesBoleto : Form
    {
        private AcaoSituacao_Boleto _BoletoSituacao;

        private Frm_VariaveisBoleto FrmVariaveis;
        //User Control
        private readonly FrmMensEmailUC frmMensEmailUC;
        private readonly FrmMensWhatsUC frmMensWhatslUC;
        private readonly DAL<AcaoSituacao_Boleto> _dalAcoesBoletosSituacoes;
        private readonly Frm_BoletoAcoesCRM_UC FrmBoletoAcoes;
        private readonly AcaoSituacao_Boleto acaoSitBoleto;
        private readonly Frm_AcoesSituacoes FrmAcoesSitBol;
        private FrmModelosDeMensagems ModelosMensagens;

        public FrmCadSituacoesBoleto(bool Criacao, AcaoSituacao_Boleto SituacaoBoletoAacao, string SalvarAtualizar, Frm_AcoesSituacoes FrmAcoesSit)
        {
            InitializeComponent();

            _dalAcoesBoletosSituacoes = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            //FrmBoletoAcoes = FrmBoletoAcoesCRMUC;

            frmMensEmailUC = new FrmMensEmailUC();
            frmMensWhatslUC = new FrmMensWhatsUC();
            FrmAcoesSitBol = FrmAcoesSit;

            Btn_Salvar.Text = SalvarAtualizar;

            acaoSitBoleto = SituacaoBoletoAacao;
            if (!Criacao)
                CarregarCampos(acaoSitBoleto);

            AdicionarUserControls();
        }




        private void AdicionarUserControls()
        {
            frmMensWhatslUC.Dock = DockStyle.Fill;
            frmMensEmailUC.Dock = DockStyle.Fill;



            TabPage MensWhats = new TabPage
            {
                Name = "Whatsapp",
                Text = "Whatsapp"
            };
            MensWhats.Controls.Add(frmMensWhatslUC);

            TabPage MensEmail = new TabPage
            {
                Name = "Email",
                Text = "Email"
            };
            MensEmail.Controls.Add(frmMensEmailUC);



            TBC_Dados.TabPages.Add(MensWhats);
            TBC_Dados.TabPages.Add(MensEmail);

        }

        private async Task CarregarCampos(AcaoSituacao_Boleto BoletoAcoesSit)
        {
            AcaoSituacao_Boleto? situacao = await _dalAcoesBoletosSituacoes.BuscarPorAsync(x => x.Situacao.Equals(BoletoAcoesSit.Situacao));

            if (situacao is not null)
            {
                Txt_Id.Text = situacao.Id.ToString();
                Txt_DiaCobranca.Text = situacao.Nome;
                Check_EnviarPDFPorWhats.Checked = situacao.EnviarPDFPorWhats;
                Check_EnviarPDFPorEmail.Checked = situacao.EnviarPDFPorEmail;
                Chbox_EmailEmHTML.Checked = situacao.MensagemEmailEmHTML;


                frmMensEmailUC.TxtMensEmail = situacao.MensagemAtualizacaoEmail.ToString();
                frmMensWhatslUC.TxtMensWhats = situacao.MensagemAtualizacaoWhats.ToString();
            }

            if (BoletoAcoesSit.Situacao is Situacao_Boleto.Cancelada_Ou_Estornado
                || BoletoAcoesSit.Situacao is Situacao_Boleto.Quitado)
            {
                Check_EnviarPDFPorEmail.Visible = false;
                Check_EnviarPDFPorWhats.Visible = false;
            }

        }
        private void Btn_VariaveisBoleto_Click(object sender, EventArgs e)
        {
            if (FrmVariaveis is not null)
                FrmVariaveis.Close();

            FrmVariaveis = new Frm_VariaveisBoleto(this);
            FrmVariaveis.Show();
        }


        public void InserirTextoNaPosicaoDoCursor(string text)
        {
            if (text is null) return;

            // Pegando a aba selecionada no TabControl
            var abaSelecionada = TBC_Dados.SelectedTab;

            if (abaSelecionada == null || abaSelecionada.Controls.Count == 0)
                return;

            // Pegando o primeiro controle da aba (esperamos que seja o UserControl)
            var controle = abaSelecionada.Controls[0];

            // Verifica o tipo do controle e trata conforme necessário
            if (controle is FrmMensEmailUC emailUC)
            {
                frmMensEmailUC.InserirTextoNaPosicaoDoCursor(text);
            }
            else if (controle is FrmMensWhatsUC whatsUC)
            {
                frmMensWhatslUC.InserirTextoNaPosicaoDoCursor(text);
            }
        }

        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            SalvarAtualizar();
        }
        private async Task SalvarAtualizar()
        {
            try
            {

                // Obter os dados da linha
                int? Id = null; // Inicializa como null

                if (!string.IsNullOrWhiteSpace(Txt_Id.Text) && int.TryParse(Txt_Id.Text, out int parsedId))
                {
                    Id = parsedId; // Se a conversão for bem-sucedida, armazena o valor
                }

                int IdCategoria;

                if (string.IsNullOrWhiteSpace(Txt_DiaCobranca.Text))
                {
                    MessageBox.Show("Por favor, informe um nome válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Interrompe a execução do método para evitar erros
                }

                if (Txt_Id.Text is null)
                {
                    //if (!await VerificaValoresRepetidos())
                    //{
                    //    MessageBox.Show($"Dia de cobrança {Txt_DiaCobranca.Text} já cadastrado. Escolha outro dia!", $"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                }

                bool enviarPDFWhats = Check_EnviarPDFPorWhats.Checked;
                bool enviarPDFEmail = Check_EnviarPDFPorEmail.Checked;
                bool MensagemEMailHTML = Chbox_EmailEmHTML.Checked;
                string MensagemWhats = frmMensWhatslUC.TxtMensWhats;
                string MensagemEmail = frmMensEmailUC.TxtMensEmail;


                // Criar um objeto para representar o registro da linha
                var BoletoAcao = new AcaoSituacao_Boleto
                {
                    Id = Id ?? 0,
                    Nome = Txt_DiaCobranca.Text,
                    Situacao = acaoSitBoleto.Situacao,
                    EnviarPDFPorWhats = enviarPDFWhats,
                    EnviarPDFPorEmail = enviarPDFWhats,
                    MensagemAtualizacaoWhats = MensagemWhats,
                    MensagemAtualizacaoEmail = MensagemEmail,
                    MensagemEmailEmHTML = MensagemEMailHTML
                };

                if (Id != null && Id > 0)
                {
                    // Verifica se o registro já existe no banco
                    AcaoSituacao_Boleto? registroExistente = await _dalAcoesBoletosSituacoes.BuscarPorAsync(x => x.Id == Id);

                    if (registroExistente != null)
                    {
                        registroExistente.Nome = Txt_DiaCobranca.Text;
                        registroExistente.EnviarPDFPorWhats = enviarPDFWhats;
                        registroExistente.EnviarPDFPorEmail = enviarPDFEmail;
                        registroExistente.MensagemAtualizacaoWhats = MensagemWhats;
                        registroExistente.MensagemAtualizacaoEmail = MensagemEmail;
                        registroExistente.MensagemEmailEmHTML = MensagemEMailHTML;
                        registroExistente.Data_Atualizacao = DateTime.Now;
                        await _dalAcoesBoletosSituacoes.AtualizarAsync(registroExistente);
                    }
                }
                else
                {
                    // Adiciona um novo registro se o ID for nulo ou 0
                    BoletoAcao.Data_Cricao = DateTime.Now;
                    await _dalAcoesBoletosSituacoes.AdicionarAsync(BoletoAcao);

                }
                await FrmAcoesSitBol.CarregarMensagensSituacoes();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCadSituacoesBoleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmVariaveis is not null)
                FrmVariaveis.Close();
        }

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            if (ModelosMensagens is not null)
                ModelosMensagens.Close();

            ModelosMensagens = new FrmModelosDeMensagems();
            ModelosMensagens.Show();
        }
    }
}
