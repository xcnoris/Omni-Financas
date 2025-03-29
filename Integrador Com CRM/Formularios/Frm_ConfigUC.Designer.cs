namespace Integrador_Com_CRM.Formularios
{
    partial class Frm_ConfigUC
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
            groupBox1 = new GroupBox();
            groupBox5 = new GroupBox();
            groupBox9 = new GroupBox();
            ChBox_EnviarPDF = new CheckBox();
            label9 = new Label();
            label10 = new Label();
            groupBox6 = new GroupBox();
            DTP_CobSegundaBoleto = new DateTimePicker();
            DTP_CobDiariaBoleto = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            groupBox8 = new GroupBox();
            DTP_SelectBoleto = new DateTimePicker();
            label8 = new Label();
            label4 = new Label();
            groupBox4 = new GroupBox();
            groupBox7 = new GroupBox();
            DTP_SelectOS = new DateTimePicker();
            label7 = new Label();
            groupBox2 = new GroupBox();
            label5 = new Label();
            Txt_TimerOS = new TextBox();
            label6 = new Label();
            groupBox3 = new GroupBox();
            Txt_Token = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(19, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(785, 393);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações";
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.Transparent;
            groupBox5.Controls.Add(groupBox9);
            groupBox5.Controls.Add(groupBox6);
            groupBox5.Controls.Add(groupBox8);
            groupBox5.ForeColor = Color.White;
            groupBox5.Location = new Point(18, 215);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(745, 170);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Boletos";
            // 
            // groupBox9
            // 
            groupBox9.BackColor = Color.Transparent;
            groupBox9.Controls.Add(ChBox_EnviarPDF);
            groupBox9.Controls.Add(label9);
            groupBox9.Controls.Add(label10);
            groupBox9.ForeColor = Color.White;
            groupBox9.Location = new Point(337, 22);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(402, 78);
            groupBox9.TabIndex = 6;
            groupBox9.TabStop = false;
            groupBox9.Text = "Config Select";
            // 
            // ChBox_EnviarPDF
            // 
            ChBox_EnviarPDF.AutoSize = true;
            ChBox_EnviarPDF.Location = new Point(236, 28);
            ChBox_EnviarPDF.Name = "ChBox_EnviarPDF";
            ChBox_EnviarPDF.Size = new Size(15, 14);
            ChBox_EnviarPDF.TabIndex = 18;
            ChBox_EnviarPDF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label9.Location = new Point(14, 25);
            label9.Name = "label9";
            label9.Size = new Size(216, 17);
            label9.TabIndex = 8;
            label9.Text = "Enviar PDF ao Criar Oportunidade:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 25);
            label10.Name = "label10";
            label10.Size = new Size(0, 17);
            label10.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.Transparent;
            groupBox6.Controls.Add(DTP_CobSegundaBoleto);
            groupBox6.Controls.Add(DTP_CobDiariaBoleto);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(label3);
            groupBox6.ForeColor = Color.White;
            groupBox6.Location = new Point(19, 22);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(312, 78);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Timers";
            // 
            // DTP_CobSegundaBoleto
            // 
            DTP_CobSegundaBoleto.CustomFormat = "HH:mm";
            DTP_CobSegundaBoleto.Format = DateTimePickerFormat.Custom;
            DTP_CobSegundaBoleto.Location = new Point(240, 49);
            DTP_CobSegundaBoleto.Name = "DTP_CobSegundaBoleto";
            DTP_CobSegundaBoleto.ShowUpDown = true;
            DTP_CobSegundaBoleto.Size = new Size(55, 25);
            DTP_CobSegundaBoleto.TabIndex = 5;
            DTP_CobSegundaBoleto.Value = new DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // DTP_CobDiariaBoleto
            // 
            DTP_CobDiariaBoleto.CustomFormat = "HH:mm";
            DTP_CobDiariaBoleto.Format = DateTimePickerFormat.Custom;
            DTP_CobDiariaBoleto.Location = new Point(240, 20);
            DTP_CobDiariaBoleto.Name = "DTP_CobDiariaBoleto";
            DTP_CobDiariaBoleto.ShowUpDown = true;
            DTP_CobDiariaBoleto.Size = new Size(55, 25);
            DTP_CobDiariaBoleto.TabIndex = 4;
            DTP_CobDiariaBoleto.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.Location = new Point(11, 51);
            label2.Name = "label2";
            label2.Size = new Size(223, 17);
            label2.TabIndex = 23;
            label2.Text = "Realizar Cobrança toda segunda às:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 27);
            label3.Name = "label3";
            label3.Size = new Size(209, 17);
            label3.TabIndex = 22;
            label3.Text = "Verificar Boletos todos os dias às:";
            // 
            // groupBox8
            // 
            groupBox8.BackColor = Color.Transparent;
            groupBox8.Controls.Add(DTP_SelectBoleto);
            groupBox8.Controls.Add(label8);
            groupBox8.Controls.Add(label4);
            groupBox8.ForeColor = Color.White;
            groupBox8.Location = new Point(19, 106);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(478, 59);
            groupBox8.TabIndex = 7;
            groupBox8.TabStop = false;
            groupBox8.Text = "Config Select";
            // 
            // DTP_SelectBoleto
            // 
            DTP_SelectBoleto.CustomFormat = "HH:mm";
            DTP_SelectBoleto.Format = DateTimePickerFormat.Short;
            DTP_SelectBoleto.Location = new Point(370, 22);
            DTP_SelectBoleto.Name = "DTP_SelectBoleto";
            DTP_SelectBoleto.Size = new Size(95, 25);
            DTP_SelectBoleto.TabIndex = 6;
            DTP_SelectBoleto.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(5, 27);
            label8.Name = "label8";
            label8.Size = new Size(359, 17);
            label8.TabIndex = 8;
            label8.Text = "Buscar Boletos registradas no banco de dados a partir de:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 25);
            label4.Name = "label4";
            label4.Size = new Size(0, 17);
            label4.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(groupBox7);
            groupBox4.Controls.Add(groupBox2);
            groupBox4.ForeColor = Color.White;
            groupBox4.Location = new Point(18, 106);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(745, 103);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ordem de Serviço";
            // 
            // groupBox7
            // 
            groupBox7.BackColor = Color.Transparent;
            groupBox7.Controls.Add(DTP_SelectOS);
            groupBox7.Controls.Add(label7);
            groupBox7.ForeColor = Color.White;
            groupBox7.Location = new Point(278, 35);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(450, 54);
            groupBox7.TabIndex = 4;
            groupBox7.TabStop = false;
            groupBox7.Text = "Config Select";
            // 
            // DTP_SelectOS
            // 
            DTP_SelectOS.CustomFormat = "HH:mm";
            DTP_SelectOS.Format = DateTimePickerFormat.Short;
            DTP_SelectOS.Location = new Point(345, 22);
            DTP_SelectOS.Name = "DTP_SelectOS";
            DTP_SelectOS.Size = new Size(95, 25);
            DTP_SelectOS.TabIndex = 3;
            DTP_SelectOS.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(8, 23);
            label7.Name = "label7";
            label7.Size = new Size(331, 17);
            label7.TabIndex = 7;
            label7.Text = "Buscar OS registradas no banco de dados a partir de:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(Txt_TimerOS);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(19, 35);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(253, 54);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Timers";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(178, 25);
            label5.Name = "label5";
            label5.Size = new Size(61, 17);
            label5.TabIndex = 7;
            label5.Text = "minutos.";
            // 
            // Txt_TimerOS
            // 
            Txt_TimerOS.Location = new Point(116, 22);
            Txt_TimerOS.Name = "Txt_TimerOS";
            Txt_TimerOS.Size = new Size(52, 25);
            Txt_TimerOS.TabIndex = 2;
            Txt_TimerOS.KeyPress += Txt_TimerOS_KeyPress;
            Txt_TimerOS.Leave += Txt_TimerOS_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(8, 25);
            label6.Name = "label6";
            label6.Size = new Size(102, 17);
            label6.TabIndex = 1;
            label6.Text = "Verificar a cada ";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Txt_Token);
            groupBox3.Controls.Add(label1);
            groupBox3.ForeColor = Color.Yellow;
            groupBox3.Location = new Point(18, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(745, 78);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Licença";
            // 
            // Txt_Token
            // 
            Txt_Token.Location = new Point(66, 33);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(555, 25);
            Txt_Token.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(19, 36);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 1;
            label1.Text = "Token:";
            // 
            // Frm_ConfigUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "Frm_ConfigUC";
            Size = new Size(829, 421);
            groupBox1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox Txt_TimerOS;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox Txt_Token;
        private Label label1;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private DateTimePicker DTP_CobSegundaBoleto;
        private DateTimePicker DTP_CobDiariaBoleto;
        private Label label2;
        private Label label3;
        private GroupBox groupBox8;
        private Label label4;
        private GroupBox groupBox7;
        private Label label5;
        private DateTimePicker DTP_SelectOS;
        private Label label7;
        private DateTimePicker DTP_SelectBoleto;
        private Label label8;
        private GroupBox groupBox9;
        private CheckBox ChBox_EnviarPDF;
        private Label label9;
        private Label label10;
    }
}
