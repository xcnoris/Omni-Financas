using CDI_OminiService.Formularios;
using CDI_OminiService.Formularios.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using System.ComponentModel.DataAnnotations;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_CadastroAcoesBoletos : Form
    {

        private Frm_VariaveisBoleto FrmVariaveis;
        private readonly DAL<BoletoAcoesModel> _dalAcoesBoletos;
        private Frm_BoletoAcoesCRM_UC FrmBoletoAcoes;

        //User Control
        private readonly FrmMensEmailUC frmMensEmailUC;
        private readonly FrmMensWhatsUC frmMensWhatslUC;
        public int DiaCobranca { get; set; }

        public Frm_CadastroAcoesBoletos(bool Criacao, BoletoAcoesModel BoletoAacao, string SalvarAtualizar, Frm_BoletoAcoesCRM_UC FrmBoletoAcoesCRMUC)
        {
            InitializeComponent();

            _dalAcoesBoletos = new DAL<BoletoAcoesModel>(new IntegradorDBContext());
            FrmBoletoAcoes = FrmBoletoAcoesCRMUC;

            frmMensEmailUC = new FrmMensEmailUC();
            frmMensWhatslUC = new FrmMensWhatsUC();

            Btn_Salvar.Text = SalvarAtualizar;

            if (!Criacao)
                CarregarCampos(BoletoAacao);

            AdicionarUserControls();
        }


        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            SalvarAtualizar();
        }

        private void CarregarCampos(BoletoAcoesModel? BoletoAcoes)
        {
            Txt_Id.Text = BoletoAcoes.Id.ToString();
            Txt_Nome.Text = BoletoAcoes.Dias_Cobrancas.ToString();
            Check_EnviarPDFPorWhats.Checked = BoletoAcoes.EnviarPDFPorWhats;
            Check_EnviarPDFPorEmail.Checked = BoletoAcoes.EnviarPDFPorEmail;
            Chbox_EmailEmHTML.Checked = BoletoAcoes.MensagemEmailEmHTML;
            DiaCobranca = BoletoAcoes.Dias_Cobrancas;

            frmMensEmailUC.TxtMensEmail = BoletoAcoes.MensagemAtualizacaoEmail.ToString();
            frmMensWhatslUC.TxtMensWhats = BoletoAcoes.MensagemAtualizacaoWhats.ToString();
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

                if (string.IsNullOrWhiteSpace(Txt_Nome.Text) || !int.TryParse(Txt_Nome.Text, out IdCategoria))
                {
                    MessageBox.Show("Por favor, informe um codigo de cobrança de categoria válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Interrompe a execução do método para evitar erros
                }

                if (Txt_Id.Text is null)
                {
                    if (!await VerificaValoresRepetidos())
                    {
                        MessageBox.Show($"Dia de cobrança {Txt_Nome.Text} já cadastrado. Escolha outro dia!", $"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool enviarPDFWhats = Check_EnviarPDFPorWhats.Checked;
                bool enviarPDFEmail = Check_EnviarPDFPorEmail.Checked;
                bool MensagemEMailHTML = Chbox_EmailEmHTML.Checked;
                string MensagemWhats = frmMensWhatslUC.TxtMensWhats;
                string MensagemEmail = frmMensEmailUC.TxtMensEmail;


                // Criar um objeto para representar o registro da linha
                var BoletoAcao = new BoletoAcoesModel
                {
                    Id = Id ?? 0,
                    Dias_Cobrancas = IdCategoria,
                    EnviarPDFPorWhats = enviarPDFWhats,
                    EnviarPDFPorEmail = enviarPDFWhats,
                    MensagemAtualizacaoWhats = MensagemWhats,
                    MensagemAtualizacaoEmail = MensagemEmail,
                    MensagemEmailEmHTML = MensagemEMailHTML
                };

                if (Id != null && Id > 0)
                {
                    // Verifica se o registro já existe no banco
                    BoletoAcoesModel? registroExistente = await _dalAcoesBoletos.BuscarPorAsync(x => x.Id == Id);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Dias_Cobrancas = IdCategoria;
                        registroExistente.EnviarPDFPorWhats = enviarPDFWhats;
                        registroExistente.EnviarPDFPorEmail =  enviarPDFEmail;
                        registroExistente.MensagemAtualizacaoWhats = MensagemWhats;
                        registroExistente.MensagemAtualizacaoEmail = MensagemEmail;
                        registroExistente.MensagemEmailEmHTML = MensagemEMailHTML;

                        await _dalAcoesBoletos.AtualizarAsync(registroExistente);
                    }
                }
                else
                {
                    // Adiciona um novo registro se o ID for nulo ou 0
                    BoletoAcao.Data_Criacao = DateTime.Now;
                    await _dalAcoesBoletos.AdicionarAsync(BoletoAcao);

                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private async Task<bool> VerificaValoresRepetidos()
        {
            try
            {
                BoletoAcoesModel? BAM = await _dalAcoesBoletos.BuscarPorAsync(x => x.Dias_Cobrancas == Convert.ToInt32(Txt_Nome.Text));
                if (BAM is null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ValidationException ex)
            {
                MetodosGerais.RegistrarLog("Erro_Boleto", $"Erro: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("Erro_Boleto", $"Erro: {ex.Message}");
                return false;
            }
        }

        internal async Task MostrarFormulario()
        {
            this.Show();
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


       



        private void Frm_CadastroAcoesBoletos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmVariaveis is not null)
                FrmVariaveis.Close();
            FrmBoletoAcoes.RemoverFrmDaListFrmAbertos(DiaCobranca);
        }

        private void Btn_Salvar_MouseEnter(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Salvar_MouseLeave(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.Teal;
        }

        private void Btn_VariaveisBoleto_MouseEnter(object sender, EventArgs e)
        {
            Btn_VariaveisBoleto.BackColor = Color.MediumTurquoise;
        }

        private void Btn_VariaveisBoleto_MouseLeave(object sender, EventArgs e)
        {
            Btn_VariaveisBoleto.BackColor = Color.Teal;
        }

        private void Btn_Remover_MouseEnter(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.Silver;
        }

        private void Btn_Remover_MouseLeave(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.DarkGray;
        }
    }
}
