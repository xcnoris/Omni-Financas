namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_OSAcoesCRM_UC
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
            DGV_Dados = new DataGridView();
            label1 = new Label();
            Btn_Remover = new ComponentesPerson.BotaoArredond(components);
            Btn_Incluir = new ComponentesPerson.BotaoArredond(components);
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).BeginInit();
            SuspendLayout();
            // 
            // DGV_Dados
            // 
            DGV_Dados.AllowUserToAddRows = false;
            DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Dados.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Dados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Dados.Location = new Point(21, 65);
            DGV_Dados.Name = "DGV_Dados";
            DGV_Dados.Size = new Size(790, 320);
            DGV_Dados.TabIndex = 0;
            DGV_Dados.DoubleClick += DGV_Dados_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.MediumSlateBlue;
            label1.Location = new Point(183, 12);
            label1.Name = "label1";
            label1.Size = new Size(415, 30);
            label1.TabIndex = 1;
            label1.Text = "Defina as Categorias e codigos das Ações";
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.Tomato;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(736, 392);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(75, 23);
            Btn_Remover.TabIndex = 13;
            Btn_Remover.Text = "Remover";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            // 
            // Btn_Incluir
            // 
            Btn_Incluir.BackColor = Color.LimeGreen;
            Btn_Incluir.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Incluir.ForeColor = Color.White;
            Btn_Incluir.Location = new Point(655, 391);
            Btn_Incluir.Name = "Btn_Incluir";
            Btn_Incluir.RaioCanto = 20;
            Btn_Incluir.Size = new Size(75, 23);
            Btn_Incluir.TabIndex = 19;
            Btn_Incluir.Text = "Incluir";
            Btn_Incluir.UseVisualStyleBackColor = false;
            Btn_Incluir.Click += Btn_Incluir_Click;
            // 
            // Frm_OSAcoesCRM_UC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Btn_Incluir);
            Controls.Add(Btn_Remover);
            Controls.Add(label1);
            Controls.Add(DGV_Dados);
            DoubleBuffered = true;
            Name = "Frm_OSAcoesCRM_UC";
            Size = new Size(829, 421);
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Dados;
        private Label label1;
        private Button Btn_Add;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private ComponentesPerson.BotaoArredond Btn_Incluir;
    }
}
