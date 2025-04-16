using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Integrador_Com_CRM.Formularios;

namespace CDI_OminiService.Formularios.Boleto
{
    public partial class Frm_VariaveisBoleto : Form
    {
        private TextBox TxtMensagem;
        public Frm_VariaveisBoleto(TextBox txtMensagem)
        {
            InitializeComponent();

            TxtMensagem = txtMensagem;
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

        private void button1_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_NomeSocial_Click_1(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_PrimNome_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Email_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_CNPJCPF_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Celular_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_IdDR_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_DocumentoDR_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Vencimento_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_Valor_Click(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }

        private void Btn_PrimNome_Click_1(object sender, EventArgs e)
        {
            InserirTextoNaPosicaoDoCursor(sender as Button);
        }
    }
}
