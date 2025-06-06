namespace CDI_OminiService.Formularios
{
    partial class FrmConfigEmail
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            Txt_Server = new TextBox();
            label1 = new Label();
            Txt_Email = new TextBox();
            label2 = new Label();
            label3 = new Label();
            Txt_Senha = new TextBox();
            Txt_Port = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(Txt_Server);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Txt_Email);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Txt_Senha);
            groupBox1.Controls.Add(Txt_Port);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(174, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(480, 223);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuração Conta Email";
            // 
            // Txt_Server
            // 
            Txt_Server.Location = new Point(147, 56);
            Txt_Server.Name = "Txt_Server";
            Txt_Server.Size = new Size(202, 25);
            Txt_Server.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(52, 64);
            label1.Name = "label1";
            label1.Size = new Size(89, 17);
            label1.TabIndex = 1;
            label1.Text = "SMTP Server:";
            // 
            // Txt_Email
            // 
            Txt_Email.Location = new Point(147, 118);
            Txt_Email.Name = "Txt_Email";
            Txt_Email.Size = new Size(262, 25);
            Txt_Email.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(52, 95);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 2;
            label2.Text = "SMTP Port:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(52, 127);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 3;
            label3.Text = "Email:";
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(147, 153);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.Size = new Size(202, 25);
            Txt_Senha.TabIndex = 5;
            // 
            // Txt_Port
            // 
            Txt_Port.Location = new Point(147, 87);
            Txt_Port.Name = "Txt_Port";
            Txt_Port.Size = new Size(92, 25);
            Txt_Port.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(52, 156);
            label5.Name = "label5";
            label5.Size = new Size(48, 17);
            label5.TabIndex = 5;
            label5.Text = "Senha:";
            // 
            // FrmConfigEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_2;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            Name = "FrmConfigEmail";
            Size = new Size(829, 421);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox Txt_Server;
        private Label label1;
        private TextBox Txt_Email;
        private Label label2;
        private Label label3;
        private TextBox Txt_Senha;
        private TextBox Txt_Port;
        private Label label5;
    }
}
