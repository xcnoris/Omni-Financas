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
    public partial class FrmMensWhatsUC : UserControl
    {
        public string TxtMensWhats
        {
            get
            {
                return Txt_MensWhats.Text;
            }
            set
            {
                Txt_MensWhats.Text = value;
            }
        }

        public FrmMensWhatsUC()
        {
            InitializeComponent();
        }

        public void InserirTextoNaPosicaoDoCursor(string Text)
        {
            if (Text != null || Text is not "")
            {
                int pos = Txt_MensWhats.SelectionStart;
                Txt_MensWhats.Text = Txt_MensWhats.Text.Insert(pos, Text);
                Txt_MensWhats.SelectionStart = pos + Text.Length;
                Txt_MensWhats.Focus(); // Retorna o foco ao TextBox
            }
        }
    }
}
