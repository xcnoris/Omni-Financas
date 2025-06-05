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
            Btn_Salvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_Mensagem = new TextBox();
            label5 = new Label();
            label2 = new Label();
            Btn_Variaveis = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            SuspendLayout();
            // 
            // Txt_Id
            // 
            Txt_Id.Location = new Point(84, 19);
            Txt_Id.MaxLength = 10;
            Txt_Id.Name = "Txt_Id";
            Txt_Id.ReadOnly = true;
            Txt_Id.Size = new Size(83, 23);
            Txt_Id.TabIndex = 29;
            // 
            // Txt_Nome
            // 
            Txt_Nome.BackColor = Color.White;
            Txt_Nome.Location = new Point(84, 53);
            Txt_Nome.MaxLength = 10;
            Txt_Nome.Name = "Txt_Nome";
            Txt_Nome.Size = new Size(149, 23);
            Txt_Nome.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(35, 22);
            label1.Name = "label1";
            label1.Size = new Size(23, 15);
            label1.TabIndex = 27;
            label1.Text = "ID:";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(317, 440);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(102, 23);
            Btn_Salvar.TabIndex = 26;
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
            Btn_Remover.Location = new Point(425, 440);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(102, 23);
            Btn_Remover.TabIndex = 25;
            Btn_Remover.Text = "Fechar";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            Btn_Remover.MouseEnter += Btn_Remover_MouseEnter;
            Btn_Remover.MouseLeave += Btn_Remover_MouseLeave;
            // 
            // Txt_Mensagem
            // 
            Txt_Mensagem.BackColor = Color.WhiteSmoke;
            Txt_Mensagem.Location = new Point(12, 105);
            Txt_Mensagem.MaxLength = 3000;
            Txt_Mensagem.Multiline = true;
            Txt_Mensagem.Name = "Txt_Mensagem";
            Txt_Mensagem.Size = new Size(810, 314);
            Txt_Mensagem.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
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
            label2.ForeColor = Color.Black;
            label2.Location = new Point(35, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 22;
            label2.Text = "Nome:";
            // 
            // Btn_Variaveis
            // 
            Btn_Variaveis.BackColor = Color.Teal;
            Btn_Variaveis.Cursor = Cursors.Hand;
            Btn_Variaveis.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Variaveis.ForeColor = SystemColors.Control;
            Btn_Variaveis.Location = new Point(687, 56);
            Btn_Variaveis.Name = "Btn_Variaveis";
            Btn_Variaveis.RaioCanto = 20;
            Btn_Variaveis.Size = new Size(135, 27);
            Btn_Variaveis.TabIndex = 41;
            Btn_Variaveis.Text = "Variáveis";
            Btn_Variaveis.UseVisualStyleBackColor = false;
            Btn_Variaveis.Click += Btn_Variaveis_Click;
            Btn_Variaveis.MouseEnter += Btn_Variaveis_MouseEnter;
            Btn_Variaveis.MouseLeave += Btn_Variaveis_MouseLeave;
            // 
            // Frm_CadastroSituacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(834, 487);
            Controls.Add(Btn_Variaveis);
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
            MaximumSize = new Size(850, 526);
            MinimizeBox = false;
            MinimumSize = new Size(850, 526);
            Name = "Frm_CadastroSituacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Casdatro Situacões";
            FormClosed += Frm_CadastroSituacoes_FormClosed;
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
        private ComponentesPerson.BotaoArredond Btn_Variaveis;
    }
}