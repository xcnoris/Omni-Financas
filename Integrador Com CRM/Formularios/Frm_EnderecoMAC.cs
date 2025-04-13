using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDI_OminiService.Formularios
{
    public partial class Frm_EnderecoMAC : Form
    {
        public Frm_EnderecoMAC(string MAC)
        {
            InitializeComponent();

            Txt_MAC.Text = MAC; 
        }
    }
}
