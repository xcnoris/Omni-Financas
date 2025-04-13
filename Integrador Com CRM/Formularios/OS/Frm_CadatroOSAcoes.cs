using CDI_OminiService.Formularios.OS;
using DataBase.IntegradorCRM.Data;
using Modelos.IntegradorCRM.Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_CadatroOSAcoes : Form
    {
        private readonly DAL<OSAcoesCRMModel> _dalOSAcoes;

        public Frm_CadatroOSAcoes(bool Criacao, OSAcoesCRMModel OSAcoes, string SalvarAtualizar)
        {
            InitializeComponent();

            _dalOSAcoes = new DAL<OSAcoesCRMModel>(new IntegradorDBContext());


            Btn_Salvar.Text = SalvarAtualizar;

            if (!Criacao)
                CarregarCampos(OSAcoes);
        }

        private void CarregarCampos(OSAcoesCRMModel? OSAcoes)
        {
            Txt_Id.Text = OSAcoes.Id.ToString();
            Txt_IdCategoria.Text = OSAcoes.IdCategoria.ToString();
            Txt_Mensagem.Text = OSAcoes.Mensagem_Atualizacao;
        }

        private void Btn_Remover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Salvar_Click(object sender, EventArgs e)
        {
            SalvarAtualizar();
        }

        internal async Task MostrarFormulario()
        {
            this.ShowDialog();
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

                if (string.IsNullOrWhiteSpace(Txt_IdCategoria.Text) || !int.TryParse(Txt_IdCategoria.Text, out IdCategoria))
                {
                    MessageBox.Show("Por favor, informe um ID de categoria válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Interrompe a execução do método para evitar erros
                }


                string Mensagem = Txt_Mensagem.Text;


                // Criar um objeto para representar o registro da linha
                var osAcao = new OSAcoesCRMModel
                {
                    Id = Id ?? 0,
                    IdCategoria = IdCategoria,
                    Mensagem_Atualizacao = Mensagem
                };

                if (Id != null && Id > 0)
                {
                    // Verifica se o registro já existe no banco
                    OSAcoesCRMModel? registroExistente = await _dalOSAcoes.BuscarPorAsync(x => x.Id == Id);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.IdCategoria = IdCategoria;
                        registroExistente.Mensagem_Atualizacao = Mensagem;

                        await _dalOSAcoes.AtualizarAsync(registroExistente);
                    }
                }
                else
                {
                    // Adiciona um novo registro se o ID for nulo ou 0
                    osAcao.Data_Criacao = DateTime.Now;
                    await _dalOSAcoes.AdicionarAsync(osAcao);

                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Variaveis_Click(object sender, EventArgs e)
        {
            Frm_VariaveisOS frm = new Frm_VariaveisOS();
            frm.Show();
        }
    }
}
