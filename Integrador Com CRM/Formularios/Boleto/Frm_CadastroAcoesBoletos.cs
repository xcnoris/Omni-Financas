using CDI_OminiService.Formularios.Boleto;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_CadastroAcoesBoletos : Form
    {

        private Frm_VariaveisBoleto FrmVariaveis;
        private readonly DAL<BoletoAcoesCRMModel> _dalAcoesBoletos;

        public Frm_CadastroAcoesBoletos(bool Criacao, BoletoAcoesCRMModel BoletoAacao, string SalvarAtualizar)
        {
            InitializeComponent();

            _dalAcoesBoletos = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());


            Btn_Salvar.Text = SalvarAtualizar;

            if (!Criacao)
                CarregarCampos(BoletoAacao);
        }


        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            SalvarAtualizar();
        }

        private void CarregarCampos(BoletoAcoesCRMModel? BoletoAcoes)
        {
            Txt_Id.Text = BoletoAcoes.Id.ToString();
            Txt_DiaCobranca.Text = BoletoAcoes.Dias_Cobrancas.ToString();
            Txt_Mensagem.Text = BoletoAcoes.Mensagem_Atualizacao;
            Check_EnviarPDF.Checked = BoletoAcoes.EnviarPDF;
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

                if (string.IsNullOrWhiteSpace(Txt_DiaCobranca.Text) || !int.TryParse(Txt_DiaCobranca.Text, out IdCategoria))
                {
                    MessageBox.Show("Por favor, informe um codigo de cobrança de categoria válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Interrompe a execução do método para evitar erros
                }

                if (Txt_Id.Text is null)
                {
                    if (!await VerificaValoresRepetidos())
                    {
                        MessageBox.Show($"Dia de cobrança {Txt_DiaCobranca.Text} já cadastrado. Escolha outro dia!", $"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool enviarPDF = Check_EnviarPDF.Checked;
                string Mensagem = Txt_Mensagem.Text;


                // Criar um objeto para representar o registro da linha
                var BoletoAcao = new BoletoAcoesCRMModel
                {
                    Id = Id ?? 0,
                    Dias_Cobrancas = IdCategoria,
                    EnviarPDF = enviarPDF,
                    Mensagem_Atualizacao = Mensagem
                };

                if (Id != null && Id > 0)
                {
                    // Verifica se o registro já existe no banco
                    BoletoAcoesCRMModel? registroExistente = await _dalAcoesBoletos.BuscarPorAsync(x => x.Id == Id);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Dias_Cobrancas = IdCategoria;
                        registroExistente.EnviarPDF = enviarPDF;
                        registroExistente.Mensagem_Atualizacao = Mensagem;

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





        private async Task<bool> VerificaValoresRepetidos()
        {
            try
            {
                BoletoAcoesCRMModel? BAM = await _dalAcoesBoletos.BuscarPorAsync(x => x.Dias_Cobrancas == Convert.ToInt32(Txt_DiaCobranca.Text));
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
            FrmVariaveis = new Frm_VariaveisBoleto(Txt_Mensagem);
            FrmVariaveis.Show();
        }

        private void Frm_CadastroAcoesBoletos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(FrmVariaveis is not null)
                FrmVariaveis.Close();
        }
    }
}
