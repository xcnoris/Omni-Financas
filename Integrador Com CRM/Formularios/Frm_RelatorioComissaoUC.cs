using Aplication.IntegradorCRM.Metodos.ControleComissao;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Retornos;
using QuestPDF.Infrastructure;
using System.Diagnostics;

namespace Integrador_Com_CRM.Formularios
{
    public partial class Frm_RelatorioComissaoUC : UserControl
    {
        private readonly DAL<Controle_Liberacao_ComissaoModel> _dalControle_Liberacao;


        public string DataInicio
        {
            get
            {
                return DTP_DTInicio.Value.ToString("dd/MM/yyyy");
            }
        }

        public string DataFim
        {
            get
            {
                return DTP_DTFim.Value.ToString("dd/MM/yyyy");
            }
        }

        public int Index_Id_CboxVendedor
        {
            get
            {
                if (Cbox_Vendedores.SelectedItem is RetornoVendedores vendedorSelecionado)
                    return vendedorSelecionado.Id_Vendedor;
                else
                    return Cbox_Vendedores.SelectedIndex;
            }
        }

        public string NomeVendedor
        {
            get
            {
                if (Cbox_Vendedores.SelectedItem is RetornoVendedores vendedorSelecionado)
                    return vendedorSelecionado.Nome;
                return "";
            }
        }

        public int IndexSituacaoComissao
        {
            get
            {
                if (Cbox_SituacaoComissao.SelectedItem is SituacaoComissao sit)
                    return sit.Id;
                else
                    return Cbox_SituacaoComissao.SelectedIndex;
            }
        }

        public string NomeSituacaoSelecionada
        {
            get
            {
                if (Cbox_SituacaoComissao.SelectedItem is SituacaoComissao sit)
                {

                    if (sit.Id == 2)
                    {
                        return "";
                    }
                    return sit.Nome;
                }
                return "";

            }
        }


        public Frm_RelatorioComissaoUC()
        {
            InitializeComponent();

            _dalControle_Liberacao = new DAL<Controle_Liberacao_ComissaoModel>(new IntegradorDBContext());
            CarregarVendedores();
            CarregarSituacoes();
        }

