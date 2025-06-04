namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_CadastroAcoesBoletos
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
            Txt_Id = new TextBox();
            Lbl_Id = new Label();
            Btn_Salvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Lbl_MensagemEnvio = new Label();
            Txt_DiaCobranca = new TextBox();
            label1 = new Label();
            Check_EnviarPDFPorWhats = new CheckBox();
            Btn_VariaveisBoleto = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            TBC_Dados = new TabControl();
            Check_EnviarPDFPorEmail = new CheckBox();
            SuspendLayout();
            // 
            // Txt_Id
            // 
            Txt_Id.BackColor = Color.White;
            Txt_Id.Location = new Point(146, 12);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 37;
            // 
            // Lbl_Id
            // 
            Lbl_Id.AutoSize = true;
            Lbl_Id.BackColor = Color.Transparent;
            Lbl_Id.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Lbl_Id.ForeColor = Color.Black;
            Lbl_Id.Location = new Point(57, 15);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(23, 15);
            Lbl_Id.TabIndex = 35;
            Lbl_Id.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(127, 346);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 34;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            Btn_Salvar.MouseEnter += Btn_Salvar_MouseEnter;
            Btn_Salvar.MouseLeave += Btn_Salvar_MouseLeave;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.DarkGray;
            Btn_Remover.Cursor = Cursors.Hand;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(235, 346);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 33;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            Btn_Remover.MouseEnter += Btn_Remover_MouseEnter;
            Btn_Remover.MouseLeave += Btn_Remover_MouseLeave;
            // 
            // Lbl_MensagemEnvio
            // 
            Lbl_MensagemEnvio.AutoSize = true;
            Lbl_MensagemEnvio.BackColor = Color.Transparent;
            Lbl_MensagemEnvio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Lbl_MensagemEnvio.ForeColor = Color.Black;
            Lbl_MensagemEnvio.Location = new Point(37, 119);
            Lbl_MensagemEnvio.Name = "Lbl_MensagemEnvio";
            Lbl_MensagemEnvio.Size = new Size(101, 15);
            Lbl_MensagemEnvio.TabIndex = 31;
            Lbl_MensagemEnvio.Text = "Mensagem Envio:";
            // 
            // Txt_DiaCobranca
            // 
            Txt_DiaCobranca.Location = new Point(146, 41);
            Txt_DiaCobranca.MaxLength = 10;
            Txt_DiaCobranca.Name = "Txt_DiaCobranca";
            Txt_DiaCobranca.Size = new Size(83, 23);
            Txt_DiaCobranca.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(57, 44);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 39;
            label1.Text = "Dia Cobrança:";
            // 
            // Check_EnviarPDFPorWhats
            // 
            Check_EnviarPDFPorWhats.AutoSize = true;
            Check_EnviarPDFPorWhats.BackColor = Color.Transparent;
            Check_EnviarPDFPorWhats.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDFPorWhats.ForeColor = Color.Black;
            Check_EnviarPDFPorWhats.Location = new Point(235, 88);
            Check_EnviarPDFPorWhats.Name = "Check_EnviarPDFPorWhats";
            Check_EnviarPDFPorWhats.Size = new Size(141, 19);
            Check_EnviarPDFPorWhats.TabIndex = 2;
            Check_EnviarPDFPorWhats.Text = "Enviar PDF Por Whats";
            Check_EnviarPDFPorWhats.UseVisualStyleBackColor = false;
            // 
            // Btn_VariaveisBoleto
            // 
            Btn_VariaveisBoleto.BackColor = Color.Teal;
            Btn_VariaveisBoleto.Cursor = Cursors.Hand;
            Btn_VariaveisBoleto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_VariaveisBoleto.ForeColor = SystemColors.Control;
            Btn_VariaveisBoleto.Location = new Point(292, 49);
            Btn_VariaveisBoleto.Name = "Btn_VariaveisBoleto";
            Btn_VariaveisBoleto.RaioCanto = 20;
            Btn_VariaveisBoleto.Size = new Size(135, 27);
            Btn_VariaveisBoleto.TabIndex = 40;
            Btn_VariaveisBoleto.Text = "Variáveis";
            Btn_VariaveisBoleto.UseVisualStyleBackColor = false;
            Btn_VariaveisBoleto.Click += Btn_VariaveisBoleto_Click;
            Btn_VariaveisBoleto.MouseEnter += Btn_VariaveisBoleto_MouseEnter;
            Btn_VariaveisBoleto.MouseLeave += Btn_VariaveisBoleto_MouseLeave;
            // 
            // TBC_Dados
            // 
            TBC_Dados.Location = new Point(5, 137);
            TBC_Dados.Name = "TBC_Dados";
            TBC_Dados.SelectedIndex = 0;
            TBC_Dados.Size = new Size(461, 180);
            TBC_Dados.TabIndex = 41;
            // 
            // Check_EnviarPDFPorEmail
            // 
            Check_EnviarPDFPorEmail.AutoSize = true;
            Check_EnviarPDFPorEmail.BackColor = Color.Transparent;
            Check_EnviarPDFPorEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDFPorEmail.ForeColor = Color.Black;
            Check_EnviarPDFPorEmail.Location = new Point(57, 88);
            Check_EnviarPDFPorEmail.Name = "Check_EnviarPDFPorEmail";
            Check_EnviarPDFPorEmail.Size = new Size(136, 19);
            Check_EnviarPDFPorEmail.TabIndex = 42;
            Check_EnviarPDFPorEmail.Text = "Enviar PDF por Email";
            Check_EnviarPDFPorEmail.UseVisualStyleBackColor = false;
            // 
            // Frm_CadastroAcoesBoletos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(468, 382);
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
            DoubleBuffered = true;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(477, 337);
            Name = "Frm_CadastroAcoesBoletos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Ações Boleto";
            FormClosed += Frm_CadastroAcoesBoletos_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Id;
        private Label Lbl_Id;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private Label Lbl_MensagemEnvio;
        private TextBox Txt_DiaCobranca;
        private Label label1;
        private CheckBox Check_EnviarPDFPorWhats;
        private ComponentesPerson.BotaoArredond Btn_VariaveisBoleto;
        private TabControl TBC_Dados;
        private CheckBox Check_EnviarPDFPorEmail;
    }
}