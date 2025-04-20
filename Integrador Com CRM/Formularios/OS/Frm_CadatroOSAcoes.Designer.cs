namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_CadatroOSAcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CadatroOSAcoes));
            label5 = new Label();
            label2 = new Label();
            Txt_Mensagem = new TextBox();
            Btn_Salvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_IdCategoria = new TextBox();
            label1 = new Label();
            Txt_Id = new TextBox();
            Btn_Variaveis = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(33, 93);
            label5.Name = "label5";
            label5.Size = new Size(112, 17);
            label5.TabIndex = 15;
            label5.Text = "Mensagem Ação:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(60, 62);
            label2.Name = "label2";
            label2.Size = new Size(85, 17);
            label2.TabIndex = 11;
            label2.Text = "Id Categoria:";
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.Location = new Point(33, 111);
            Txt_Mensagem.MaxLength = 3000;
            Txt_Mensagem.Multiline = true;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.ScrollBars = ScrollBars.Vertical;
            Txt_Mensagem.Size = new Size(394, 128);
            Txt_Mensagem.TabIndex = 2;
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(127, 260);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 18;
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
            Btn_Remover.Location = new Point(235, 260);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 17;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            Btn_Remover.MouseEnter += Btn_Remover_MouseEnter;
            Btn_Remover.MouseLeave += Btn_Remover_MouseLeave;
            // 
            // Txt_IdCategoria
            // 
            Txt_IdCategoria.Location = new Point(151, 61);
            Txt_IdCategoria.MaxLength = 10;
            Txt_IdCategoria.Name = "Txt_IdCategoria";
            Txt_IdCategoria.Size = new Size(114, 23);
            Txt_IdCategoria.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(121, 34);
            label1.Name = "label1";
            label1.Size = new Size(24, 17);
            label1.TabIndex = 19;
            label1.Text = "ID:";
            // 
            // Txt_Id
            // 
            Txt_Id.BackColor = Color.White;
            Txt_Id.Location = new Point(151, 28);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 21;
            // 
            // Btn_Variaveis
            // 
            Btn_Variaveis.BackColor = Color.Teal;
            Btn_Variaveis.Cursor = Cursors.Hand;
            Btn_Variaveis.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Variaveis.ForeColor = SystemColors.Control;
            Btn_Variaveis.Location = new Point(292, 57);
            Btn_Variaveis.Name = "Btn_Variaveis";
            Btn_Variaveis.RaioCanto = 20;
            Btn_Variaveis.Size = new Size(135, 27);
            Btn_Variaveis.TabIndex = 41;
            Btn_Variaveis.Text = "variáveis";
            Btn_Variaveis.UseVisualStyleBackColor = false;
            Btn_Variaveis.Click += Btn_Variaveis_Click;
            Btn_Variaveis.MouseEnter += Btn_Variaveis_MouseEnter;
            Btn_Variaveis.MouseLeave += Btn_Variaveis_MouseLeave;
            // 
            // Frm_CadatroOSAcoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(461, 298);
            Controls.Add(Btn_Variaveis);
            Controls.Add(Txt_Id);
            Controls.Add(Txt_IdCategoria);
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
            Name = "Frm_CadatroOSAcoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Ações OS";
            FormClosed += Frm_CadatroOSAcoes_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label2;
        private TextBox Txt_Mensagem;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private TextBox Txt_IdCategoria;
        private Label label1;
        private TextBox Txt_Id;
        private ComponentesPerson.BotaoArredond Btn_Variaveis;
    }
}