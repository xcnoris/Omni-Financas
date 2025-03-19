using Microsoft.Extensions.Options;
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
    public partial class Frm_QuitacaoComissao : Form
    {
        public Frm_QuitacaoComissao(string nomevendedor, string dataInicio, string dataFim, string ValorTotal)
        {
            InitializeComponent();

            CarregarCampos(nomevendedor, dataInicio, dataFim, ValorTotal);
        }

        private void CarregarCampos(string nomevendedor, string dataInicio, string dataFim, string ValorTotal)
        {
            Lbl_VendedorNome.Text = nomevendedor;
            Lbl_DTInicio.Text = dataInicio;
            Lbl_DTFim.Text = dataFim;
            Lbl_ValorTotal.Text = ValorTotal;
        }

        private void botaoArredond1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_QuitarComis_Click(object sender, EventArgs e)
        {

        }
    }
}
