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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            groupBox7 = new GroupBox();
            ChBox_OSMensCancel = new CheckBox();
            label14 = new Label();
            DTP_OSSelect = new DateTimePicker();
            label7 = new Label();
            groupBox2 = new GroupBox();
            label5 = new Label();
            Txt_OSTimer = new TextBox();
            label6 = new Label();
            label13 = new Label();
            groupBox9 = new GroupBox();
            ChBox_BoletoEnviarMensCancel = new CheckBox();
            label15 = new Label();
            ChBox_BoletoEnviarMensFimdesem = new CheckBox();
            label11 = new Label();
            ChBox_BoletoEnviarPDF = new CheckBox();
            label9 = new Label();
            label10 = new Label();
            label12 = new Label();
            groupBox6 = new GroupBox();
            DTP_BoletoCobDiaria = new DateTimePicker();
            label3 = new Label();
            groupBox8 = new GroupBox();
            DTP_BoletoSelect = new DateTimePicker();
            label8 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            Btn_BuscarMAC = new Integrador_Com_CRM.ComponentesPerson.BotaoArredond(components);
            Txt_Token = new TextBox();
            label1 = new Label();
            ChBox_BoletoEnviarPDFPorEmail = new CheckBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox7);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(groupBox9);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(groupBox6);
            groupBox1.Controls.Add(groupBox8);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(19, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(791, 390);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configurações";
            // 
            // groupBox7
            // 
            groupBox7.BackColor = Color.Transparent;
            groupBox7.Controls.Add(ChBox_OSMensCancel);
            groupBox7.Controls.Add(label14);
            groupBox7.Controls.Add(DTP_OSSelect);
            groupBox7.Controls.Add(label7);
            groupBox7.ForeColor = Color.Black;
            groupBox7.Location = new Point(277, 123);
            groupBox7.Margin = new Padding(10, 3, 3, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(486, 87);
            groupBox7.TabIndex = 4;
            groupBox7.TabStop = false;
            groupBox7.Text = "Parâmetros";
            // 
            // ChBox_OSMensCancel
            // 
            ChBox_OSMensCancel.AutoSize = true;
            ChBox_OSMensCancel.Location = new Point(222, 54);
            ChBox_OSMensCancel.Name = "ChBox_OSMensCancel";
            ChBox_OSMensCancel.Size = new Size(15, 14);
            ChBox_OSMensCancel.TabIndex = 20;
            ChBox_OSMensCancel.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(8, 52);
            label14.Name = "label14";
            label14.Size = new Size(206, 17);
            label14.TabIndex = 19;
            label14.Text = "Enviar Mensagem Cancelamento";
            // 
            // DTP_OSSelect
            // 
            DTP_OSSelect.CustomFormat = "HH:mm";
            DTP_OSSelect.Format = DateTimePickerFormat.Short;
            DTP_OSSelect.Location = new Point(339, 22);
            DTP_OSSelect.Margin = new Padding(10, 3, 3, 3);
            DTP_OSSelect.Name = "DTP_OSSelect";
            DTP_OSSelect.Size = new Size(141, 25);
            DTP_OSSelect.TabIndex = 3;
            DTP_OSSelect.Value = new DateTime(2025, 6, 30, 0, 0, 0, 0);
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
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
            groupBox2.Controls.Add(Txt_OSTimer);
            groupBox2.Controls.Add(label6);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(18, 123);
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
            label5.ForeColor = Color.Black;
            label5.Location = new Point(178, 25);
            label5.Name = "label5";
            label5.Size = new Size(61, 17);
            label5.TabIndex = 7;
            label5.Text = "minutos.";
            // 
            // Txt_OSTimer
            // 
            Txt_OSTimer.Location = new Point(116, 22);
            Txt_OSTimer.Name = "Txt_OSTimer";
            Txt_OSTimer.Size = new Size(52, 25);
            Txt_OSTimer.TabIndex = 2;
            Txt_OSTimer.KeyPress += Txt_TimerOS_KeyPress;
            Txt_OSTimer.Leave += Txt_TimerOS_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(8, 25);
            label6.Name = "label6";
            label6.Size = new Size(102, 17);
            label6.TabIndex = 1;
            label6.Text = "Verificar a cada ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Teal;
            label13.Location = new Point(23, 103);
            label13.Name = "label13";
            label13.Size = new Size(177, 22);
            label13.TabIndex = 8;
            label13.Text = "Ordem de Serviço";
            // 
            // groupBox9
            // 
            groupBox9.BackColor = Color.Transparent;
            groupBox9.Controls.Add(ChBox_BoletoEnviarPDFPorEmail);
            groupBox9.Controls.Add(label2);
            groupBox9.Controls.Add(ChBox_BoletoEnviarMensCancel);
            groupBox9.Controls.Add(label15);
            groupBox9.Controls.Add(ChBox_BoletoEnviarMensFimdesem);
            groupBox9.Controls.Add(label11);
            groupBox9.Controls.Add(ChBox_BoletoEnviarPDF);
            groupBox9.Controls.Add(label9);
            groupBox9.Controls.Add(label10);
            groupBox9.ForeColor = Color.Black;
            groupBox9.Location = new Point(23, 225);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(275, 143);
            groupBox9.TabIndex = 6;
            groupBox9.TabStop = false;
            groupBox9.Text = "Parâmetros";
            // 
            // ChBox_BoletoEnviarMensCancel
            // 
            ChBox_BoletoEnviarMensCancel.AutoSize = true;
            ChBox_BoletoEnviarMensCancel.Location = new Point(174, 58);
            ChBox_BoletoEnviarMensCancel.Name = "ChBox_BoletoEnviarMensCancel";
            ChBox_BoletoEnviarMensCancel.Size = new Size(15, 14);
            ChBox_BoletoEnviarMensCancel.TabIndex = 22;
            ChBox_BoletoEnviarMensCancel.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(13, 56);
            label15.Name = "label15";
            label15.Size = new Size(162, 17);
            label15.TabIndex = 21;
            label15.Text = "Enviar Mensagem Cancel.";
            // 
            // ChBox_BoletoEnviarMensFimdesem
            // 
            ChBox_BoletoEnviarMensFimdesem.AutoSize = true;
            ChBox_BoletoEnviarMensFimdesem.Location = new Point(251, 86);
            ChBox_BoletoEnviarMensFimdesem.Name = "ChBox_BoletoEnviarMensFimdesem";
            ChBox_BoletoEnviarMensFimdesem.Size = new Size(15, 14);
            ChBox_BoletoEnviarMensFimdesem.TabIndex = 20;
            ChBox_BoletoEnviarMensFimdesem.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(13, 84);
            label11.Name = "label11";
            label11.Size = new Size(232, 17);
            label11.TabIndex = 19;
            label11.Text = "Enviar Mensagem no Fim de semana";
            // 
            // ChBox_BoletoEnviarPDF
            // 
            ChBox_BoletoEnviarPDF.AutoSize = true;
            ChBox_BoletoEnviarPDF.Location = new Point(184, 31);
            ChBox_BoletoEnviarPDF.Name = "ChBox_BoletoEnviarPDF";
            ChBox_BoletoEnviarPDF.Size = new Size(15, 14);
            ChBox_BoletoEnviarPDF.TabIndex = 18;
            ChBox_BoletoEnviarPDF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(13, 29);
            label9.Name = "label9";
            label9.Size = new Size(165, 17);
            label9.TabIndex = 8;
            label9.Text = "Enviar PDF ao criar boleto";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 25);
            label10.Name = "label10";
            label10.Size = new Size(0, 17);
            label10.TabIndex = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Teal;
            label12.Location = new Point(23, 200);
            label12.Name = "label12";
            label12.Size = new Size(81, 22);
            label12.TabIndex = 3;
            label12.Text = "Boletos";
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.Transparent;
            groupBox6.Controls.Add(DTP_BoletoCobDiaria);
            groupBox6.Controls.Add(label3);
            groupBox6.ForeColor = Color.Black;
            groupBox6.Location = new Point(327, 295);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(312, 55);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Timers";
            // 
            // DTP_BoletoCobDiaria
            // 
            DTP_BoletoCobDiaria.CustomFormat = "HH:mm";
            DTP_BoletoCobDiaria.Format = DateTimePickerFormat.Custom;
            DTP_BoletoCobDiaria.Location = new Point(251, 19);
            DTP_BoletoCobDiaria.Name = "DTP_BoletoCobDiaria";
            DTP_BoletoCobDiaria.ShowUpDown = true;
            DTP_BoletoCobDiaria.Size = new Size(55, 25);
            DTP_BoletoCobDiaria.TabIndex = 4;
            DTP_BoletoCobDiaria.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(8, 21);
            label3.Name = "label3";
            label3.Size = new Size(209, 17);
            label3.TabIndex = 22;
            label3.Text = "Verificar Boletos todos os dias às:";
            // 
            // groupBox8
            // 
            groupBox8.BackColor = Color.Transparent;
            groupBox8.Controls.Add(DTP_BoletoSelect);
            groupBox8.Controls.Add(label8);
            groupBox8.Controls.Add(label4);
            groupBox8.ForeColor = Color.Black;
            groupBox8.Location = new Point(327, 225);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(366, 59);
            groupBox8.TabIndex = 7;
            groupBox8.TabStop = false;
            groupBox8.Text = "Config Select";
            // 
            // DTP_BoletoSelect
            // 
            DTP_BoletoSelect.CustomFormat = "HH:mm";
            DTP_BoletoSelect.Format = DateTimePickerFormat.Short;
            DTP_BoletoSelect.Location = new Point(250, 24);
            DTP_BoletoSelect.Name = "DTP_BoletoSelect";
            DTP_BoletoSelect.Size = new Size(95, 25);
            DTP_BoletoSelect.TabIndex = 6;
            DTP_BoletoSelect.Value = new DateTime(2024, 12, 15, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(5, 27);
            label8.Name = "label8";
            label8.Size = new Size(239, 17);
            label8.TabIndex = 8;
            label8.Text = "Buscar Boletos registrados a partir de:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 25);
            label4.Name = "label4";
            label4.Size = new Size(0, 17);
            label4.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(Btn_BuscarMAC);
            groupBox3.Controls.Add(Txt_Token);
            groupBox3.Controls.Add(label1);
            groupBox3.ForeColor = Color.Black;
            groupBox3.Location = new Point(18, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(745, 78);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Licença";
            // 
            // Btn_BuscarMAC
            // 
            Btn_BuscarMAC.BackColor = Color.Teal;
            Btn_BuscarMAC.Cursor = Cursors.Hand;
            Btn_BuscarMAC.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            Btn_BuscarMAC.ForeColor = SystemColors.Control;
            Btn_BuscarMAC.Location = new Point(627, 32);
            Btn_BuscarMAC.Name = "Btn_BuscarMAC";
            Btn_BuscarMAC.RaioCanto = 20;
            Btn_BuscarMAC.Size = new Size(91, 27);
            Btn_BuscarMAC.TabIndex = 5;
            Btn_BuscarMAC.Text = "Buscar MAC";
            Btn_BuscarMAC.UseVisualStyleBackColor = false;
            Btn_BuscarMAC.Click += Btn_BuscarMAC_Click;
            Btn_BuscarMAC.MouseEnter += Btn_BuscarMAC_MouseEnter;
            Btn_BuscarMAC.MouseLeave += Btn_BuscarMAC_MouseLeave;
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
            label1.ForeColor = Color.Black;
            label1.Location = new Point(19, 36);
            label1.Name = "label1";
            label1.Size = new Size(47, 17);
            label1.TabIndex = 1;
            label1.Text = "Token:";
            // 
            // ChBox_BoletoEnviarPDFPorEmail
            // 
            ChBox_BoletoEnviarPDFPorEmail.AutoSize = true;
            ChBox_BoletoEnviarPDFPorEmail.Location = new Point(251, 110);
            ChBox_BoletoEnviarPDFPorEmail.Name = "ChBox_BoletoEnviarPDFPorEmail";
            ChBox_BoletoEnviarPDFPorEmail.Size = new Size(15, 14);
            ChBox_BoletoEnviarPDFPorEmail.TabIndex = 24;
            ChBox_BoletoEnviarPDFPorEmail.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(13, 108);
            label2.Name = "label2";
            label2.Size = new Size(231, 17);
            label2.TabIndex = 23;
            label2.Text = "Enviar PDF por email ao Criar Boleto:";
            // 
            // Frm_ConfigUC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = CDI_OminiService.Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "Frm_ConfigUC";
            Size = new Size(829, 421);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox Txt_OSTimer;
        private Label label6;
        private GroupBox groupBox3;
        private TextBox Txt_Token;
        private Label label1;
        private GroupBox groupBox6;
        private DateTimePicker DTP_BoletoCobDiaria;
        private Label label3;
        private GroupBox groupBox8;
        private Label label4;
        private GroupBox groupBox7;
        private Label label5;
        private Label label7;
        private DateTimePicker DTP_BoletoSelect;
        private Label label8;
        private GroupBox groupBox9;
        private CheckBox ChBox_BoletoEnviarPDF;
        private Label label9;
        private Label label10;
        private ComponentesPerson.BotaoArredond Btn_BuscarMAC;
        private Label label12;
        private CheckBox ChBox_BoletoEnviarMensFimdesem;
        private Label label11;
        private Label label13;
        private CheckBox ChBox_OSMensCancel;
        private Label label14;
        private CheckBox ChBox_BoletoEnviarMensCancel;
        private Label label15;
        internal DateTimePicker DTP_OSSelect;
        private CheckBox ChBox_BoletoEnviarPDFPorEmail;
        private Label label2;
    }
}
