namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_AcoesSituacoes
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
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            Btn_Editar5 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Editar4 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_OSCriacao = new TextBox();
            label2 = new Label();
            Txt_OSCancelada = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            Btn_Editar3 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Editar2 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_Editar1 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_BolCriacao = new TextBox();
            label4 = new Label();
            Txt_BolCanEst = new TextBox();
            label3 = new Label();
            Txt_BolQuitado = new TextBox();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            bindingSource1 = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(69, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(696, 363);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ações para Situações";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Btn_Editar5);
            groupBox3.Controls.Add(Btn_Editar4);
            groupBox3.Controls.Add(Txt_OSCriacao);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(Txt_OSCancelada);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox3.ForeColor = Color.Black;
            groupBox3.Location = new Point(58, 206);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(668, 124);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ordem de Serviço";
            // 
            // Btn_Editar5
            // 
            Btn_Editar5.BackColor = Color.Teal;
            Btn_Editar5.Cursor = Cursors.Hand;
            Btn_Editar5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Editar5.ForeColor = Color.White;
            Btn_Editar5.Location = new Point(440, 61);
            Btn_Editar5.Name = "Btn_Editar5";
            Btn_Editar5.RaioCanto = 20;
            Btn_Editar5.Size = new Size(70, 23);
            Btn_Editar5.TabIndex = 28;
            Btn_Editar5.Text = "Editar";
            Btn_Editar5.UseVisualStyleBackColor = false;
            Btn_Editar5.Click += Btn_EditarMenCacelarOS_Click;
            Btn_Editar5.MouseEnter += Btn_Editar5_MouseEnter;
            Btn_Editar5.MouseLeave += Btn_Editar5_MouseLeave;
            // 
            // Btn_Editar4
            // 
            Btn_Editar4.BackColor = Color.Teal;
            Btn_Editar4.Cursor = Cursors.Hand;
            Btn_Editar4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Editar4.ForeColor = Color.White;
            Btn_Editar4.Location = new Point(440, 27);
            Btn_Editar4.Name = "Btn_Editar4";
            Btn_Editar4.RaioCanto = 20;
            Btn_Editar4.Size = new Size(70, 23);
            Btn_Editar4.TabIndex = 27;
            Btn_Editar4.Text = "Editar";
            Btn_Editar4.UseVisualStyleBackColor = false;
            Btn_Editar4.Click += Btn_EditarMenCricaoOS_Click;
            Btn_Editar4.MouseEnter += Btn_Editar4_MouseEnter;
            Btn_Editar4.MouseLeave += Btn_Editar4_MouseLeave;
            // 
            // Txt_OSCriacao
            // 
            Txt_OSCriacao.Location = new Point(276, 27);
            Txt_OSCriacao.Name = "Txt_OSCriacao";
            Txt_OSCriacao.ReadOnly = true;
            Txt_OSCriacao.Size = new Size(158, 25);
            Txt_OSCriacao.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(178, 30);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 3;
            label2.Text = "Criação:";
            // 
            // Txt_OSCancelada
            // 
            Txt_OSCancelada.Location = new Point(276, 60);
            Txt_OSCancelada.Name = "Txt_OSCancelada";
            Txt_OSCancelada.ReadOnly = true;
            Txt_OSCancelada.Size = new Size(158, 25);
            Txt_OSCancelada.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(177, 63);
            label5.Name = "label5";
            label5.Size = new Size(90, 17);
            label5.TabIndex = 1;
            label5.Text = "1 - Cancelada:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(Btn_Editar3);
            groupBox2.Controls.Add(Btn_Editar2);
            groupBox2.Controls.Add(Btn_Editar1);
            groupBox2.Controls.Add(Txt_BolCriacao);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Txt_BolCanEst);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(Txt_BolQuitado);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(58, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(668, 178);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Boletos";
            // 
            // Btn_Editar3
            // 
            Btn_Editar3.BackColor = Color.Teal;
            Btn_Editar3.Cursor = Cursors.Hand;
            Btn_Editar3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Editar3.ForeColor = Color.White;
            Btn_Editar3.Location = new Point(440, 116);
            Btn_Editar3.Name = "Btn_Editar3";
            Btn_Editar3.RaioCanto = 20;
            Btn_Editar3.Size = new Size(70, 23);
            Btn_Editar3.TabIndex = 31;
            Btn_Editar3.Text = "Editar";
            Btn_Editar3.UseVisualStyleBackColor = false;
            Btn_Editar3.Click += botaoArredond3_Click;
            Btn_Editar3.MouseEnter += Btn_Editar3_MouseEnter;
            Btn_Editar3.MouseLeave += Btn_Editar3_MouseLeave;
            // 
            // Btn_Editar2
            // 
            Btn_Editar2.BackColor = Color.Teal;
            Btn_Editar2.Cursor = Cursors.Hand;
            Btn_Editar2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Editar2.ForeColor = Color.White;
            Btn_Editar2.Location = new Point(440, 77);
            Btn_Editar2.Name = "Btn_Editar2";
            Btn_Editar2.RaioCanto = 20;
            Btn_Editar2.Size = new Size(70, 23);
            Btn_Editar2.TabIndex = 30;
            Btn_Editar2.Text = "Editar";
            Btn_Editar2.UseVisualStyleBackColor = false;
            Btn_Editar2.Click += botaoArredond1_Click;
            Btn_Editar2.MouseEnter += Btn_Editar2_MouseEnter;
            Btn_Editar2.MouseLeave += Btn_Editar2_MouseLeave;
            // 
            // Btn_Editar1
            // 
            Btn_Editar1.BackColor = Color.Teal;
            Btn_Editar1.Cursor = Cursors.Hand;
            Btn_Editar1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_Editar1.ForeColor = Color.White;
            Btn_Editar1.Location = new Point(440, 41);
            Btn_Editar1.Name = "Btn_Editar1";
            Btn_Editar1.RaioCanto = 20;
            Btn_Editar1.Size = new Size(70, 23);
            Btn_Editar1.TabIndex = 1;
            Btn_Editar1.Text = "Editar";
            Btn_Editar1.UseVisualStyleBackColor = false;
            Btn_Editar1.Click += botaoArredond2_Click;
            Btn_Editar1.MouseEnter += Btn_Editar1_MouseEnter;
            Btn_Editar1.MouseLeave += Btn_Editar1_MouseLeave;
            // 
            // Txt_BolCriacao
            // 
            Txt_BolCriacao.Location = new Point(276, 41);
            Txt_BolCriacao.Name = "Txt_BolCriacao";
            Txt_BolCriacao.ReadOnly = true;
            Txt_BolCriacao.Size = new Size(158, 25);
            Txt_BolCriacao.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(179, 40);
            label4.Name = "label4";
            label4.Size = new Size(78, 17);
            label4.TabIndex = 7;
            label4.Text = "1 - Emissão:";
            // 
            // Txt_BolCanEst
            // 
            Txt_BolCanEst.Location = new Point(276, 118);
            Txt_BolCanEst.Name = "Txt_BolCanEst";
            Txt_BolCanEst.ReadOnly = true;
            Txt_BolCanEst.Size = new Size(158, 25);
            Txt_BolCanEst.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(179, 122);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 5;
            label3.Text = "3 - Cancelada:";
            // 
            // Txt_BolQuitado
            // 
            Txt_BolQuitado.Location = new Point(276, 79);
            Txt_BolQuitado.Name = "Txt_BolQuitado";
            Txt_BolQuitado.ReadOnly = true;
            Txt_BolQuitado.Size = new Size(158, 25);
            Txt_BolQuitado.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(177, 84);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 3;
            label1.Text = "2 - Quitado:";
            // 
            // Frm_AcoesSituacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "Frm_AcoesSituacoes";
            Size = new Size(829, 421);
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private TextBox Txt_OSCancelada;
        private Label label5;
        private GroupBox groupBox2;
        private TextBox Txt_BolCanEst;
        private Label label3;
        private TextBox Txt_BolQuitado;
        private Label label1;
        private TextBox Txt_MenBOLCancelado;
        private Label label8;
        private TextBox Txt_MenBOLQuitado;
        private Label label7;
        private TextBox Txt_OSCriacao;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ComponentesPerson.BotaoArredond Btn_Editar4;
        private BindingSource bindingSource1;
        private ComponentesPerson.BotaoArredond Btn_Editar5;
        private TextBox Txt_BolCriacao;
        private Label label4;
        private ComponentesPerson.BotaoArredond Btn_Editar3;
        private ComponentesPerson.BotaoArredond Btn_Editar2;
        private ComponentesPerson.BotaoArredond Btn_Editar1;
    }
}
