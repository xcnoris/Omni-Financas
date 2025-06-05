namespace CDI_OminiService.Formularios.ACoesSituacoes
{
    partial class FrmCadSituacoesBoleto
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
            Chbox_EmailEmHTML = new CheckBox();
            Check_EnviarPDFPorEmail = new CheckBox();
            TBC_Dados = new TabControl();
            Btn_VariaveisBoleto = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Check_EnviarPDFPorWhats = new CheckBox();
            label1 = new Label();
            Txt_DiaCobranca = new TextBox();
            Txt_Id = new TextBox();
            Lbl_Id = new Label();
            Btn_Salvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Lbl_MensagemEnvio = new Label();
            SuspendLayout();
            // 
            // Chbox_EmailEmHTML
            // 
            Chbox_EmailEmHTML.AutoSize = true;
            Chbox_EmailEmHTML.BackColor = Color.Transparent;
            Chbox_EmailEmHTML.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Chbox_EmailEmHTML.ForeColor = Color.Black;
            Chbox_EmailEmHTML.Location = new Point(37, 90);
            Chbox_EmailEmHTML.Name = "Chbox_EmailEmHTML";
            Chbox_EmailEmHTML.Size = new Size(159, 19);
            Chbox_EmailEmHTML.TabIndex = 55;
            Chbox_EmailEmHTML.Text = "Email em Formato HTML";
            Chbox_EmailEmHTML.UseVisualStyleBackColor = false;
            // 
            // Check_EnviarPDFPorEmail
            // 
            Check_EnviarPDFPorEmail.AutoSize = true;
            Check_EnviarPDFPorEmail.BackColor = Color.Transparent;
            Check_EnviarPDFPorEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDFPorEmail.ForeColor = Color.Black;
            Check_EnviarPDFPorEmail.Location = new Point(241, 90);
            Check_EnviarPDFPorEmail.Name = "Check_EnviarPDFPorEmail";
            Check_EnviarPDFPorEmail.Size = new Size(136, 19);
            Check_EnviarPDFPorEmail.TabIndex = 54;
            Check_EnviarPDFPorEmail.Text = "Enviar PDF por Email";
            Check_EnviarPDFPorEmail.UseVisualStyleBackColor = false;
            // 
            // TBC_Dados
            // 
            TBC_Dados.Location = new Point(12, 141);
            TBC_Dados.Name = "TBC_Dados";
            TBC_Dados.SelectedIndex = 0;
            TBC_Dados.Size = new Size(810, 298);
            TBC_Dados.TabIndex = 53;
            // 
            // Btn_VariaveisBoleto
            // 
            Btn_VariaveisBoleto.BackColor = Color.Teal;
            Btn_VariaveisBoleto.Cursor = Cursors.Hand;
            Btn_VariaveisBoleto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_VariaveisBoleto.ForeColor = SystemColors.Control;
            Btn_VariaveisBoleto.Location = new Point(687, 84);
            Btn_VariaveisBoleto.Name = "Btn_VariaveisBoleto";
            Btn_VariaveisBoleto.RaioCanto = 20;
            Btn_VariaveisBoleto.Size = new Size(135, 27);
            Btn_VariaveisBoleto.TabIndex = 52;
            Btn_VariaveisBoleto.Text = "Variáveis";
            Btn_VariaveisBoleto.UseVisualStyleBackColor = false;
            Btn_VariaveisBoleto.Click += Btn_VariaveisBoleto_Click;
            // 
            // Check_EnviarPDFPorWhats
            // 
            Check_EnviarPDFPorWhats.AutoSize = true;
            Check_EnviarPDFPorWhats.BackColor = Color.Transparent;
            Check_EnviarPDFPorWhats.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDFPorWhats.ForeColor = Color.Black;
            Check_EnviarPDFPorWhats.Location = new Point(440, 90);
            Check_EnviarPDFPorWhats.Name = "Check_EnviarPDFPorWhats";
            Check_EnviarPDFPorWhats.Size = new Size(161, 19);
            Check_EnviarPDFPorWhats.TabIndex = 45;
            Check_EnviarPDFPorWhats.Text = "Enviar PDF Por Whatsapp";
            Check_EnviarPDFPorWhats.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(37, 50);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 51;
            label1.Text = "Situacao:";
            // 
            // Txt_DiaCobranca
            // 
            Txt_DiaCobranca.Location = new Point(126, 47);
            Txt_DiaCobranca.MaxLength = 10;
            Txt_DiaCobranca.Name = "Txt_DiaCobranca";
            Txt_DiaCobranca.Size = new Size(106, 23);
            Txt_DiaCobranca.TabIndex = 44;
            // 
            // Txt_Id
            // 
            Txt_Id.BackColor = Color.White;
            Txt_Id.Location = new Point(126, 18);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 50;
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.BackColor = Color.Transparent;
            Lbl_Id.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Lbl_Id.ForeColor = Color.Black;
            Lbl_Id.Location = new Point(37, 21);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(23, 15);
            Lbl_Id.TabIndex = 49;
            Lbl_Id.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(310, 445);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 48;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.DarkGray;
            Btn_Remover.Cursor = Cursors.Hand;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(418, 445);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 47;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Lbl_MensagemEnvio
            // 
            Lbl_MensagemEnvio.AutoSize = true;
            Lbl_MensagemEnvio.BackColor = Color.Transparent;
            Lbl_MensagemEnvio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Lbl_MensagemEnvio.ForeColor = Color.Black;
            Lbl_MensagemEnvio.Location = new Point(37, 123);
            Lbl_MensagemEnvio.Name = "Lbl_MensagemEnvio";
            Lbl_MensagemEnvio.Size = new Size(101, 15);
            Lbl_MensagemEnvio.TabIndex = 46;
            Lbl_MensagemEnvio.Text = "Mensagem Envio:";
            // 
            // FrmCadSituacoesBoleto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_2;
            ClientSize = new Size(834, 487);
            Controls.Add(Chbox_EmailEmHTML);
            Controls.Add(Check_EnviarPDFPorEmail);
            Controls.Add(TBC_Dados);
            Controls.Add(Btn_VariaveisBoleto);
            Controls.Add(Check_EnviarPDFPorWhats);
            Controls.Add(label1);
            Controls.Add(Txt_DiaCobranca);
            Controls.Add(Txt_Id);
            Controls.Add(Lbl_Id);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(Lbl_MensagemEnvio);
            MaximizeBox = false;
            MaximumSize = new Size(850, 526);
            MinimizeBox = false;
            MinimumSize = new Size(850, 526);
            Name = "FrmCadSituacoesBoleto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Situações Boleto";
            FormClosed += FrmCadSituacoesBoleto_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox Chbox_EmailEmHTML;
        private CheckBox Check_EnviarPDFPorEmail;
        private TabControl TBC_Dados;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_VariaveisBoleto;
        private CheckBox Check_EnviarPDFPorWhats;
        private Label label1;
        private TextBox Txt_DiaCobranca;
        private TextBox Txt_Id;
        private Label Lbl_Id;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_Salvar;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_Remover;
        private Label Lbl_MensagemEnvio;
    }
}