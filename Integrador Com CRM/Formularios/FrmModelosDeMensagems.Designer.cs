namespace CDI_OminiService.Formularios
{
    partial class FrmModelosDeMensagems
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
            label13 = new Label();
            label1 = new Label();
            Txt_CobranBOl = new TextBox();
            Txt_CriacaoBolHTML = new TextBox();
            SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Teal;
            label13.Location = new Point(32, 9);
            label13.Name = "label13";
            label13.Size = new Size(166, 22);
            label13.TabIndex = 9;
            label13.Text = "Cobrança Boleto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(32, 140);
            label1.Name = "label1";
            label1.Size = new Size(318, 22);
            label1.TabIndex = 10;
            label1.Text = "Modelo Em HTML - Criação Email";
            // 
            // Txt_CobranBOl
            // 
            Txt_CobranBOl.Location = new Point(32, 34);
            Txt_CobranBOl.Multiline = true;
            Txt_CobranBOl.Name = "Txt_CobranBOl";
            Txt_CobranBOl.ReadOnly = true;
            Txt_CobranBOl.ScrollBars = ScrollBars.Both;
            Txt_CobranBOl.Size = new Size(893, 93);
            Txt_CobranBOl.TabIndex = 11;
            // 
            // Txt_CriacaoBolHTML
            // 
            Txt_CriacaoBolHTML.Location = new Point(32, 165);
            Txt_CriacaoBolHTML.Multiline = true;
            Txt_CriacaoBolHTML.Name = "Txt_CriacaoBolHTML";
            Txt_CriacaoBolHTML.ReadOnly = true;
            Txt_CriacaoBolHTML.ScrollBars = ScrollBars.Both;
            Txt_CriacaoBolHTML.Size = new Size(893, 93);
            Txt_CriacaoBolHTML.TabIndex = 12;
            // 
            // FrmModelosDeMensagems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(958, 450);
            Controls.Add(Txt_CriacaoBolHTML);
            Controls.Add(Txt_CobranBOl);
            Controls.Add(label1);
            Controls.Add(label13);
            MaximizeBox = false;
            MaximumSize = new Size(974, 489);
            MinimizeBox = false;
            MinimumSize = new Size(974, 489);
            Name = "FrmModelosDeMensagems";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modelos de Mensagens";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label13;
        private Label label1;
        private TextBox Txt_CobranBOl;
        private TextBox Txt_CriacaoBolHTML;
    }
}