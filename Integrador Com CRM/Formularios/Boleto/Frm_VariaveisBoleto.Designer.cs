namespace CDI_OminiService.Formularios.Boleto
{
    partial class Frm_VariaveisBoleto
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(46, 35);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 25);
            textBox1.TabIndex = 0;
            textBox1.Text = "<Documento>";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(46, 77);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(100, 25);
            textBox2.TabIndex = 1;
            textBox2.Text = "<Cliente>";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(46, 122);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 25);
            textBox3.TabIndex = 2;
            textBox3.Text = "<Vencimento>";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(191, 77);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(100, 25);
            textBox4.TabIndex = 3;
            textBox4.Text = "<Valor>";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(191, 35);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(100, 25);
            textBox5.TabIndex = 4;
            textBox5.Text = "<EmailCliente>";
            // 
            // Frm_VariaveisBoleto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(328, 166);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MaximumSize = new Size(344, 205);
            MinimizeBox = false;
            MinimumSize = new Size(344, 205);
            Name = "Frm_VariaveisBoleto";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Variaveis Boleto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
    }
}