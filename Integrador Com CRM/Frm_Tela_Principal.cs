
using Integrador_Com_CRM.Formularios;

namespace Integrador_Com_CRM
{
    public partial class Frm_Tela_Principal : Form
    {
        public string Mensagem;

        private System.Timers.Timer timer5Min;
        private System.Timers.Timer timerDaily;

        //Declando Variaveis dos Formularios
        private readonly Frm_GeralUC FrmGeralUC;
        private readonly Frm_ConexaoUC ConexaoUC;


        public Frm_Tela_Principal()
        {
            InitializeComponent();

            //Instanciando Variaveis dos Formularios
            FrmGeralUC = new Frm_GeralUC(this);
            ConexaoUC = new Frm_ConexaoUC();

            AdicionarUserontrols();
        }

        private void AdicionarUserontrols()
        {
            FrmGeralUC.Dock = DockStyle.Fill;
            ConexaoUC.Dock= DockStyle.Fill;

            TabPage TB1 = new TabPage
            {
                Name = "Geral",
                Text = "Geral"
            };
            TB1.Controls.Add(FrmGeralUC);

            TabPage TB2 = new TabPage
            {
                Name = "Conexão",
                Text = "Conexão"
            };
            TB2.Controls.Add(ConexaoUC);





            TBC_Dados.TabPages.Add(TB1);
            TBC_Dados.TabPages.Add(TB2);

        }

        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            // Minimiza a janela
            this.WindowState = FormWindowState.Minimized;
            MinimizarParaBandeja();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        internal void MinimizarParaBandeja()
        {
            // Verifica se o ponteiro do mouse está na área de trabalho (não na barra de tarefas)
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (MousePointerNotOnTaskBar)
            {
                notifyIcon1.Icon = SystemIcons.Application;
                notifyIcon1.BalloonTipText = "Seu programa está sendo minimizado para a bandeja do Windows";
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }
    }
}
