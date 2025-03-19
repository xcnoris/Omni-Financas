namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_RelatorioComissaoUC
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
            groupBox4 = new GroupBox();
            Cbox_SituacaoComissao = new ComboBox();
            label2 = new Label();
            Btn_GerarPDF = new ComponentesPerson.BotaoArredond(components);
            Btn_SelectDiretorio = new Button();
            Txt_Diretorio = new TextBox();
            label1 = new Label();
            DTP_DTFim = new DateTimePicker();
            label9 = new Label();
            Cbox_Vendedores = new ComboBox();
            DTP_DTInicio = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            botaoArredond1 = new ComponentesPerson.BotaoArredond(components);
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.White;
            groupBox4.Controls.Add(botaoArredond1);
            groupBox4.Controls.Add(Cbox_SituacaoComissao);
            groupBox4.Controls.Add(label2);
            groupBox4.Controls.Add(Btn_GerarPDF);
            groupBox4.Controls.Add(Btn_SelectDiretorio);
            groupBox4.Controls.Add(Txt_Diretorio);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(DTP_DTFim);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(Cbox_Vendedores);
            groupBox4.Controls.Add(DTP_DTInicio);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label8);
            groupBox4.ForeColor = SystemColors.HotTrack;
            groupBox4.Location = new Point(14, 91);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(792, 231);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Gerar Relatorio de Comissão";
            // 
            // Cbox_SituacaoComissao
            // 
            Cbox_SituacaoComissao.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Cbox_SituacaoComissao.FormattingEnabled = true;
            Cbox_SituacaoComissao.Location = new Point(121, 144);
            Cbox_SituacaoComissao.Name = "Cbox_SituacaoComissao";
            Cbox_SituacaoComissao.Size = new Size(196, 29);
            Cbox_SituacaoComissao.TabIndex = 36;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(25, 146);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 35;
            label2.Text = "Situação:";
            // 
            // Btn_GerarPDF
            // 
            Btn_GerarPDF.BackColor = Color.MediumPurple;
            Btn_GerarPDF.FlatAppearance.BorderColor = Color.Black;
            Btn_GerarPDF.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_GerarPDF.ForeColor = SystemColors.ButtonFace;
            Btn_GerarPDF.Location = new Point(541, 155);
            Btn_GerarPDF.Name = "Btn_GerarPDF";
            Btn_GerarPDF.RaioCanto = 20;
            Btn_GerarPDF.Size = new Size(221, 32);
            Btn_GerarPDF.TabIndex = 34;
            Btn_GerarPDF.Text = "Visualizar Relatorio";
            Btn_GerarPDF.UseVisualStyleBackColor = false;
            Btn_GerarPDF.Click += Btn_GerarPDF_Click;
            // 
            // Btn_SelectDiretorio
            // 
            Btn_SelectDiretorio.BackgroundImage = Properties.Resources.salvar;
            Btn_SelectDiretorio.BackgroundImageLayout = ImageLayout.Stretch;
            Btn_SelectDiretorio.Location = new Point(710, 95);
            Btn_SelectDiretorio.Name = "Btn_SelectDiretorio";
            Btn_SelectDiretorio.Size = new Size(42, 23);
            Btn_SelectDiretorio.TabIndex = 32;
            Btn_SelectDiretorio.UseVisualStyleBackColor = true;
            Btn_SelectDiretorio.Click += Btn_SelectDiretorio_Click;
            // 
            // Txt_Diretorio
            // 
            Txt_Diretorio.Location = new Point(233, 95);
            Txt_Diretorio.Name = "Txt_Diretorio";
            Txt_Diretorio.ReadOnly = true;
            Txt_Diretorio.Size = new Size(471, 23);
            Txt_Diretorio.TabIndex = 31;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(25, 98);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 30;
            label1.Text = "Diretorio para salvar arquivo:";
            // 
            // DTP_DTFim
            // 
            DTP_DTFim.CustomFormat = "HH:mm";
            DTP_DTFim.Format = DateTimePickerFormat.Short;
            DTP_DTFim.Location = new Point(667, 49);
            DTP_DTFim.Name = "DTP_DTFim";
            DTP_DTFim.Size = new Size(95, 23);
            DTP_DTFim.TabIndex = 29;
            DTP_DTFim.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.Desktop;
            label9.Location = new Point(623, 54);
            label9.Name = "label9";
            label9.Size = new Size(23, 15);
            label9.TabIndex = 28;
            label9.Text = "até";
            // 
            // Cbox_Vendedores
            // 
            Cbox_Vendedores.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Cbox_Vendedores.FormattingEnabled = true;
            Cbox_Vendedores.Location = new Point(121, 50);
            Cbox_Vendedores.Name = "Cbox_Vendedores";
            Cbox_Vendedores.Size = new Size(196, 29);
            Cbox_Vendedores.TabIndex = 27;
            // 
            // DTP_DTInicio
            // 
            DTP_DTInicio.CustomFormat = "HH:mm";
            DTP_DTInicio.Format = DateTimePickerFormat.Short;
            DTP_DTInicio.Location = new Point(522, 50);
            DTP_DTInicio.Name = "DTP_DTInicio";
            DTP_DTInicio.Size = new Size(95, 23);
            DTP_DTInicio.TabIndex = 26;
            DTP_DTInicio.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(338, 50);
            label7.Name = "label7";
            label7.Size = new Size(178, 20);
            label7.TabIndex = 3;
            label7.Text = "Comissôes geradas entre ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.Desktop;
            label8.Location = new Point(25, 52);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 1;
            label8.Text = "Vendedores:";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // botaoArredond1
            // 
            botaoArredond1.BackColor = Color.LightSalmon;
            botaoArredond1.FlatAppearance.BorderColor = Color.Black;
            botaoArredond1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond1.ForeColor = Color.White;
            botaoArredond1.Location = new Point(541, 193);
            botaoArredond1.Name = "botaoArredond1";
            botaoArredond1.RaioCanto = 20;
            botaoArredond1.Size = new Size(221, 32);
            botaoArredond1.TabIndex = 38;
            botaoArredond1.Text = "Quitar Comissões";
            botaoArredond1.UseVisualStyleBackColor = false;
            botaoArredond1.Click += botaoArredond1_Click;
            // 
            // Frm_RelatorioComissaoUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox4);
            DoubleBuffered = true;
            Name = "Frm_RelatorioComissaoUC";
            Size = new Size(829, 421);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox4;
        private Label label7;
        private Label label8;
        private DateTimePicker DTP_DTInicio;
        private DateTimePicker DTP_DTFim;
        private Label label9;
        private ComboBox Cbox_Vendedores;
        private TextBox Txt_Diretorio;
        private Label label1;
        private Button Btn_SelectDiretorio;
        private ComponentesPerson.BotaoArredond Btn_GerarPDF;
        private ComboBox Cbox_SituacaoComissao;
        private Label label2;
        private FileSystemWatcher fileSystemWatcher1;
        private ComponentesPerson.BotaoArredond botaoArredond1;
    }
}
