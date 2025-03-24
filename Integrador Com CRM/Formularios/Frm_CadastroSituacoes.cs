using DataBase.IntegradorCRM.Data;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Enuns;
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
    public partial class Frm_CadastroSituacoes : Form
    {
        private int IdSituacao;

        private Situacao_OSBoleto TipoSituacao;

        private readonly DAL<AcaoSituacao_OS_CRM> _dalSituacaoOS;
        private readonly DAL<AcaoSituacao_Boleto_CRM> _dalSituacaoBoleto;

        public Frm_CadastroSituacoes(Situacao_OSBoleto enumSituacao, Situacao_Campos SituacaoCampos)
        {
            InitializeComponent();

            IdSituacao = (int)SituacaoCampos;
            TipoSituacao = enumSituacao;

            _dalSituacaoOS = new DAL<AcaoSituacao_OS_CRM>(new IntegradorDBContext());
            _dalSituacaoBoleto = new DAL<AcaoSituacao_Boleto_CRM>(new IntegradorDBContext());


            CarregarCamposAsync(enumSituacao, SituacaoCampos);
        }

        internal void MostrarFormulario()
        {
            this.ShowDialog();
        }

        private async Task CarregarCamposAsync(Situacao_OSBoleto situacaoOSBoleto, Situacao_Campos tiposCamposSituacao)
        {
            int idFiltro = (int)tiposCamposSituacao; // Converte o Enum para inteiro
            if (situacaoOSBoleto == Situacao_OSBoleto.Boleto)
            {
                AcaoSituacao_Boleto_CRM? registroExistente = await _dalSituacaoBoleto.BuscarPorAsync(x => x.Situacao.Equals(idFiltro));

                if (registroExistente != null)
                {
                    // Atualiza os campos do formulário com os dados encontrados
                    Txt_Id.Text = registroExistente.Id.ToString();
                    Txt_Nome.Text = registroExistente.Nome;
                    Txt_Mensagem.Text = registroExistente.Mensagem;
                }
            }
            else if (situacaoOSBoleto == Situacao_OSBoleto.OS)
            {
                AcaoSituacao_OS_CRM? registroExistente = await _dalSituacaoOS.BuscarPorAsync(x => x.Situacao.Equals(idFiltro));

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
                    AcaoSituacao_Boleto_CRM? registroExistente = await _dalSituacaoBoleto.BuscarPorAsync(x => x.Id == IdSituacao);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Nome = Txt_Nome.Text;
                        registroExistente.Mensagem = Txt_Mensagem.Text;

                        await _dalSituacaoBoleto.AtualizarAsync(registroExistente);
                    }
                }
                else if (TipoSituacao == Situacao_OSBoleto.OS)
                {
                    AcaoSituacao_OS_CRM? registroExistente = await _dalSituacaoOS.BuscarPorAsync(x => x.Id == IdSituacao);

                    if (registroExistente != null)
                    {
                        // Atualiza os dados do registro existente
                        registroExistente.Nome = Txt_Nome.Text;
                        registroExistente.Mensagem = Txt_Mensagem.Text;

                        await _dalSituacaoOS.AtualizarAsync(registroExistente);
                    }
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
    }
}
