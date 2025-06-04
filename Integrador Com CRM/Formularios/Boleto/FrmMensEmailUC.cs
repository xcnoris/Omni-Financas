using Modelos.IntegradorCRM.Interfaces;
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
    public partial class FrmMensEmailUC : UserControl
    {
        public string TxtMensEmail
        {
            get
            {
                return Txt_MensEmail.Text;
            }
            set
            {
                Txt_MensEmail.Text = value;
            }
        }


        public void InserirTextoNaPosicaoDoCursor(string Text)
        {
            if (Text !=  null || Text is not "")
            {
                int pos = Txt_MensEmail.SelectionStart;
                Txt_MensEmail.Text = Txt_MensEmail.Text.Insert(pos, Text);
                Txt_MensEmail.SelectionStart = pos + Text.Length;
                Txt_MensEmail.Focus(); // Retorna o foco ao TextBox
            }
        }

        public FrmMensEmailUC()
        {
            InitializeComponent();
        }
    }
}
