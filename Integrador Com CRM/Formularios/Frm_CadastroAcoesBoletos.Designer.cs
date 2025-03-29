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
            Btn_Salvar = new ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new ComponentesPerson.BotaoArredond(components);
            Txt_Mensagem = new TextBox();
            Lbl_MensagemEnvio = new Label();
            Txt_DiaCobranca = new TextBox();
            label1 = new Label();
            Check_EnviarPDF = new CheckBox();
            SuspendLayout();
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(113, 20);
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
            Lbl_Id.ForeColor = Color.White;
            Lbl_Id.Location = new Point(33, 23);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(23, 15);
            Lbl_Id.TabIndex = 35;
            Lbl_Id.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.LimeGreen;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(127, 263);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 34;
            Btn_Salvar.Text = "Salvar";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Tomato;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(235, 263);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 33;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.Location = new Point(33, 105);
            Txt_Mensagem.MaxLength = 100;
            Txt_Mensagem.Multiline = true;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.Size = new Size(394, 139);
            Txt_Mensagem.TabIndex = 3;
            // 
            // Lbl_MensagemEnvio
            // 
            Lbl_MensagemEnvio.AutoSize = true;
            Lbl_MensagemEnvio.BackColor = Color.Transparent;
            Lbl_MensagemEnvio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Lbl_MensagemEnvio.ForeColor = Color.White;
            Lbl_MensagemEnvio.Location = new Point(33, 87);
            Lbl_MensagemEnvio.Name = "Lbl_MensagemEnvio";
            Lbl_MensagemEnvio.Size = new Size(101, 15);
            Lbl_MensagemEnvio.TabIndex = 31;
            Lbl_MensagemEnvio.Text = "Mensagem Envio:";
            // 
            // Txt_DiaCobranca
            // 
            Txt_DiaCobranca.Location = new Point(113, 53);
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
            label1.ForeColor = Color.White;
            label1.Location = new Point(33, 56);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 39;
            label1.Text = "Dia Cobrança:";
            // 
            // Check_EnviarPDF
            // 
            Check_EnviarPDF.AutoSize = true;
            Check_EnviarPDF.BackColor = Color.Transparent;
            Check_EnviarPDF.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDF.ForeColor = Color.White;
            Check_EnviarPDF.Location = new Point(341, 57);
            Check_EnviarPDF.Name = "Check_EnviarPDF";
            Check_EnviarPDF.Size = new Size(86, 19);
            Check_EnviarPDF.TabIndex = 2;
            Check_EnviarPDF.Text = "Enviar PDF:";
            Check_EnviarPDF.UseVisualStyleBackColor = false;
            // 
            // Frm_CadastroAcoesBoletos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(461, 298);
            Controls.Add(Check_EnviarPDF);
            Controls.Add(label1);
            Controls.Add(Txt_DiaCobranca);
            Controls.Add(Txt_Id);
            Controls.Add(Lbl_Id);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(Txt_Mensagem);
            Controls.Add(Lbl_MensagemEnvio);
            MaximizeBox = false;
            MaximumSize = new Size(477, 337);
            MinimizeBox = false;
            MinimumSize = new Size(477, 337);
            Name = "Frm_CadastroAcoesBoletos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro Ações Boleto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Id;
        private Label Lbl_Id;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private TextBox Txt_Mensagem;
        private Label Lbl_MensagemEnvio;
        private TextBox Txt_DiaCobranca;
        private Label label1;
        private CheckBox Check_EnviarPDF;
    }
}