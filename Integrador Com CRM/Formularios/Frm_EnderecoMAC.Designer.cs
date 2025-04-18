namespace CDI_OminiService.Formularios
{
    partial class Frm_EnderecoMAC
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
            label1 = new Label();
            Txt_MAC = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 52);
            label1.Name = "label1";
            label1.Size = new Size(125, 21);
            label1.TabIndex = 0;
            label1.Text = "Endereço MAC:";
            // 
            // Txt_MAC
            // 
            Txt_MAC.Location = new Point(155, 50);
            Txt_MAC.Name = "Txt_MAC";
            Txt_MAC.ReadOnly = true;
            Txt_MAC.Size = new Size(155, 23);
            Txt_MAC.TabIndex = 1;
            // 
            // Frm_EnderecoMAC
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fundo_omni;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(337, 131);
            Controls.Add(Txt_MAC);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Frm_EnderecoMAC";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Txt_MAC;
    }
}