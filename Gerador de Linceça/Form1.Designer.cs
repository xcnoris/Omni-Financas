namespace Gerador_de_Linceça
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Txt_Token = new TextBox();
            label5 = new Label();
            Btn_Gerar = new Button();
            label1 = new Label();
            Txt_EndMac = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // Txt_Token
            // 
            Txt_Token.Location = new Point(95, 26);
            Txt_Token.Name = "Txt_Token";
            Txt_Token.Size = new Size(345, 23);
            Txt_Token.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(12, 106);
            label5.Name = "label5";
            label5.Size = new Size(188, 15);
            label5.TabIndex = 3;
            label5.Text = "Digite o endereço MAC do cliente:";
            // 
            // Btn_Gerar
            // 
            Btn_Gerar.Location = new Point(156, 142);
            Btn_Gerar.Name = "Btn_Gerar";
            Btn_Gerar.Size = new Size(125, 23);
            Btn_Gerar.TabIndex = 4;
            Btn_Gerar.Text = "Gerar Token";
            Btn_Gerar.UseVisualStyleBackColor = true;
            Btn_Gerar.Click += Btn_Gerar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 39);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 5;
            // 
            // Txt_EndMac
            // 
            Txt_EndMac.Location = new Point(206, 103);
            Txt_EndMac.Name = "Txt_EndMac";
            Txt_EndMac.Size = new Size(229, 23);
            Txt_EndMac.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 192, 0);
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(25, 24);
            label2.Name = "label2";
            label2.Size = new Size(64, 25);
            label2.TabIndex = 7;
            label2.Text = "token";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 187);
            Controls.Add(Txt_EndMac);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Btn_Gerar);
            Controls.Add(Txt_Token);
            Controls.Add(label5);
            MaximizeBox = false;
            MaximumSize = new Size(468, 226);
            MinimumSize = new Size(468, 226);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Linceça";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Txt_Token;
        private Label label5;
        private Button Btn_Gerar;
        private Label label1;
        private TextBox Txt_EndMac;
        private Label label2;
    }
}
