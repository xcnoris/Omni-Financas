namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_BoletoAcoesCRM_UC
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
            CheckBox = new DataGridViewCheckBoxColumn();
            ChboxPDFEmail = new DataGridViewCheckBoxColumn();
            ChboxEmailHTML = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            Btn_Salvar = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Remover = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).BeginInit();
            SuspendLayout();
            // 
            // DGV_Dados
            // 
            DGV_Dados.AllowUserToAddRows = false;
            DGV_Dados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DGV_Dados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Dados.BackgroundColor = SystemColors.ControlLightLight;
            DGV_Dados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Dados.Columns.AddRange(new DataGridViewColumn[] { CheckBox, ChboxPDFEmail, ChboxEmailHTML });
            DGV_Dados.Location = new Point(21, 61);
            DGV_Dados.Name = "DGV_Dados";
            DGV_Dados.ReadOnly = true;
            DGV_Dados.Size = new Size(790, 292);
            DGV_Dados.TabIndex = 0;
            DGV_Dados.DoubleClick += DGV_Dados_DoubleClick;
            // 
            // CheckBox
            // 
            CheckBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CheckBox.HeaderText = "PDF Por Whats";
            CheckBox.Name = "CheckBox";
            CheckBox.ReadOnly = true;
            CheckBox.Width = 82;
            // 
            // ChboxPDFEmail
            // 
            ChboxPDFEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ChboxPDFEmail.HeaderText = "PDF Por Email";
            ChboxPDFEmail.Name = "ChboxPDFEmail";
            ChboxPDFEmail.ReadOnly = true;
            ChboxPDFEmail.Resizable = DataGridViewTriState.True;
            ChboxPDFEmail.Width = 78;
            // 
            // ChboxEmailHTML
            // 
            ChboxEmailHTML.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ChboxEmailHTML.HeaderText = "Email Em HTML";
            ChboxEmailHTML.Name = "ChboxEmailHTML";
            ChboxEmailHTML.ReadOnly = true;
            ChboxEmailHTML.Resizable = DataGridViewTriState.True;
            ChboxEmailHTML.Width = 88;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(805, 46);
            label1.TabIndex = 1;
            label1.Text = "Defina as datas de cobranças e codigos das Ações";
            // 
            // Btn_Salvar
            // 
            Btn_Salvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Btn_Salvar.BackColor = Color.Teal;
            Btn_Salvar.Cursor = Cursors.Hand;
            Btn_Salvar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Salvar.ForeColor = Color.White;
            Btn_Salvar.Location = new Point(21, 359);
            Btn_Salvar.Name = "Btn_Salvar";
            Btn_Salvar.RaioCanto = 20;
            Btn_Salvar.Size = new Size(105, 33);
            Btn_Salvar.TabIndex = 10;
            Btn_Salvar.Text = "Incluir";
            Btn_Salvar.UseVisualStyleBackColor = false;
            Btn_Salvar.Click += Btn_Salvar_Click;
            Btn_Salvar.MouseEnter += Btn_Salvar_MouseEnter;
            Btn_Salvar.MouseLeave += Btn_Salvar_MouseLeave;
            // 
            // Btn_Remover
            // 
            Btn_Remover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Btn_Remover.BackColor = Color.DarkGray;
            Btn_Remover.Cursor = Cursors.Hand;
            Btn_Remover.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Remover.ForeColor = Color.White;
            Btn_Remover.Location = new Point(132, 359);
            Btn_Remover.Name = "Btn_Remover";
            Btn_Remover.RaioCanto = 20;
            Btn_Remover.Size = new Size(105, 33);
            Btn_Remover.TabIndex = 11;
            Btn_Remover.Text = "Remover";
            Btn_Remover.UseVisualStyleBackColor = false;
            Btn_Remover.Click += Btn_Remover_Click;
            Btn_Remover.MouseEnter += Btn_Remover_MouseEnter;
            Btn_Remover.MouseLeave += Btn_Remover_MouseLeave;
            // 
            // Frm_BoletoAcoesCRM_UC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(Btn_Remover);
            Controls.Add(Btn_Salvar);
            Controls.Add(label1);
            Controls.Add(DGV_Dados);
            DoubleBuffered = true;
            Name = "Frm_BoletoAcoesCRM_UC";
            Size = new Size(829, 421);
            ((System.ComponentModel.ISupportInitialize)DGV_Dados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGV_Dados;
        private Label label1;
        private ComponentesPerson.BotaoArredond Btn_Salvar;
        private ComponentesPerson.BotaoArredond Btn_Remover;
        private ComponentesPerson.Flecha flecha1;
        private DataGridViewCheckBoxColumn CheckBox;
        private DataGridViewCheckBoxColumn ChboxPDFEmail;
        private DataGridViewCheckBoxColumn ChboxEmailHTML;
    }
}
