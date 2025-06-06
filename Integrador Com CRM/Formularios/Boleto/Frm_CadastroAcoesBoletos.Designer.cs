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
            Txt_Nome = new TextBox();
            label1 = new Label();
            Check_EnviarPDFPorWhats = new CheckBox();
            Btn_VariaveisBoleto = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            TBC_Dados = new TabControl();
            Check_EnviarPDFPorEmail = new CheckBox();
            Chbox_EmailEmHTML = new CheckBox();
            botaoArredond1 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            SuspendLayout();
            // 
            // Txt_Id
            // 
            Txt_Id.BackColor = Color.White;
            Txt_Id.Location = new Point(126, 14);
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
            Lbl_Id.Location = new Point(37, 17);
            Lbl_Id.Name = "Lbl_Id";
            Lbl_Id.Size = new Size(23, 15);
            Lbl_Id.TabIndex = 35;
            Lbl_Id.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.Anchor = AnchorStyles.Bottom;
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(310, 441);
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
            Btn_Remover.Anchor = AnchorStyles.Bottom;
            Btn_Remover.BackColor = Color.DarkGray;
            Btn_Remover.Cursor = Cursors.Hand;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(418, 441);
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
            // Txt_Nome
            // 
            Txt_Nome.Location = new Point(126, 43);
            Txt_Nome.MaxLength = 10;
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(83, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(37, 46);
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
            Check_EnviarPDFPorWhats.Location = new Point(37, 86);
            Check_EnviarPDFPorWhats.Name = "Check_EnviarPDFPorWhats";
            Check_EnviarPDFPorWhats.Size = new Size(161, 19);
            Check_EnviarPDFPorWhats.TabIndex = 2;
            Check_EnviarPDFPorWhats.Text = "Enviar PDF Por Whatsapp";
            Check_EnviarPDFPorWhats.UseVisualStyleBackColor = false;
            // 
            // Btn_VariaveisBoleto
            // 
            Btn_VariaveisBoleto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Btn_VariaveisBoleto.BackColor = Color.Teal;
            Btn_VariaveisBoleto.Cursor = Cursors.Hand;
            Btn_VariaveisBoleto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_VariaveisBoleto.ForeColor = SystemColors.Control;
            Btn_VariaveisBoleto.Location = new Point(687, 80);
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
            TBC_Dados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TBC_Dados.Location = new Point(12, 137);
            TBC_Dados.Name = "TBC_Dados";
            TBC_Dados.SelectedIndex = 0;
            TBC_Dados.Size = new Size(810, 298);
            TBC_Dados.TabIndex = 41;
            // 
            // Check_EnviarPDFPorEmail
            // 
            Check_EnviarPDFPorEmail.AutoSize = true;
            Check_EnviarPDFPorEmail.BackColor = Color.Transparent;
            Check_EnviarPDFPorEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Check_EnviarPDFPorEmail.ForeColor = Color.Black;
            Check_EnviarPDFPorEmail.Location = new Point(234, 88);
            Check_EnviarPDFPorEmail.Name = "Check_EnviarPDFPorEmail";
            Check_EnviarPDFPorEmail.Size = new Size(136, 19);
            Check_EnviarPDFPorEmail.TabIndex = 42;
            Check_EnviarPDFPorEmail.Text = "Enviar PDF por Email";
            Check_EnviarPDFPorEmail.UseVisualStyleBackColor = false;
            // 
            // Chbox_EmailEmHTML
            // 
            Chbox_EmailEmHTML.AutoSize = true;
            Chbox_EmailEmHTML.BackColor = Color.Transparent;
            Chbox_EmailEmHTML.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Chbox_EmailEmHTML.ForeColor = Color.Black;
            Chbox_EmailEmHTML.Location = new Point(434, 88);
            Chbox_EmailEmHTML.Name = "Chbox_EmailEmHTML";
            Chbox_EmailEmHTML.Size = new Size(159, 19);
            Chbox_EmailEmHTML.TabIndex = 43;
            Chbox_EmailEmHTML.Text = "Email em Formato HTML";
            Chbox_EmailEmHTML.UseVisualStyleBackColor = false;
            // 
            // botaoArredond1
            // 
            botaoArredond1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            botaoArredond1.BackColor = Color.Teal;
            botaoArredond1.Cursor = Cursors.Hand;
            botaoArredond1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond1.ForeColor = SystemColors.Control;
            botaoArredond1.Location = new Point(663, 34);
            botaoArredond1.Name = "botaoArredond1";
            botaoArredond1.RaioCanto = 20;
            botaoArredond1.Size = new Size(159, 27);
            botaoArredond1.TabIndex = 44;
            botaoArredond1.Text = "Modelos Mensagens";
            botaoArredond1.UseVisualStyleBackColor = false;
            botaoArredond1.Click += botaoArredond1_Click;
            // 
            // Frm_CadastroAcoesBoletos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(834, 487);
            Controls.Add(botaoArredond1);
            Controls.Add(Chbox_EmailEmHTML);
            Controls.Add(Check_EnviarPDFPorEmail);
            Controls.Add(TBC_Dados);
            Controls.Add(Btn_VariaveisBoleto);
            Controls.Add(Check_EnviarPDFPorWhats);
            Controls.Add(label1);
            Controls.Add(Txt_Nome);
            Controls.Add(Txt_Id);
            Controls.Add(Lbl_Id);
            Controls.Add(Btn_Salvar);
            Controls.Add(Btn_Remover);
            Controls.Add(Lbl_MensagemEnvio);
            DoubleBuffered = true;
            MinimizeBox = false;
            MinimumSize = new Size(850, 526);
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
        private TextBox Txt_Nome;
        private Label label1;
        private CheckBox Check_EnviarPDFPorWhats;
        private ComponentesPerson.BotaoArredond Btn_VariaveisBoleto;
        private TabControl TBC_Dados;
        private CheckBox Check_EnviarPDFPorEmail;
        private CheckBox Chbox_EmailEmHTML;
        private ComponentesPerson.BotaoArredond botaoArredond1;
    }
}