namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_DadosAPIUC
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
            Txt_Token = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            Txt_CodJornadaOS = new TextBox();
            label3 = new Label();
            Txt_CodAPIOS = new TextBox();
            label4 = new Label();
            groupBox3 = new GroupBox();
            Txt_CodJornadaBoleto = new TextBox();
            label2 = new Label();
            Txt_CodAPIBoleto = new TextBox();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // Txt_Token
            // 
            Txt_Token.Location = new Point(59, 34);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(490, 23);
            Txt_Token.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "Token:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(Txt_Token);
            groupBox1.Controls.Add(label1);
            groupBox1.ForeColor = SystemColors.HotTrack;
            groupBox1.Location = new Point(143, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 318);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados API";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(Txt_CodJornadaOS);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(Txt_CodAPIOS);
            groupBox2.Controls.Add(label4);
            groupBox2.ForeColor = SystemColors.HotTrack;
            groupBox2.Location = new Point(12, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(537, 87);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Config. Ordem de Serviço";
            // 
            // Txt_CodJornadaOS
            // 
            Txt_CodJornadaOS.Location = new Point(360, 42);
            Txt_CodJornadaOS.Name = "Txt_CodJornadaOS";
            Txt_CodJornadaOS.Size = new Size(158, 23);
            Txt_CodJornadaOS.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(261, 45);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 3;
            label3.Text = "Codigo Jornada:";
            // 
            // Txt_CodAPIOS
            // 
            Txt_CodAPIOS.Location = new Point(84, 40);
            Txt_CodAPIOS.Name = "Txt_CodAPIOS";
            Txt_CodAPIOS.Size = new Size(158, 23);
            Txt_CodAPIOS.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Desktop;
            label4.Location = new Point(8, 43);
            label4.Name = "label4";
            label4.Size = new Size(70, 15);
            label4.TabIndex = 1;
            label4.Text = "Codigo API:";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Txt_CodJornadaBoleto);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(Txt_CodAPIBoleto);
            groupBox3.Controls.Add(label5);
            groupBox3.ForeColor = SystemColors.HotTrack;
            groupBox3.Location = new Point(12, 184);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(537, 87);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Config. Boleto";
            // 
            // Txt_CodJornadaBoleto
            // 
            Txt_CodJornadaBoleto.Location = new Point(360, 42);
            Txt_CodJornadaBoleto.Name = "Txt_CodJornadaBoleto";
            Txt_CodJornadaBoleto.Size = new Size(158, 23);
            Txt_CodJornadaBoleto.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(261, 50);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Codigo Jornada:";
            // 
            // Txt_CodAPIBoleto
            // 
            Txt_CodAPIBoleto.Location = new Point(84, 42);
            Txt_CodAPIBoleto.Name = "Txt_CodAPIBoleto";
            Txt_CodAPIBoleto.Size = new Size(158, 23);
            Txt_CodAPIBoleto.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(8, 45);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 1;
            label5.Text = "Codigo API:";
            // 
            // Frm_DadosAPIUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "Frm_DadosAPIUC";
            Size = new Size(829, 421);
            Load += Frm_DadosAPIUC_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox Txt_Token;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox Txt_CodJornadaOS;
        private Label label3;
        private TextBox Txt_CodAPIOS;
        private Label label4;
        private GroupBox groupBox3;
        private TextBox Txt_CodJornadaBoleto;
        private Label label2;
        private TextBox Txt_CodAPIBoleto;
        private Label label5;
    }
}
