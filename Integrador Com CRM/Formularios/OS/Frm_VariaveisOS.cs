using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDI_OminiService.Formularios.OS
{
    public partial class Frm_VariaveisOS : Form
    {
        private TextBox TxtMensagem;

        public Frm_VariaveisOS(TextBox textbo)
        {
            InitializeComponent();

            TxtMensagem = textbo;
        }
        public void InserirTextoNaPosicaoDoCursor(Button btn)
        {
            if (btn != null)
            {
                int pos = TxtMensagem.SelectionStart;
                TxtMensagem.Text = TxtMensagem.Text.Insert(pos, btn.Text);
                TxtMensagem.SelectionStart = pos + btn.Text.Length;
                TxtMensagem.Focus(); // Retorna o foco ao TextBox
            }
        }

        private void Btn_IdCliente_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_NomeSocial_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_PrimNome_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_CNPJCPF_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Email_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Celular_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_IDOS_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_NSU_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Categoria_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }
    }
}
