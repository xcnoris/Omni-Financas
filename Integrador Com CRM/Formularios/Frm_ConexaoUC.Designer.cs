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
            components = new System.ComponentModel.Container();
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
            Btn_TestarConexao = new ComponentesPerson.BotaoArredond(components);
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.Location = new Point(52, 64);
            label1.Name = "label1";
            label1.Size = new Size(63, 17);
            label1.TabIndex = 1;
            label1.Text = "Servidor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(52, 95);
            label2.Name = "label2";
            label2.Size = new Size(57, 17);
            label2.TabIndex = 2;
            label2.Text = "IP/Host:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 127);
            label3.Name = "label3";
            label3.Size = new Size(67, 17);
            label3.TabIndex = 3;
            label3.Text = "Database:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.Location = new Point(56, 158);
            label4.Name = "label4";
            label4.Size = new Size(57, 17);
            label4.TabIndex = 4;
            label4.Text = "Usuário:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.Location = new Point(56, 189);
            label5.Name = "label5";
            label5.Size = new Size(48, 17);
            label5.TabIndex = 5;
            label5.Text = "Senha:";
            // 
            // Txt_Servidor
            // 
            Txt_Servidor.Location = new Point(137, 61);
            Txt_Servidor.Name = "Txt_Servidor";
            Txt_Servidor.Size = new Size(202, 25);
            Txt_Servidor.TabIndex = 1;
            // 
            // Txt_IpHost
            // 
            Txt_IpHost.Location = new Point(137, 92);
            Txt_IpHost.Name = "Txt_IpHost";
            Txt_IpHost.Size = new Size(202, 25);
            Txt_IpHost.TabIndex = 2;
            // 
            // Txt_Senha
            // 
            Txt_Senha.Location = new Point(137, 186);
            Txt_Senha.Name = "Txt_Senha";
            Txt_Senha.PasswordChar = '*';
            Txt_Senha.Size = new Size(202, 25);
            Txt_Senha.TabIndex = 5;
            // 
            // Txt_Usuario
            // 
            Txt_Usuario.Location = new Point(137, 155);
            Txt_Usuario.Name = "Txt_Usuario";
            Txt_Usuario.Size = new Size(202, 25);
            Txt_Usuario.TabIndex = 4;
            // 
            // Txt_DataBase
            // 
            Txt_DataBase.Location = new Point(137, 124);
            Txt_DataBase.Name = "Txt_DataBase";
            Txt_DataBase.Size = new Size(202, 25);
            Txt_DataBase.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(Btn_TestarConexao);
            groupBox1.Controls.Add(Txt_Servidor);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Txt_DataBase);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Txt_Usuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Txt_Senha);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Txt_IpHost);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(199, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(435, 309);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados Conexão";
            // 
            // Btn_TestarConexao
            // 
            Btn_TestarConexao.BackColor = Color.CadetBlue;
            Btn_TestarConexao.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_TestarConexao.ForeColor = SystemColors.ControlLightLight;
            Btn_TestarConexao.Location = new Point(137, 236);
            Btn_TestarConexao.Name = "Btn_TestarConexao";
            Btn_TestarConexao.RaioCanto = 20;
            Btn_TestarConexao.Size = new Size(202, 31);
            Btn_TestarConexao.TabIndex = 6;
            Btn_TestarConexao.Text = "Testar Conexão";
            Btn_TestarConexao.UseVisualStyleBackColor = false;
            Btn_TestarConexao.Click += Btn_TestarConexao_Click;
            // 
            // Frm_ConexaoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "Frm_ConexaoUC";
            Size = new Size(829, 421);
            Load += Frm_ConexaoUC_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
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
        private ComponentesPerson.BotaoArredond Btn_TestarConexao;
    }
}
