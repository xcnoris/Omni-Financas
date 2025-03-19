namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_QuitacaoComissao
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_QuitacaoComissao));
            label1 = new Label();
            Lbl_VendedorNome = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            Lbl_DTFim = new Label();
            label4 = new Label();
            Lbl_DTInicio = new Label();
            Btn_QuitarComis = new ComponentesPerson.BotaoArredond(components);
            botaoArredond1 = new ComponentesPerson.BotaoArredond(components);
            groupBox2 = new GroupBox();
            Lbl_ValorTotal = new Label();
            label9 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 30);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 0;
            label1.Text = "Vendedor:";
            // 
            // Lbl_VendedorNome
            // 
            Lbl_VendedorNome.AutoSize = true;
            Lbl_VendedorNome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_VendedorNome.ForeColor = Color.Green;
            Lbl_VendedorNome.Location = new Point(150, 30);
            Lbl_VendedorNome.Name = "Lbl_VendedorNome";
            Lbl_VendedorNome.Size = new Size(58, 21);
            Lbl_VendedorNome.TabIndex = 1;
            Lbl_VendedorNome.Text = "Fulano";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 31);
            label3.Name = "label3";
            label3.Size = new Size(54, 21);
            label3.TabIndex = 3;
            label3.Text = "Inicio:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(Lbl_DTFim);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Lbl_DTInicio);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(57, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 78);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Periodo";
            // 
            // Lbl_DTFim
            // 
            Lbl_DTFim.AutoSize = true;
            Lbl_DTFim.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_DTFim.ForeColor = Color.Green;
            Lbl_DTFim.Location = new Point(247, 31);
            Lbl_DTFim.Name = "Lbl_DTFim";
            Lbl_DTFim.Size = new Size(87, 21);
            Lbl_DTFim.TabIndex = 6;
            Lbl_DTFim.Text = "01/01/0001";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(192, 31);
            label4.Name = "label4";
            label4.Size = new Size(37, 21);
            label4.TabIndex = 5;
            label4.Text = "até:";
            // 
            // Lbl_DTInicio
            // 
            Lbl_DTInicio.AutoSize = true;
            Lbl_DTInicio.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_DTInicio.ForeColor = Color.Green;
            Lbl_DTInicio.Location = new Point(78, 31);
            Lbl_DTInicio.Name = "Lbl_DTInicio";
            Lbl_DTInicio.Size = new Size(87, 21);
            Lbl_DTInicio.TabIndex = 4;
            Lbl_DTInicio.Text = "01/01/0001";
            // 
            // Btn_QuitarComis
            // 
            Btn_QuitarComis.BackColor = Color.LightSalmon;
            Btn_QuitarComis.FlatAppearance.BorderColor = Color.Black;
            Btn_QuitarComis.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_QuitarComis.ForeColor = Color.White;
            Btn_QuitarComis.Location = new Point(57, 310);
            Btn_QuitarComis.Name = "Btn_QuitarComis";
            Btn_QuitarComis.RaioCanto = 20;
            Btn_QuitarComis.Size = new Size(221, 32);
            Btn_QuitarComis.TabIndex = 38;
            Btn_QuitarComis.Text = "Quitar Comissões";
            Btn_QuitarComis.UseVisualStyleBackColor = false;
            Btn_QuitarComis.Click += Btn_QuitarComis_Click;
            // 
            // botaoArredond1
            // 
            botaoArredond1.BackColor = Color.Crimson;
            botaoArredond1.FlatAppearance.BorderColor = Color.Black;
            botaoArredond1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond1.ForeColor = Color.White;
            botaoArredond1.Location = new Point(310, 310);
            botaoArredond1.Name = "botaoArredond1";
            botaoArredond1.RaioCanto = 20;
            botaoArredond1.Size = new Size(134, 32);
            botaoArredond1.TabIndex = 39;
            botaoArredond1.Text = "Cancelar";
            botaoArredond1.UseVisualStyleBackColor = false;
            botaoArredond1.Click += botaoArredond1_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(Lbl_ValorTotal);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(57, 173);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(387, 81);
            groupBox2.TabIndex = 40;
            groupBox2.TabStop = false;
            groupBox2.Text = "Valores";
            // 
            // Lbl_ValorTotal
            // 
            Lbl_ValorTotal.AutoSize = true;
            Lbl_ValorTotal.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_ValorTotal.ForeColor = Color.Green;
            Lbl_ValorTotal.Location = new Point(119, 31);
            Lbl_ValorTotal.Name = "Lbl_ValorTotal";
            Lbl_ValorTotal.Size = new Size(87, 21);
            Lbl_ValorTotal.TabIndex = 4;
            Lbl_ValorTotal.Text = "01/01/0001";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(18, 31);
            label9.Name = "label9";
            label9.Size = new Size(90, 21);
            label9.TabIndex = 3;
            label9.Text = "Valor Total:";
            // 
            // Frm_QuitacaoComissao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_crm;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(496, 354);
            ControlBox = false;
            Controls.Add(groupBox2);
            Controls.Add(botaoArredond1);
            Controls.Add(Btn_QuitarComis);
            Controls.Add(groupBox1);
            Controls.Add(Lbl_VendedorNome);
            Controls.Add(label1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Frm_QuitacaoComissao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Confirmação de Quitação ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Lbl_VendedorNome;
        private Label label3;
        private GroupBox groupBox1;
        private Label Lbl_DTFim;
        private Label label4;
        private Label Lbl_DTInicio;
        private ComponentesPerson.BotaoArredond Btn_QuitarComis;
        private ComponentesPerson.BotaoArredond botaoArredond1;
        private GroupBox groupBox2;
        private Label Lbl_ValorTotal;
        private Label label9;
    }
}