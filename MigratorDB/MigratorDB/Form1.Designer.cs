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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            Btn_TEstar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_Servidor = new TextBox();
            Btn_SalvarConexao = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            label1 = new Label();
            Txt_DataBase = new TextBox();
            label2 = new Label();
            Txt_Usuario = new TextBox();
            label3 = new Label();
            Txt_Senha = new TextBox();
            label4 = new Label();
            Txt_IpHost = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            Btn_CriarDataBase = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(Btn_TEstar);
            groupBox1.Controls.Add(Txt_Servidor);
            groupBox1.Controls.Add(Btn_SalvarConexao);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Txt_DataBase);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_Usuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Txt_Senha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Txt_IpHost);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(62, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(409, 255);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados Conexão";
            // 
            // Btn_TEstar
            // 
            Btn_TEstar.BackColor = Color.CadetBlue;
            Btn_TEstar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Btn_TEstar.ForeColor = Color.White;
            Btn_TEstar.Location = new Point(114, 206);
            Btn_TEstar.Name = "Btn_TEstar";
            Btn_TEstar.RaioCanto = 20;
            Btn_TEstar.Size = new Size(108, 30);
            Btn_TEstar.TabIndex = 16;
            Btn_TEstar.Text = "Testar Conexão";
            Btn_TEstar.UseVisualStyleBackColor = false;
            Btn_TEstar.Click += Btn_TEstar_Click;
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Location = new Point(114, 33);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(237, 27);
            Txt_Servidor.TabIndex = 6;
            // 
            // Btn_SalvarConexao
            // 
            Btn_SalvarConexao.BackColor = Color.CadetBlue;
            Btn_SalvarConexao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Btn_SalvarConexao.ForeColor = Color.White;
            Btn_SalvarConexao.Location = new Point(240, 206);
            Btn_SalvarConexao.Name = "Btn_SalvarConexao";
            Btn_SalvarConexao.RaioCanto = 20;
            Btn_SalvarConexao.Size = new Size(111, 30);
            Btn_SalvarConexao.TabIndex = 15;
            Btn_SalvarConexao.Text = "Salvar Conexão";
            Btn_SalvarConexao.UseVisualStyleBackColor = false;
            Btn_SalvarConexao.Click += Btn_SalvarConexao_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 36);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 1;
            label1.Text = "Servidor";
            // 
            // Txt_DataBase
            // 
            Txt_DataBase.Location = new Point(114, 99);
            Txt_DataBase.Name = "Txt_DataBase";
            Txt_DataBase.Size = new Size(237, 27);
            Txt_DataBase.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 69);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 2;
            label2.Text = "IP/HOST";
            // 
            // Txt_Usuario
            // 
            Txt_Usuario.Location = new Point(114, 132);
            Txt_Usuario.Name = "Txt_Usuario";
            Txt_Usuario.Size = new Size(237, 27);
            Txt_Usuario.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 102);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "DataBase";
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(114, 165);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.Size = new Size(237, 27);
            Txt_Senha.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 135);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 4;
            label4.Text = "Usuario";
            // 
            // Txt_IpHost
            // 
            Txt_IpHost.Location = new Point(114, 66);
            Txt_IpHost.Name = "Txt_IpHost";
            Txt_IpHost.Size = new Size(237, 27);
            Txt_IpHost.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 168);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 5;
            label5.Text = "Senha";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(Btn_CriarDataBase);
            groupBox2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(62, 273);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(409, 88);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Banco de Dados";
            // 
            // Btn_CriarDataBase
            // 
            Btn_CriarDataBase.BackColor = Color.CadetBlue;
            Btn_CriarDataBase.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Btn_CriarDataBase.ForeColor = Color.White;
            Btn_CriarDataBase.Location = new Point(114, 37);
            Btn_CriarDataBase.Name = "Btn_CriarDataBase";
            Btn_CriarDataBase.RaioCanto = 20;
            Btn_CriarDataBase.Size = new Size(190, 30);
            Btn_CriarDataBase.TabIndex = 16;
            Btn_CriarDataBase.Text = "Criar Banco de Dados";
            Btn_CriarDataBase.UseVisualStyleBackColor = false;
            Btn_CriarDataBase.Click += Btn_CriarDataBase_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(553, 390);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CDI MigratoDB";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox Txt_Servidor;
        private Label label1;
        private TextBox Txt_DataBase;
        private Label label2;
        private TextBox Txt_Usuario;
        private Label label3;
        private TextBox Txt_Senha;
        private Label label4;
        private TextBox Txt_IpHost;
        private Label label5;
        private GroupBox groupBox2;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_TEstar;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_SalvarConexao;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_CriarDataBase;
    }
}
