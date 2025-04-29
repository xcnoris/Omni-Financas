using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase.IntegradorCRM.Data;
using Modelos.IntegradorCRM.Models.EF;

namespace CDI_OminiService.Formularios
{
    public partial class FrmEtapaBoletoUC : UserControl
    {
        private readonly DAL<BoletoAcoesCRMModel> _dalAcoesBoleto;

        public FrmEtapaBoletoUC()
        {
            InitializeComponent();

            _dalAcoesBoleto = new DAL<BoletoAcoesCRMModel>(new IntegradorDBContext());

            PopularCboxDiaCobranca();
        }

        private async Task PopularCboxDiaCobranca()
        {
            List<BoletoAcoesCRMModel> AcoesBoletoList = (await _dalAcoesBoleto.ListarAsync()).ToList();

            Cbox_DiaCobranca.DataSource = AcoesBoletoList;
            Cbox_DiaCobranca.DisplayMember = "Dias_Cobrancas";
            Cbox_DiaCobranca.ValueMember = "Dias_Cobrancas";
        }
    }
}
