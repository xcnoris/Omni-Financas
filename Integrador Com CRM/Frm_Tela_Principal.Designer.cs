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
            botaoArredond1 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            botaoArredond2 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
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
            // botaoArredond1
            // 
            botaoArredond1.BackColor = Color.CadetBlue;
            botaoArredond1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond1.ForeColor = SystemColors.ButtonFace;
            botaoArredond1.Location = new Point(430, 451);
            botaoArredond1.Name = "botaoArredond1";
            botaoArredond1.RaioCanto = 20;
            botaoArredond1.Size = new Size(134, 30);
            botaoArredond1.TabIndex = 10;
            botaoArredond1.Text = "Fechar";
            botaoArredond1.UseVisualStyleBackColor = false;
            botaoArredond1.Click += botaoArredond1_Click;
            // 
            // botaoArredond2
            // 
            botaoArredond2.BackColor = Color.CadetBlue;
            botaoArredond2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            botaoArredond2.ForeColor = SystemColors.ButtonFace;
            botaoArredond2.Location = new Point(280, 451);
            botaoArredond2.Name = "botaoArredond2";
            botaoArredond2.RaioCanto = 20;
            botaoArredond2.Size = new Size(134, 30);
            botaoArredond2.TabIndex = 11;
            botaoArredond2.Text = "Salvar";
            botaoArredond2.UseVisualStyleBackColor = false;
            botaoArredond2.Click += botaoArredond2_Click;
            // 
            // Frm_Tela_Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(834, 487);
            Controls.Add(botaoArredond2);
            Controls.Add(botaoArredond1);
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
        private ComponentesPerson.BotaoArredond botaoArredond1;
        private ComponentesPerson.BotaoArredond botaoArredond2;
    }
}