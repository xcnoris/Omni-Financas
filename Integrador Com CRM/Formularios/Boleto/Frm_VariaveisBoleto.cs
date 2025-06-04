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
        private Frm_CadastroAcoesBoletos frmCadastroAcoes;
        private Frm_CadastroSituacoes frmCadastroSituacoes;

        public Frm_VariaveisBoleto(Frm_CadastroAcoesBoletos frm_CadastroAcoes)
        {
            InitializeComponent();

            frmCadastroAcoes = frm_CadastroAcoes;
        }

        public Frm_VariaveisBoleto(Frm_CadastroSituacoes frm_CadastroSituacoes)
        {
            InitializeComponent();

            frmCadastroSituacoes = frm_CadastroSituacoes;
        }


        public void InserirTextoNaPosicaoDoCursor(Button btn)
        {
            if(frmCadastroAcoes is null)
            {
                frmCadastroSituacoes.InserirTextoNaPosicaoDoCursor(btn.Text);
            }
            if (frmCadastroSituacoes is null)
            {
                frmCadastroAcoes.InserirTextoNaPosicaoDoCursor(btn.Text);
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
