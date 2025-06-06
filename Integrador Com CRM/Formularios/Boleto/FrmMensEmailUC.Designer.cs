namespace CDI_OminiService.Formularios.Boleto
{
    partial class FrmMensEmailUC
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
            Txt_MensEmail = new TextBox();
            SuspendLayout();
            // 
            // Txt_MensEmail
            // 
            Txt_MensEmail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Txt_MensEmail.Location = new Point(0, 0);
            Txt_MensEmail.MaxLength = 3000;
            Txt_MensEmail.Multiline = true;
            Txt_MensEmail.Name = "Txt_MensEmail";
            Txt_MensEmail.ScrollBars = ScrollBars.Vertical;
            Txt_MensEmail.Size = new Size(810, 298);
            Txt_MensEmail.TabIndex = 5;
            Txt_MensEmail.TextChanged += Txt_MensEmail_TextChanged;
            // 
            // FrmMensEmailUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Txt_MensEmail);
            Name = "FrmMensEmailUC";
            Size = new Size(810, 298);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_MensEmail;
    }
}
