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
            groupBox1.ForeColor = SystemColors.HotTrack;
            groupBox1.Location = new Point(19, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(785, 404);
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
            groupBox5.ForeColor = SystemColors.HotTrack;
            groupBox5.Location = new Point(18, 215);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(745, 183);
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
            groupBox9.ForeColor = SystemColors.HotTrack;
            groupBox9.Location = new Point(309, 101);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(419, 58);
            groupBox9.TabIndex = 18;
            groupBox9.TabStop = false;
            groupBox9.Text = "Config Select";
            // 
            // ChBox_EnviarPDF
            // 
            ChBox_EnviarPDF.AutoSize = true;
            ChBox_EnviarPDF.Location = new Point(207, 26);
            ChBox_EnviarPDF.Name = "ChBox_EnviarPDF";
            ChBox_EnviarPDF.Size = new Size(15, 14);
            ChBox_EnviarPDF.TabIndex = 18;
            ChBox_EnviarPDF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 25);
            label9.Name = "label9";
            label9.Size = new Size(187, 15);
            label9.TabIndex = 8;
            label9.Text = "Enviar PDF ao Criar Oportunidade:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 25);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 1;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.White;
            groupBox6.Controls.Add(DTP_CobSegundaBoleto);
            groupBox6.Controls.Add(DTP_CobDiariaBoleto);
            groupBox6.Controls.Add(label2);
            groupBox6.Controls.Add(label3);
            groupBox6.ForeColor = SystemColors.HotTrack;
            groupBox6.Location = new Point(16, 17);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(281, 78);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "Timers";
            // 
            // DTP_CobSegundaBoleto
            // 
            DTP_CobSegundaBoleto.CustomFormat = "HH:mm";
            DTP_CobSegundaBoleto.Format = DateTimePickerFormat.Custom;
            DTP_CobSegundaBoleto.Location = new Point(210, 49);
            DTP_CobSegundaBoleto.Name = "DTP_CobSegundaBoleto";
            DTP_CobSegundaBoleto.ShowUpDown = true;
            DTP_CobSegundaBoleto.Size = new Size(55, 23);
            DTP_CobSegundaBoleto.TabIndex = 25;
            DTP_CobSegundaBoleto.Value = new DateTime(2024, 12, 25, 0, 0, 0, 0);
            // 
            // DTP_CobDiariaBoleto
            // 
            DTP_CobDiariaBoleto.CustomFormat = "HH:mm";
            DTP_CobDiariaBoleto.Format = DateTimePickerFormat.Custom;
            DTP_CobDiariaBoleto.Location = new Point(210, 22);
            DTP_CobDiariaBoleto.Name = "DTP_CobDiariaBoleto";
            DTP_CobDiariaBoleto.ShowUpDown = true;
            DTP_CobDiariaBoleto.Size = new Size(55, 23);
            DTP_CobDiariaBoleto.TabIndex = 24;
            DTP_CobDiariaBoleto.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 51);
            label2.Name = "label2";
            label2.Size = new Size(193, 15);
            label2.TabIndex = 23;
            label2.Text = "Realizar Cobrança toda segunda às:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 27);
            label3.Name = "label3";
            label3.Size = new Size(180, 15);
            label3.TabIndex = 22;
            label3.Text = "Verificar Boletos todos os dias às:";
            // 
            // groupBox8
            // 
            groupBox8.BackColor = Color.Transparent;
            groupBox8.Controls.Add(DTP_SelectBoleto);
            groupBox8.Controls.Add(label8);
            groupBox8.Controls.Add(label4);
            groupBox8.ForeColor = SystemColors.HotTrack;
            groupBox8.Location = new Point(309, 17);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(419, 78);
            groupBox8.TabIndex = 16;
            groupBox8.TabStop = false;
            groupBox8.Text = "Config Select";
            // 
            // DTP_SelectBoleto
            // 
            DTP_SelectBoleto.CustomFormat = "HH:mm";
            DTP_SelectBoleto.Format = DateTimePickerFormat.Short;
            DTP_SelectBoleto.Location = new Point(318, 22);
            DTP_SelectBoleto.Name = "DTP_SelectBoleto";
            DTP_SelectBoleto.Size = new Size(95, 23);
            DTP_SelectBoleto.TabIndex = 26;
            DTP_SelectBoleto.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 27);
            label8.Name = "label8";
            label8.Size = new Size(307, 15);
            label8.TabIndex = 8;
            label8.Text = "Buscar Boletos registradas no banco de dados a partir de:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 25);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.Transparent;
            groupBox4.Controls.Add(groupBox7);
            groupBox4.Controls.Add(groupBox2);
            groupBox4.ForeColor = SystemColors.HotTrack;
            groupBox4.Location = new Point(18, 106);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(745, 103);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Ordem de Serviço";
            // 
            // groupBox7
            // 
            groupBox7.BackColor = Color.Transparent;
            groupBox7.Controls.Add(DTP_SelectOS);
            groupBox7.Controls.Add(label7);
            groupBox7.ForeColor = SystemColors.HotTrack;
            groupBox7.Location = new Point(309, 35);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(419, 54);
            groupBox7.TabIndex = 15;
            groupBox7.TabStop = false;
            groupBox7.Text = "Config Select";
            // 
            // DTP_SelectOS
            // 
            DTP_SelectOS.CustomFormat = "HH:mm";
            DTP_SelectOS.Format = DateTimePickerFormat.Short;
            DTP_SelectOS.Location = new Point(318, 21);
            DTP_SelectOS.Name = "DTP_SelectOS";
            DTP_SelectOS.Size = new Size(95, 23);
            DTP_SelectOS.TabIndex = 25;
            DTP_SelectOS.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 27);
            label7.Name = "label7";
            label7.Size = new Size(283, 15);
            label7.TabIndex = 7;
            label7.Text = "Buscar OS registradas no banco de dados a partir de:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(Txt_TimerOS);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = SystemColors.HotTrack;
            groupBox2.Location = new Point(19, 35);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(278, 54);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Timers";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(161, 25);
            label5.Name = "label5";
            label5.Size = new Size(54, 15);
            label5.TabIndex = 7;
            label5.Text = "minutos.";
            // 
            // Txt_TimerOS
            // 
            Txt_TimerOS.Location = new Point(103, 22);
            Txt_TimerOS.Name = "Txt_TimerOS";
            Txt_TimerOS.Size = new Size(52, 23);
            Txt_TimerOS.TabIndex = 6;
            Txt_TimerOS.KeyPress += Txt_TimerOS_KeyPress;
            Txt_TimerOS.Leave += Txt_TimerOS_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 25);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 1;
            label6.Text = "Verificar a cada ";
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Txt_Token);
            groupBox3.Controls.Add(label1);
            groupBox3.ForeColor = SystemColors.HotTrack;
            groupBox3.Location = new Point(18, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(745, 78);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Licença";
            // 
            // Txt_Token
            // 
            Txt_Token.Location = new Point(66, 33);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(555, 23);
            Txt_Token.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 36);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 1;
            label1.Text = "Token:";
            // 
            // Frm_ConfigUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            BackgroundImage = Properties.Resources.fundo_crm;
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
