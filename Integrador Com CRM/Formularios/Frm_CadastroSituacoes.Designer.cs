namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_CadastroSituacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CadastroSituacoes));
            Txt_Id = new TextBox();
            Txt_Nome = new TextBox();
            label1 = new Label();
            Btn_Salvar = new ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new ComponentesPerson.BotaoArredond(components);
            Txt_Mensagem = new TextBox();
            label5 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(115, 19);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 29;
            // 
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(115, 53);
            Txt_Nome.MaxLength = 10;
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(114, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(35, 22);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 27;
            label1.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.LimeGreen;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(129, 254);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 26;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Tomato;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(237, 254);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 25;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.Location = new Point(35, 105);
            Txt_Mensagem.MaxLength = 100;
            Txt_Mensagem.Multiline = true;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.Size = new Size(394, 128);
            Txt_Mensagem.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(35, 87);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 23;
            label5.Text = "Mensagem Envio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 22;
            label2.Text = "Nome:";
            // 
            // Frm_CadastroSituacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(461, 298);
            Controls.Add(Txt_Id);
            Controls.Add(Txt_Nome);
            Controls.Add(label1);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(Txt_Mensagem);
            Controls.Add(label5);
            Controls.Add(label2);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(477, 337);
            MinimizeBox = false;
            MinimumSize = new Size(477, 337);
            Name = "Frm_CadastroSituacoes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Casdatro Situacões";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Id;
        private TextBox Txt_Nome;
        private Label label1;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private TextBox Txt_Mensagem;
        private Label label5;
        private Label label2;
    }
}