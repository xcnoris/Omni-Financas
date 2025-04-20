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
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Incluir = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
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
            DGV_Dados.Size = new Size(790, 270);
            DGV_Dados.TabIndex = 0;
            DGV_Dados.DoubleClick += DGV_Dados_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(66, 16);
            label1.Name = "label1";
            label1.Size = new Size(672, 46);
            label1.TabIndex = 1;
            label1.Text = "Defina as Categorias e codigos das Ações";
            // 
            // Btn_Remover
            // 
            Btn_Remover.BackColor = Color.DarkGray;
            Btn_Remover.Cursor = Cursors.Hand;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(132, 341);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(95, 33);
            Btn_Remover.TabIndex = 13;
            Btn_Remover.Text = "Remover";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            Btn_Remover.MouseEnter += Btn_Remover_MouseEnter;
            Btn_Remover.MouseLeave += Btn_Remover_MouseLeave;
            // 
            // Btn_Incluir
            // 
            Btn_Incluir.BackColor = Color.Teal;
            Btn_Incluir.Cursor = Cursors.Hand;
            Btn_Incluir.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Incluir.ForeColor = Color.White;
            Btn_Incluir.Location = new Point(21, 341);
            Btn_Incluir.Name = "Btn_Incluir";
            Btn_Incluir.RaioCanto = 20;
            Btn_Incluir.Size = new Size(105, 33);
            Btn_Incluir.TabIndex = 19;
            Btn_Incluir.Text = "Incluir";
            Btn_Incluir.UseVisualStyleBackColor = false;
            Btn_Incluir.Click += Btn_Incluir_Click;
            Btn_Incluir.MouseEnter += Btn_Incluir_MouseEnter;
            Btn_Incluir.MouseLeave += Btn_Incluir_MouseLeave;
            // 
            // Frm_OSAcoesCRM_UC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
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
