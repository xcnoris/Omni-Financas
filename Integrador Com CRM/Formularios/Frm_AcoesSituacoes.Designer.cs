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
            Btn_EditarMenCacelarOS = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Btn_EditarMenCricaoOS = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_OSCriacao = new TextBox();
            label2 = new Label();
            Txt_OSCancelada = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            botaoArredond3 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            botaoArredond1 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            botaoArredond2 = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
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
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(33, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(769, 363);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ações para Situações";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Btn_EditarMenCacelarOS);
            groupBox3.Controls.Add(Btn_EditarMenCricaoOS);
            groupBox3.Controls.Add(Txt_OSCriacao);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(Txt_OSCancelada);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox3.ForeColor = Color.White;
            groupBox3.Location = new Point(58, 217);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(668, 124);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Ordem de Serviço";
            // 
            // Btn_EditarMenCacelarOS
            // 
            Btn_EditarMenCacelarOS.BackColor = Color.LimeGreen;
            Btn_EditarMenCacelarOS.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_EditarMenCacelarOS.ForeColor = Color.White;
            Btn_EditarMenCacelarOS.Location = new Point(276, 76);
            Btn_EditarMenCacelarOS.Name = "Btn_EditarMenCacelarOS";
            Btn_EditarMenCacelarOS.RaioCanto = 20;
            Btn_EditarMenCacelarOS.Size = new Size(70, 23);
            Btn_EditarMenCacelarOS.TabIndex = 28;
            Btn_EditarMenCacelarOS.Text = "Editar";
            Btn_EditarMenCacelarOS.UseVisualStyleBackColor = false;
            Btn_EditarMenCacelarOS.Click += Btn_EditarMenCacelarOS_Click;
            // 
            // Btn_EditarMenCricaoOS
            // 
            Btn_EditarMenCricaoOS.BackColor = Color.LimeGreen;
            Btn_EditarMenCricaoOS.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            Btn_EditarMenCricaoOS.ForeColor = Color.White;
            Btn_EditarMenCricaoOS.Location = new Point(276, 42);
            Btn_EditarMenCricaoOS.Name = "Btn_EditarMenCricaoOS";
            Btn_EditarMenCricaoOS.RaioCanto = 20;
            Btn_EditarMenCricaoOS.Size = new Size(70, 23);
            Btn_EditarMenCricaoOS.TabIndex = 27;
            Btn_EditarMenCricaoOS.Text = "Editar";
            Btn_EditarMenCricaoOS.UseVisualStyleBackColor = false;
            Btn_EditarMenCricaoOS.Click += Btn_EditarMenCricaoOS_Click;
            // 
            // Txt_OSCriacao
            // 
            Txt_OSCriacao.Location = new Point(112, 42);
            Txt_OSCriacao.Name = "Txt_OSCriacao";
            Txt_OSCriacao.ReadOnly = true;
            Txt_OSCriacao.Size = new Size(158, 25);
            Txt_OSCriacao.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 45);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 3;
            label2.Text = "Criação:";
            // 
            // Txt_OSCancelada
            // 
            Txt_OSCancelada.Location = new Point(112, 75);
            Txt_OSCancelada.Name = "Txt_OSCancelada";
            Txt_OSCancelada.ReadOnly = true;
            Txt_OSCancelada.Size = new Size(158, 25);
            Txt_OSCancelada.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(13, 78);
            label5.Name = "label5";
            label5.Size = new Size(90, 17);
            label5.TabIndex = 1;
            label5.Text = "1 - Cancelada:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(botaoArredond3);
            groupBox2.Controls.Add(botaoArredond1);
            groupBox2.Controls.Add(botaoArredond2);
            groupBox2.Controls.Add(Txt_BolCriacao);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(Txt_BolCanEst);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(Txt_BolQuitado);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(58, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(668, 178);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Boletos";
            // 
            // botaoArredond3
            // 
            botaoArredond3.BackColor = Color.LimeGreen;
            botaoArredond3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond3.ForeColor = Color.White;
            botaoArredond3.Location = new Point(276, 123);
            botaoArredond3.Name = "botaoArredond3";
            botaoArredond3.RaioCanto = 20;
            botaoArredond3.Size = new Size(70, 23);
            botaoArredond3.TabIndex = 31;
            botaoArredond3.Text = "Editar";
            botaoArredond3.UseVisualStyleBackColor = false;
            botaoArredond3.Click += botaoArredond3_Click;
            // 
            // botaoArredond1
            // 
            botaoArredond1.BackColor = Color.LimeGreen;
            botaoArredond1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond1.ForeColor = Color.White;
            botaoArredond1.Location = new Point(276, 84);
            botaoArredond1.Name = "botaoArredond1";
            botaoArredond1.RaioCanto = 20;
            botaoArredond1.Size = new Size(70, 23);
            botaoArredond1.TabIndex = 30;
            botaoArredond1.Text = "Editar";
            botaoArredond1.UseVisualStyleBackColor = false;
            botaoArredond1.Click += botaoArredond1_Click;
            // 
            // botaoArredond2
            // 
            botaoArredond2.BackColor = Color.LimeGreen;
            botaoArredond2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Italic);
            botaoArredond2.ForeColor = Color.White;
            botaoArredond2.Location = new Point(276, 48);
            botaoArredond2.Name = "botaoArredond2";
            botaoArredond2.RaioCanto = 20;
            botaoArredond2.Size = new Size(70, 23);
            botaoArredond2.TabIndex = 1;
            botaoArredond2.Text = "Editar";
            botaoArredond2.UseVisualStyleBackColor = false;
            botaoArredond2.Click += botaoArredond2_Click;
            // 
            // Txt_BolCriacao
            // 
            Txt_BolCriacao.Location = new Point(112, 48);
            Txt_BolCriacao.Name = "Txt_BolCriacao";
            Txt_BolCriacao.ReadOnly = true;
            Txt_BolCriacao.Size = new Size(158, 25);
            Txt_BolCriacao.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(15, 47);
            label4.Name = "label4";
            label4.Size = new Size(78, 17);
            label4.TabIndex = 7;
            label4.Text = "1 - Emissão:";
            // 
            // Txt_BolCanEst
            // 
            Txt_BolCanEst.Location = new Point(112, 125);
            Txt_BolCanEst.Name = "Txt_BolCanEst";
            Txt_BolCanEst.ReadOnly = true;
            Txt_BolCanEst.Size = new Size(158, 25);
            Txt_BolCanEst.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 129);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 5;
            label3.Text = "3 - Cancelada:";
            // 
            // Txt_BolQuitado
            // 
            Txt_BolQuitado.Location = new Point(112, 86);
            Txt_BolQuitado.Name = "Txt_BolQuitado";
            Txt_BolQuitado.ReadOnly = true;
            Txt_BolQuitado.Size = new Size(158, 25);
            Txt_BolQuitado.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(13, 91);
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
            BackgroundImage = CDI_OminiService.Properties.Resources.Cdi_1;
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
        private ComponentesPerson.BotaoArredond Btn_EditarMenCricaoOS;
        private BindingSource bindingSource1;
        private ComponentesPerson.BotaoArredond Btn_EditarMenCacelarOS;
        private TextBox Txt_BolCriacao;
        private Label label4;
        private ComponentesPerson.BotaoArredond botaoArredond3;
        private ComponentesPerson.BotaoArredond botaoArredond1;
        private ComponentesPerson.BotaoArredond botaoArredond2;
    }
}
