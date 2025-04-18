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
            Txt_Token.Location = new Point(127, 39);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(405, 25);
            Txt_Token.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(14, 42);
            label1.Name = "label1";
            label1.Size = new Size(72, 17);
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
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(105, 105);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(611, 145);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dados API";
            // 
            // Txt_NomeInstancia
            // 
            Txt_NomeInstancia.Location = new Point(127, 83);
            Txt_NomeInstancia.Name = "Txt_NomeInstancia";
            Txt_NomeInstancia.Size = new Size(405, 25);
            Txt_NomeInstancia.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(14, 86);
            label2.Name = "label2";
            label2.Size = new Size(106, 17);
            label2.TabIndex = 3;
            label2.Text = "Nome Instancia:";
            // 
            // Frm_DadosAPIUC
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            ForeColor = Color.White;
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
