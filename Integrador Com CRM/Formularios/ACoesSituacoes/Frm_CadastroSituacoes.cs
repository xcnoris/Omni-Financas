using CDI_OminiService.Formularios;
using CDI_OminiService.Formularios.Boleto;
using CDI_OminiService.Formularios.OS;
using DataBase.IntegradorCRM.Data;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_CadastroSituacoes : Form
    {
        private int IdSituacao;

        private Situacao_OSBoleto TipoSituacao;

        private Frm_VariaveisBoleto FrmVariaveisBoleto;
        private Frm_VariaveisOS FrmVariaveisOS;
        private FrmModelosDeMensagems ModelosMensagens;

        private readonly DAL<AcaoSituacao_OS> _dalSituacaoOS;
        private readonly DAL<AcaoSituacao_Boleto> _dalSituacaoBoleto;
        private readonly Frm_AcoesSituacoes FrmSit;


        public Frm_CadastroSituacoes(Situacao_OSBoleto enumSituacao, Situacao_Campos SituacaoCampos, Frm_AcoesSituacoes FrmAcoesSit)
        {
            InitializeComponent();

            IdSituacao = (int)SituacaoCampos;
            TipoSituacao = enumSituacao;

            _dalSituacaoOS = new DAL<AcaoSituacao_OS>(new IntegradorDBContext());
            _dalSituacaoBoleto = new DAL<AcaoSituacao_Boleto>(new IntegradorDBContext());
            FrmSit = FrmAcoesSit;

            CarregarCamposAsync(enumSituacao, SituacaoCampos);
        }

        internal void MostrarFormulario()
        {
            if (TipoSituacao is Situacao_OSBoleto.Boleto)
            {
                this.Text = "Casdatro Situacões Boleto";
            }
            else if (TipoSituacao is Situacao_OSBoleto.OS)
            {
                this.Text = "Casdatro Situacões Ordem de Serviço";
            }

            this.Show();
        }

        public void InserirTextoNaPosicaoDoCursor(string text)
        {
            if (Text != null || Text is not "")
            {
                int pos = Txt_Mensagem.SelectionStart;
                Txt_Mensagem.Text = Txt_Mensagem.Text.Insert(pos, Text);
                Txt_Mensagem.SelectionStart = pos + Text.Length;
                Txt_Mensagem.Focus(); // Retorna o foco ao TextBox
            }
        }

        private async Task CarregarCamposAsync(Situacao_OSBoleto situacaoOSBoleto, Situacao_Campos tiposCamposSituacao)
        {
            int idFiltro = (int)tiposCamposSituacao; // Converte o Enum para inteiro

            if (idFiltro is 11)
            {
                idFiltro = 1;
            }
            if (situacaoOSBoleto == Situacao_OSBoleto.Boleto)
            {
                AcaoSituacao_Boleto? registroExistente = await _dalSituacaoBoleto.BuscarPorAsync(x => x.Situacao == (Situacao_Boleto)idFiltro);

                if (registroExistente != null)
                {
                    // Atualiza os campos do formulário com os dados encontrados
                    Txt_Id.Text = registroExistente.Id.ToString();
                    Txt_Nome.Text = registroExistente.Nome;
                    Txt_Mensagem.Text = registroExistente.MensagemAtualizacaoWhats;
                }
            }
            else if (situacaoOSBoleto == Situacao_OSBoleto.OS)
            {
                AcaoSituacao_OS? registroExistente = await _dalSituacaoOS.BuscarPorAsync(x => x.Situacao == (Situacao_OS)idFiltro);

                if (registroExistente != null)
                {
                    // Atualiza os campos do formulário com os dados encontrados
                    Txt_Id.Text = registroExistente.Id.ToString();
                    Txt_Nome.Text = registroExistente.Nome;
                    Txt_Mensagem.Text = registroExistente.Mensagem;
                }
            }
        }



        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private async Task Salvar()
        {
            try
            {
                ValidarCampos(); // Se falhar, interrompe aqui.

                if (TipoSituacao == Situacao_OSBoleto.Boleto)
                {
                    AcaoSituacao_Boleto? registroExistente = await _dalSituacaoBoleto.BuscarPorAsync(x => x.Situacao == (Situacao_Boleto)IdSituacao);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Nome = Txt_Nome.Text;
                        registroExistente.MensagemAtualizacaoWhats = Txt_Mensagem.Text;
                        registroExistente.Data_Atualizacao = DateTime.Now;

                        await _dalSituacaoBoleto.AtualizarAsync(registroExistente);
                    }
                    else
                    {
                        registroExistente = new AcaoSituacao_Boleto()
                        {
                            Situacao = (Situacao_Boleto)IdSituacao,
                            Nome = Txt_Nome.Text,
                            MensagemAtualizacaoWhats = Txt_Mensagem.Text,
                            Data_Cricao = DateTime.Now,
                        };
                        await _dalSituacaoBoleto.AdicionarAsync(registroExistente);
                    }

                    this.Close();
                }
                else if (TipoSituacao == Situacao_OSBoleto.OS)
                {
                    if (IdSituacao is 11)
                    {
                        IdSituacao = 1;
                    }
                    AcaoSituacao_OS? registroExistente = await _dalSituacaoOS.BuscarPorAsync(x => x.Situacao == (Situacao_OS)IdSituacao);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Nome = Txt_Nome.Text;
                        registroExistente.Mensagem = Txt_Mensagem.Text;
                        registroExistente.Data_Atualizacao = DateTime.Now;

                        await _dalSituacaoOS.AtualizarAsync(registroExistente);
                    }
                    else
                    {
                        registroExistente = new AcaoSituacao_OS()
                        {
                            Situacao = (Situacao_OS)IdSituacao,
                            Nome = Txt_Nome.Text,
                            Mensagem = Txt_Mensagem.Text,
                            Data_Cricao = DateTime.Now,
                        };
                        await _dalSituacaoOS.AdicionarAsync(registroExistente);
                    }
                    await FrmSit.CarregarMensagensSituacoes();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(Txt_Nome.Text))
            {
                MessageBox.Show("Por favor, informe um nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("ID de categoria inválido."); // Lança uma exceção para interromper o fluxo
            }
        }

        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Variaveis_Click(object sender, EventArgs e)
        {
            if (TipoSituacao is Situacao_OSBoleto.Boleto)
            {
                if (FrmVariaveisBoleto is not null)
                    FrmVariaveisBoleto.Close();

                FrmVariaveisBoleto = new Frm_VariaveisBoleto(this);
                FrmVariaveisBoleto.Show();
            }
            else if (TipoSituacao is Situacao_OSBoleto.OS)
            {
                if (FrmVariaveisOS is not null)
                    FrmVariaveisOS.Close();

                FrmVariaveisOS = new Frm_VariaveisOS(Txt_Mensagem);
                FrmVariaveisOS.Show();
            }
        }

        private void Frm_CadastroSituacoes_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FrmVariaveisBoleto is not null)
                FrmVariaveisBoleto.Close();

            if (FrmVariaveisOS is not null)
                FrmVariaveisOS.Close();
        }

        private void Btn_Salvar_MouseEnter(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Salvar_MouseLeave(object sender, EventArgs e)
        {
            Btn_Salvar.BackColor = Color.Teal;
        }

        private void Btn_Remover_MouseEnter(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.Silver;
        }

        private void Btn_Remover_MouseLeave(object sender, EventArgs e)
        {
            Btn_Remover.BackColor = Color.DarkGray;
        }

        private void Btn_Variaveis_MouseEnter(object sender, EventArgs e)
        {
            Btn_Variaveis.BackColor = Color.MediumTurquoise;
        }

        private void Btn_Variaveis_MouseLeave(object sender, EventArgs e)
        {
            Btn_Variaveis.BackColor = Color.Teal;
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
