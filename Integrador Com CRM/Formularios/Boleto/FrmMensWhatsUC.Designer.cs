namespace CDI_OminiService.Formularios.Boleto
{
    partial class FrmMensWhatsUC
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
            Txt_MensWhats = new TextBox();
            SuspendLayout();
            // 
            // Txt_MensWhats
            // 
            Txt_MensWhats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Txt_MensWhats.Location = new Point(-3, 0);
            Txt_MensWhats.MaxLength = 3000;
            Txt_MensWhats.Multiline = true;
            Txt_MensWhats.Name = "Txt_MensWhats";
            Txt_MensWhats.ScrollBars = ScrollBars.Vertical;
            Txt_MensWhats.Size = new Size(810, 298);
            Txt_MensWhats.TabIndex = 4;
            // 
            // FrmMensWhatsUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Txt_MensWhats);
            Name = "FrmMensWhatsUC";
            Size = new Size(810, 298);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_MensWhats;
    }
}
