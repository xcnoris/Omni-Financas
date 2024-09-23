namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_GeralUC
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
            Btn_BuscarBoletos = new Button();
            Btn_BuscarOS = new Button();
            Btn_RealizarCobrancas = new Button();
            SuspendLayout();
            // 
            // Btn_BuscarBoletos
            // 
            Btn_BuscarBoletos.Location = new Point(266, 169);
            Btn_BuscarBoletos.Name = "Btn_BuscarBoletos";
            Btn_BuscarBoletos.Size = new Size(247, 66);
            Btn_BuscarBoletos.TabIndex = 0;
            Btn_BuscarBoletos.Text = "Consultar Boletos";
            Btn_BuscarBoletos.UseVisualStyleBackColor = true;
            Btn_BuscarBoletos.Click += Btn_BuscarBoletos_Click;
            // 
            // Btn_BuscarOS
            // 
            Btn_BuscarOS.Location = new Point(266, 82);
            Btn_BuscarOS.Name = "Btn_BuscarOS";
            Btn_BuscarOS.Size = new Size(247, 64);
            Btn_BuscarOS.TabIndex = 1;
            Btn_BuscarOS.Text = "Consultar Ordem de Serviço";
            Btn_BuscarOS.UseVisualStyleBackColor = true;
            Btn_BuscarOS.Click += Btn_BuscarOS_Click;
            // 
            // Btn_RealizarCobrancas
            // 
            Btn_RealizarCobrancas.Location = new Point(266, 256);
            Btn_RealizarCobrancas.Name = "Btn_RealizarCobrancas";
            Btn_RealizarCobrancas.Size = new Size(247, 66);
            Btn_RealizarCobrancas.TabIndex = 2;
            Btn_RealizarCobrancas.Text = "Realizar Cobranças";
            Btn_RealizarCobrancas.UseVisualStyleBackColor = true;
            Btn_RealizarCobrancas.Click += Btn_RealizarCobrancas_Click;
            // 
            // Frm_GeralUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Btn_RealizarCobrancas);
            Controls.Add(Btn_BuscarOS);
            Controls.Add(Btn_BuscarBoletos);
            DoubleBuffered = true;
            Name = "Frm_GeralUC";
            Size = new Size(829, 421);
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_BuscarBoletos;
        private Button Btn_BuscarOS;
        private Button Btn_RealizarCobrancas;
    }
}
