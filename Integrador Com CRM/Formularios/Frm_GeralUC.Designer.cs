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
            components = new System.ComponentModel.Container();
            Btn_BuscarOS = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_BuscarBoletos = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            SuspendLayout();
            // 
            // Btn_BuscarOS
            // 
            Btn_BuscarOS.BackColor = Color.Teal;
            Btn_BuscarOS.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_BuscarOS.ForeColor = SystemColors.Control;
            Btn_BuscarOS.Location = new Point(291, 124);
            Btn_BuscarOS.Name = "Btn_BuscarOS";
            Btn_BuscarOS.RaioCanto = 20;
            Btn_BuscarOS.Size = new Size(247, 64);
            Btn_BuscarOS.TabIndex = 3;
            Btn_BuscarOS.Text = "Consultar Ordem de Serviço";
            Btn_BuscarOS.UseVisualStyleBackColor = false;
            Btn_BuscarOS.Click += Btn_BuscarOS_Click;
            Btn_BuscarOS.MouseEnter += Btn_BuscarOS_MouseEnter;
            Btn_BuscarOS.MouseLeave += Btn_BuscarOS_MouseLeave;
            // 
            // Btn_BuscarBoletos
            // 
            Btn_BuscarBoletos.BackColor = Color.Teal;
            Btn_BuscarBoletos.Cursor = Cursors.Hand;
            Btn_BuscarBoletos.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_BuscarBoletos.ForeColor = SystemColors.Control;
            Btn_BuscarBoletos.Location = new Point(291, 209);
            Btn_BuscarBoletos.Name = "Btn_BuscarBoletos";
            Btn_BuscarBoletos.RaioCanto = 20;
            Btn_BuscarBoletos.Size = new Size(247, 64);
            Btn_BuscarBoletos.TabIndex = 4;
            Btn_BuscarBoletos.Text = "Consultar Boletos";
            Btn_BuscarBoletos.UseVisualStyleBackColor = false;
            Btn_BuscarBoletos.Click += Btn_BuscarBoletos_Click;
            Btn_BuscarBoletos.MouseEnter += Btn_BuscarBoletos_MouseEnter;
            Btn_BuscarBoletos.MouseLeave += Btn_BuscarBoletos_MouseLeave;
            // 
            // Frm_GeralUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Btn_BuscarBoletos);
            Controls.Add(Btn_BuscarOS);
            DoubleBuffered = true;
            Name = "Frm_GeralUC";
            Size = new Size(829, 421);
            ResumeLayout(false);
        }

        #endregion
        private ComponentesPerson.BotaoArredond Btn_BuscarOS;
        private ComponentesPerson.BotaoArredond Btn_BuscarBoletos;
    }
}
