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
    public partial class Frm_GeralUC : UserControl
    {
        private readonly Frm_Tela_Principal FrmTelaPrincial;
        public Frm_GeralUC(Frm_Tela_Principal frmTelaPrincial)
        {
            InitializeComponent();
            FrmTelaPrincial = frmTelaPrincial;
        }


    }
}
