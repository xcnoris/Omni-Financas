namespace MigratorDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            Btn_Salvar = new Button();
            Txt_Servidor = new TextBox();
            label1 = new Label();
            Btn_TestarConexao = new Button();
            Txt_DataBase = new TextBox();
            label2 = new Label();
            Txt_Usuario = new TextBox();
            label3 = new Label();
            Txt_Senha = new TextBox();
            label4 = new Label();
            Txt_IpHost = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            Btn_CriarDB = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Btn_Salvar);
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
            groupBox1.Location = new Point(38, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 255);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados Conexão";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Salvar.Location = new Point(204, 198);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.Size = new Size(112, 38);
            Btn_Salvar.TabIndex = 11;
            Btn_Salvar.Text = "Salvar Conexão";
            Btn_Salvar.UseVisualStyleBackColor = true;
            Btn_Salvar.Click += Btn_Salvar_Click;
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Location = new Point(114, 33);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(202, 23);
            Txt_Servidor.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 36);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Servidor";
            // 
            // Btn_TestarConexao
            // 
            Btn_TestarConexao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_TestarConexao.Location = new Point(33, 198);
            Btn_TestarConexao.Name = "Btn_TestarConexao";
            Btn_TestarConexao.Size = new Size(117, 38);
            Btn_TestarConexao.TabIndex = 0;
            Btn_TestarConexao.Text = "Testar Conexão";
            Btn_TestarConexao.UseVisualStyleBackColor = true;
            Btn_TestarConexao.Click += Btn_TestarConexao_Click;
            // 
            // Txt_DataBase
            // 
            Txt_DataBase.Location = new Point(114, 98);
            Txt_DataBase.Name = "Txt_DataBase";
            Txt_DataBase.Size = new Size(202, 23);
            Txt_DataBase.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 65);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "IP/HOST";
            // 
            // Txt_Usuario
            // 
            Txt_Usuario.Location = new Point(114, 135);
            Txt_Usuario.Name = "Txt_Usuario";
            Txt_Usuario.Size = new Size(202, 23);
            Txt_Usuario.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 101);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "DataBase";
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(114, 169);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.Size = new Size(202, 23);
            Txt_Senha.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 138);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 4;
            label4.Text = "usuario";
            // 
            // Txt_IpHost
            // 
            Txt_IpHost.Location = new Point(114, 62);
            Txt_IpHost.Name = "Txt_IpHost";
            Txt_IpHost.Size = new Size(202, 23);
            Txt_IpHost.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 172);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 5;
            label5.Text = "Senha";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Btn_CriarDB);
            groupBox2.Location = new Point(431, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 96);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Banco de Dados";
            // 
            // Btn_CriarDB
            // 
            Btn_CriarDB.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_CriarDB.Location = new Point(46, 33);
            Btn_CriarDB.Name = "Btn_CriarDB";
            Btn_CriarDB.Size = new Size(112, 44);
            Btn_CriarDB.TabIndex = 12;
            Btn_CriarDB.Text = "Criar Banco de Dados";
            Btn_CriarDB.UseVisualStyleBackColor = true;
            Btn_CriarDB.Click += Btn_CriarDB_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 288);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button Btn_Salvar;
        private TextBox Txt_Servidor;
        private Label label1;
        private Button Btn_TestarConexao;
        private TextBox Txt_DataBase;
        private Label label2;
        private TextBox Txt_Usuario;
        private Label label3;
        private TextBox Txt_Senha;
        private Label label4;
        private TextBox Txt_IpHost;
        private Label label5;
        private GroupBox groupBox2;
        private Button Btn_CriarDB;
    }
}
