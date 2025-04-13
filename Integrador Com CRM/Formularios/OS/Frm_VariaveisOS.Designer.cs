namespace CDI_OminiService.Formularios.OS
{
    partial class Frm_VariaveisOS
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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(34, 56);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(104, 25);
            textBox1.TabIndex = 1;
            textBox1.Text = "<NSU>";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(34, 25);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(104, 25);
            textBox2.TabIndex = 2;
            textBox2.Text = "<ClienteNome>";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(157, 25);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(159, 25);
            textBox3.TabIndex = 3;
            textBox3.Text = "<ClientePrimeiroNome>";
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(34, 87);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(104, 25);
            textBox4.TabIndex = 4;
            textBox4.Text = "<Categoria>";
            // 
            // Frm_VariaveisOS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(328, 166);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MaximumSize = new Size(344, 205);
            MinimizeBox = false;
            MinimumSize = new Size(344, 205);
            Name = "Frm_VariaveisOS";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Variaveis OS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
    }
}