        private void Btn_SelectDiretorio_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecione um diretório para salvar o arquivo";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Txt_Diretorio.Text = fbd.SelectedPath;
                }
            }
        }

        private void Btn_GerarPDF_Click(object sender, EventArgs e)
        {
            if (Index_Id_CboxVendedor == -1)
            {
                MessageBox.Show($"Selecione um vendedor!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VisualizarPDF();
        }


        private async Task VisualizarPDF()
        {
            await GerarRelatorioEmPDF();
        }

        private async Task GerarRelatorioEmPDF()
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;

                List<Controle_Liberacao_ComissaoModel?> comissaoList = await ListarComissoesGeradas();

                if (comissaoList == null || comissaoList.Count == 0)
                {
                    MessageBox.Show($"Nenhuma comissão gerada para esse vendedor no perido selecionado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



                var reportGenerator = new QuestPDFService(comissaoList, Cbox_Vendedores.Text, DataInicio, DataFim);

                string caminhoPDF = $"{Txt_Diretorio.Text}\\Relatorio_Comissao_{NomeVendedor}_{DateTime.Now:dd-MM-yyyy}.pdf";

                bool modeloPDF = false;
                if (IndexSituacaoComissao == 1 || IndexSituacaoComissao == 3 || IndexSituacaoComissao == 4)
                {
                    modeloPDF = false;
                }
                else if (IndexSituacaoComissao == 2)
                {
                    modeloPDF = true;
                }

                reportGenerator.GerarPDF(caminhoPDF, modeloPDF, $"- {NomeSituacaoSelecionada}");
                VisualizarPDF(caminhoPDF);
            }

            catch (Exception ex)
            {
                MetodosGerais.RegistrarLog("GeracaoPDF", $"Ocorreu um erro ao gerar o relatorio pdf. ERROR: {ex.Message}");
                MessageBox.Show($"Ocorreu um erro ao gerar o relatorio. ERROR:  {ex.Message}", "Erro na geração", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<List<Controle_Liberacao_ComissaoModel?>> ListarComissoesGeradas()
        {
            try
            {

                DateTime dataInicio = Convert.ToDateTime(DataInicio).Date; // Garante que começa no início do dia
                DateTime dataFim = Convert.ToDateTime(DataFim).Date.AddDays(1).AddTicks(-1); // Último milissegundo do dia

                // TODAS AS COMISSOES GERADAS
                if (IndexSituacaoComissao == 1)
                {
                    return (await _dalControle_Liberacao.
                    RecuperarTodosPorAsync(
                        x => x.Id_Usuario_Vendedor == Index_Id_CboxVendedor &&
                        x.data_hora_emissao_nota >= dataInicio &&
                        x.data_hora_emissao_nota <= dataFim
                    )).ToList();
                }
                // TODAS AS COMISSOES LIBERADAS NAO PAGAS
                else if (IndexSituacaoComissao == 2)
                {
                    return (await _dalControle_Liberacao.
                    RecuperarTodosPorAsync(
                        x => x.Id_Usuario_Vendedor == Index_Id_CboxVendedor &&
                        x.Data_Quitacao >= dataInicio &&
                        x.Data_Quitacao <= dataFim &&
                        x.Pago_para_Vendedor == 0
                    )).ToList();
                }
                // TODAS AS COMISSOES LIBERADAS  PAGAS
                else if (IndexSituacaoComissao == 3)
                {
                    return (await _dalControle_Liberacao.
                    RecuperarTodosPorAsync(
                        x => x.Id_Usuario_Vendedor == Index_Id_CboxVendedor &&
                        x.Data_Quitacao >= dataInicio &&
                        x.Data_Quitacao <= dataFim &&
                        x.Pago_para_Vendedor == 1
                    )).ToList();
                }
                // TODAS AS COMISSOES LIBERADAS  PAGAS
                else if (IndexSituacaoComissao == 4)
                {
                    return (await _dalControle_Liberacao.
                    RecuperarTodosPorAsync(
                        x => x.Id_Usuario_Vendedor == Index_Id_CboxVendedor &&
                        x.Data_Vencimento >= dataInicio &&
                        x.Data_Vencimento <= dataFim &&
                        x.Data_Quitacao == null &&
                        x.Pago_para_Vendedor == 0
                    )).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao", $"Erro ao listar comissoes geradas:", ex);
                throw;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("Comissao");
            }

        }



        private void VisualizarPDF(string caminhoPDF)
        {
            if (!string.IsNullOrEmpty(caminhoPDF) && System.IO.File.Exists(caminhoPDF))
            {
                Process.Start(new ProcessStartInfo(caminhoPDF) { UseShellExecute = true });
            }
            else
            {
                MetodosGerais.RegistrarLog("ComissaoOperacoes", $"Arquivo não encontrado! Caminho PDF {caminhoPDF}");
                MessageBox.Show("Arquivo não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task CarregarVendedores()
        {
            CrudVendedores crudVendedores = new CrudVendedores();
            List<RetornoVendedores> vendedoresList = await crudVendedores.BuscarComissoesInDB();

            if (vendedoresList == null || vendedoresList.Count == 0)
            {
                MetodosGerais.RegistrarLog("ComissaoOperacoes", $"Nenhum vendedor encontrado");
                //MessageBox.Show("Nenhum vendedor encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cbox_Vendedores.DataSource = null; // Limpa o ComboBox
            Cbox_Vendedores.DisplayMember = "Nome";  // Nome que será exibido
            Cbox_Vendedores.ValueMember = "ID";      // Valor interno (deve corresponder ao nome da propriedade na classe)
            Cbox_Vendedores.DataSource = vendedoresList; // Atribui os dados

            Cbox_Vendedores.SelectedIndex = -1; // Garante que nenhum item esteja pré-selecionado
        }


        private async Task CarregarSituacoes()
        {
            SituacaoComissao sit1 = new SituacaoComissao()
            {
                Id = 1,
                Nome = "Geradas"
            };

            SituacaoComissao sit2 = new SituacaoComissao()
            {
                Id = 2,
                Nome = "Não Quitadas"
            };

            SituacaoComissao sit3 = new SituacaoComissao()
            {
                Id = 3,
                Nome = "Quitadas"
            };

            SituacaoComissao sit4 = new SituacaoComissao()
            {
                Id = 4,
                Nome = "Futuras"
            };

            List<SituacaoComissao> sitcomissaolist = new List<SituacaoComissao>();
            sitcomissaolist.Add(sit1);
            sitcomissaolist.Add(sit2);
            sitcomissaolist.Add(sit3);
            sitcomissaolist.Add(sit4);



            Cbox_SituacaoComissao.DataSource = null; // Limpa o ComboBox
            Cbox_SituacaoComissao.DisplayMember = "Nome";  // Nome que será exibido
            Cbox_SituacaoComissao.ValueMember = "ID";      // Valor interno (deve corresponder ao nome da propriedade na classe)
            Cbox_SituacaoComissao.DataSource = sitcomissaolist; // Atribui os dados

            Cbox_SituacaoComissao.SelectedIndex = -1; // Garante que nenhum item esteja pré-selecionado
        }

      

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            QuitarComissoes();
        }

        private async Task QuitarComissoes()
        {
            if (Index_Id_CboxVendedor == -1)
            {
                MessageBox.Show($"Selecione um vendedor!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (IndexSituacaoComissao !=2)
            {
                MessageBox.Show($"Situacao Incorreta!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resposta = MessageBox.Show("Você Realmente quer marcar como QUITADO as comissões?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta == DialogResult.Yes)
            {

                List<Controle_Liberacao_ComissaoModel?> listaComissao = await ListarComissoesGeradas();

                decimal grandTotal = 0;
                foreach (var product in listaComissao)
                {
                    grandTotal += product.Valor_Comissao_Por_Parcela;
                }

                Frm_QuitacaoComissao FrmQuitarComissao = new Frm_QuitacaoComissao(NomeVendedor, DataInicio, DataFim, $"R$ {grandTotal}");
                FrmQuitarComissao.ShowDialog();
            }
        }
    }
}
