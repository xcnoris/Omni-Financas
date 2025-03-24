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
            Txt_NomeInstancia = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Txt_Token
            // 
            Txt_Token.Location = new Point(111, 34);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(355, 23);
            Txt_Token.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Token API:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(Txt_NomeInstancia);
            groupBox1.Controls.Add(label2);
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
            // Txt_NomeInstancia
            // 
            Txt_NomeInstancia.Location = new Point(111, 73);
            Txt_NomeInstancia.Name = "Txt_NomeInstancia";
            Txt_NomeInstancia.Size = new Size(355, 23);
            Txt_NomeInstancia.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 3;
            label2.Text = "Nome Instancia:";
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox Txt_Token;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox Txt_NomeInstancia;
        private Label label2;
    }
}
