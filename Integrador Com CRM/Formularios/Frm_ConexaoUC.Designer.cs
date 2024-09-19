namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_ConexaoUC
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
            Btn_TestarConexao = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Txt_Servidor = new TextBox();
            Txt_IpHost = new TextBox();
            Txt_Senha = new TextBox();
            Txt_Usuario = new TextBox();
            Txt_DataBase = new TextBox();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_TestarConexao
            // 
            Btn_TestarConexao.Location = new Point(163, 244);
            Btn_TestarConexao.Name = "Btn_TestarConexao";
            Btn_TestarConexao.Size = new Size(149, 23);
            Btn_TestarConexao.TabIndex = 0;
            Btn_TestarConexao.Text = "Testar Conexão";
            Btn_TestarConexao.UseVisualStyleBackColor = true;
            Btn_TestarConexao.Click += Btn_TestarConexao_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 66);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Servidor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 95);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "IP/HOST";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 131);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "DataBase";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 168);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 4;
            label4.Text = "usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(56, 202);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Senha";
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Location = new Point(137, 63);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(202, 23);
            Txt_Servidor.TabIndex = 6;
            // 
            // Txt_IpHost
            // 
            Txt_IpHost.Location = new Point(137, 92);
            Txt_IpHost.Name = "Txt_IpHost";
            Txt_IpHost.Size = new Size(202, 23);
            Txt_IpHost.TabIndex = 7;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(137, 199);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.Size = new Size(202, 23);
            Txt_Senha.TabIndex = 8;
            // 
            // Txt_Usuario
            // 
            Txt_Usuario.Location = new Point(137, 165);
            Txt_Usuario.Name = "Txt_Usuario";
            Txt_Usuario.Size = new Size(202, 23);
            Txt_Usuario.TabIndex = 9;
            // 
            // Txt_DataBase
            // 
            Txt_DataBase.Location = new Point(137, 128);
            Txt_DataBase.Name = "Txt_DataBase";
            Txt_DataBase.Size = new Size(202, 23);
            Txt_DataBase.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Txt_Servidor);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Btn_TestarConexao);
            groupBox1.Controls.Add(Txt_DataBase);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_Usuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Txt_Senha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Txt_IpHost);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(215, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(434, 309);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados Conexão";
            // 
            // Frm_ConexaoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(groupBox1);
            Name = "Frm_ConexaoUC";
            Size = new Size(829, 421);
            Load += Frm_ConexaoUC_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_TestarConexao;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox Txt_Servidor;
        private TextBox Txt_IpHost;
        private TextBox Txt_Senha;
        private TextBox Txt_Usuario;
        private TextBox Txt_DataBase;
        private GroupBox groupBox1;
    }
}
