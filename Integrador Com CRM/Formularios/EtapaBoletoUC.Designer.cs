namespace CDI_OminiService.Formularios
{
    partial class FrmEtapaBoletoUC
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
            groupBox3 = new GroupBox();
            Btn_BuscarBoletos = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            label1 = new Label();
            Cbox_DiaCobranca = new ComboBox();
            DGV_Dados = new DataGridView();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Cbox_DiaCobranca);
            groupBox3.Controls.Add(Btn_BuscarBoletos);
            groupBox3.Controls.Add(label1);
            groupBox3.ForeColor = Color.Black;
            groupBox3.Location = new Point(38, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(745, 78);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtro";
            // 
            // Btn_BuscarBoletos
            // 
            Btn_BuscarBoletos.BackColor = Color.Teal;
            Btn_BuscarBoletos.Cursor = Cursors.Hand;
            Btn_BuscarBoletos.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Btn_BuscarBoletos.ForeColor = SystemColors.Control;
            Btn_BuscarBoletos.Location = new Point(590, 32);
            Btn_BuscarBoletos.Name = "Btn_BuscarBoletos";
            Btn_BuscarBoletos.RaioCanto = 20;
            Btn_BuscarBoletos.Size = new Size(128, 27);
            Btn_BuscarBoletos.TabIndex = 5;
            Btn_BuscarBoletos.Text = "Buscar Boletos";
            Btn_BuscarBoletos.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(19, 36);
            label1.Name = "label1";
            label1.Size = new Size(89, 17);
            label1.TabIndex = 1;
            label1.Text = "Dia cobrança:";
            // 
            // Cbox_DiaCobranca
            // 
            Cbox_DiaCobranca.FormattingEnabled = true;
            Cbox_DiaCobranca.Location = new Point(114, 35);
            Cbox_DiaCobranca.Name = "Cbox_DiaCobranca";
            Cbox_DiaCobranca.Size = new Size(121, 23);
            Cbox_DiaCobranca.TabIndex = 6;
            // 
            // DGV_Dados
            // 
            DGV_Dados.AllowUserToAddRows = false;
            DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Dados.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Dados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Dados.Location = new Point(19, 102);
            DGV_Dados.Name = "DGV_Dados";
            DGV_Dados.Size = new Size(790, 243);
            DGV_Dados.TabIndex = 3;
            // 
            // EtapaBoletoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_2;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(DGV_Dados);
            Controls.Add(groupBox3);
            Name = "EtapaBoletoUC";
            Size = new Size(829, 421);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private ComboBox Cbox_DiaCobranca;
        private Integrador_Com_CRM.ComponentesPerson.BotaoArredond Btn_BuscarBoletos;
        private Label label1;
        private DataGridView DGV_Dados;
    }
}
