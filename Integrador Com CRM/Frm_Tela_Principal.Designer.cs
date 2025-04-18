namespace Integrador_Com_CRM
{
    partial class Frm_Tela_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Tela_Principal));
            TBC_Dados = new TabControl();
            notifyIcon1 = new NotifyIcon(components);
            label7 = new Label();
            btnFechar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            btnSalvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            SuspendLayout();
            // 
            // TBC_Dados
            // 
            TBC_Dados.Dock = DockStyle.Top;
            TBC_Dados.Location = new Point(0, 0);
            TBC_Dados.Name = "TBC_Dados";
            TBC_Dados.SelectedIndex = 0;
            TBC_Dados.Size = new Size(834, 446);
            TBC_Dados.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Integrador Com CRM";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(770, 463);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 9;
            label7.Text = "1.1.1";
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Teal;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            btnFechar.ForeColor = SystemColors.ButtonFace;
            btnFechar.Location = new Point(430, 451);
            btnFechar.Name = "btnFechar";
            btnFechar.RaioCanto = 20;
            btnFechar.Size = new Size(134, 30);
            btnFechar.TabIndex = 10;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            btnFechar.MouseEnter += btnFechar_MouseEnter;
            btnFechar.MouseLeave += btnFechar_MouseLeave;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.Teal;
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSalvar.ForeColor = SystemColors.ButtonFace;
            btnSalvar.Location = new Point(280, 451);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.RaioCanto = 20;
            btnSalvar.Size = new Size(134, 30);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            btnSalvar.MouseEnter += btnSalvar_MouseEnter;
            btnSalvar.MouseLeave += btnSalvar_MouseLeave;
            // 
            // Frm_Tela_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(834, 487);
            Controls.Add(btnSalvar);
            Controls.Add(btnFechar);
            Controls.Add(label7);
            Controls.Add(TBC_Dados);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(850, 526);
            MinimumSize = new Size(850, 526);
            Name = "Frm_Tela_Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CDI OminiService";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl TBC_Dados;
        private NotifyIcon notifyIcon1;
        private Label label7;
        private ComponentesPerson.BotaoArredond btnFechar;
        private ComponentesPerson.BotaoArredond btnSalvar;
    }
}