using CDI_OminiService.Formularios.ACoesSituacoes;
using Integrador_Com_CRM.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDI_OminiService.Formularios.Boleto
{
    public partial class Frm_VariaveisBoleto : Form
    {
        private Frm_CadastroAcoesBoletos frmCadastroAcoes;
        private Frm_CadastroSituacoes frmCadastroSituacoes;
        private FrmCadSituacoesBoleto frmCadSituacoesBoleto;

        public Frm_VariaveisBoleto(Frm_CadastroAcoesBoletos frm_CadastroAcoes)
        {
            InitializeComponent();

            frmCadastroAcoes = frm_CadastroAcoes;
        }

        public Frm_VariaveisBoleto(FrmCadSituacoesBoleto frm_CadastroSituacoesBoleto)
        {
            InitializeComponent();

            frmCadSituacoesBoleto = frm_CadastroSituacoesBoleto;
        }

        public Frm_VariaveisBoleto(Frm_CadastroSituacoes frm_CadastroSituacoes)
        {
            InitializeComponent();

            frmCadastroSituacoes = frm_CadastroSituacoes;
        }


        public void InserirTextoNaPosicaoDoCursor(Button btn)
        {
            if(frmCadastroAcoes is null && frmCadastroSituacoes is null)
            {
                frmCadSituacoesBoleto.InserirTextoNaPosicaoDoCursor(btn.Text);
            }
            else if(frmCadSituacoesBoleto is null && frmCadastroAcoes is null)
            {
                frmCadastroSituacoes.InserirTextoNaPosicaoDoCursor(btn.Text);
            }
            if (frmCadSituacoesBoleto is null && frmCadastroSituacoes is null)
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
