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
            label2 = new Label();
            label1 = new Label();
            Btn_IdCliente = new Button();
            Btn_NomeSocial = new Button();
            Btn_PrimNome = new Button();
            Btn_CNPJCPF = new Button();
            Btn_Email = new Button();
            Btn_Celular = new Button();
            Btn_IdDR = new Button();
            Btn_DocumentoDR = new Button();
            Btn_Vencimento = new Button();
            Btn_Valor = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(310, 26);
            label2.Name = "label2";
            label2.Size = new Size(113, 19);
            label2.TabIndex = 7;
            label2.Text = "Dados Boleto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(44, 26);
            label1.Name = "label1";
            label1.Size = new Size(116, 19);
            label1.TabIndex = 31;
            label1.Text = "Dados Cliente";
            // 
            // Btn_IdCliente
            // 
            Btn_IdCliente.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_IdCliente.Location = new Point(44, 53);
            Btn_IdCliente.Name = "Btn_IdCliente";
            Btn_IdCliente.Size = new Size(93, 30);
            Btn_IdCliente.TabIndex = 36;
            Btn_IdCliente.Text = "<Id_Cliente>";
            Btn_IdCliente.UseVisualStyleBackColor = true;
            Btn_IdCliente.Click += button1_Click;
            // 
            // Btn_NomeSocial
            // 
            Btn_NomeSocial.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_NomeSocial.Location = new Point(44, 86);
            Btn_NomeSocial.Name = "Btn_NomeSocial";
            Btn_NomeSocial.Size = new Size(174, 30);
            Btn_NomeSocial.TabIndex = 37;
            Btn_NomeSocial.Text = "<NomeComp_RazSocial>";
            Btn_NomeSocial.UseVisualStyleBackColor = true;
            Btn_NomeSocial.Click += Btn_NomeSocial_Click_1;
            // 
            // Btn_PrimNome
            // 
            Btn_PrimNome.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_PrimNome.Location = new Point(44, 119);
            Btn_PrimNome.Name = "Btn_PrimNome";
            Btn_PrimNome.Size = new Size(174, 30);
            Btn_PrimNome.TabIndex = 38;
            Btn_PrimNome.Text = "<PrimNome_Fantasia>";
            Btn_PrimNome.UseVisualStyleBackColor = true;
            Btn_PrimNome.Click += Btn_PrimNome_Click_1;
            // 
            // Btn_CNPJCPF
            // 
            Btn_CNPJCPF.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_CNPJCPF.Location = new Point(44, 152);
            Btn_CNPJCPF.Name = "Btn_CNPJCPF";
            Btn_CNPJCPF.Size = new Size(174, 30);
            Btn_CNPJCPF.TabIndex = 39;
            Btn_CNPJCPF.Text = "<CNPJ_CPF>";
            Btn_CNPJCPF.UseVisualStyleBackColor = true;
            Btn_CNPJCPF.Click += Btn_CNPJCPF_Click;
            // 
            // Btn_Email
            // 
            Btn_Email.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_Email.Location = new Point(44, 185);
            Btn_Email.Name = "Btn_Email";
            Btn_Email.Size = new Size(78, 30);
            Btn_Email.TabIndex = 40;
            Btn_Email.Text = "<Email>";
            Btn_Email.UseVisualStyleBackColor = true;
            Btn_Email.Click += Btn_Email_Click;
            // 
            // Btn_Celular
            // 
            Btn_Celular.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_Celular.Location = new Point(137, 185);
            Btn_Celular.Name = "Btn_Celular";
            Btn_Celular.Size = new Size(81, 30);
            Btn_Celular.TabIndex = 41;
            Btn_Celular.Text = "<Celular>";
            Btn_Celular.UseVisualStyleBackColor = true;
            Btn_Celular.Click += Btn_Celular_Click;
            // 
            // Btn_IdDR
            // 
            Btn_IdDR.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_IdDR.Location = new Point(310, 53);
            Btn_IdDR.Name = "Btn_IdDR";
            Btn_IdDR.Size = new Size(147, 30);
            Btn_IdDR.TabIndex = 42;
            Btn_IdDR.Text = "<Id_DR>";
            Btn_IdDR.UseVisualStyleBackColor = true;
            Btn_IdDR.Click += Btn_IdDR_Click;
            // 
            // Btn_DocumentoDR
            // 
            Btn_DocumentoDR.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_DocumentoDR.Location = new Point(310, 86);
            Btn_DocumentoDR.Name = "Btn_DocumentoDR";
            Btn_DocumentoDR.Size = new Size(145, 30);
            Btn_DocumentoDR.TabIndex = 43;
            Btn_DocumentoDR.Text = "<Documento_DR>";
            Btn_DocumentoDR.UseVisualStyleBackColor = true;
            Btn_DocumentoDR.Click += Btn_DocumentoDR_Click;
            // 
            // Btn_Vencimento
            // 
            Btn_Vencimento.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_Vencimento.Location = new Point(310, 119);
            Btn_Vencimento.Name = "Btn_Vencimento";
            Btn_Vencimento.Size = new Size(147, 30);
            Btn_Vencimento.TabIndex = 44;
            Btn_Vencimento.Text = "<Vencimento>";
            Btn_Vencimento.UseVisualStyleBackColor = true;
            Btn_Vencimento.Click += Btn_Vencimento_Click;
            // 
            // Btn_Valor
            // 
            Btn_Valor.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            Btn_Valor.Location = new Point(310, 152);
            Btn_Valor.Name = "Btn_Valor";
            Btn_Valor.Size = new Size(147, 30);
            Btn_Valor.TabIndex = 45;
            Btn_Valor.Text = "<Valor>";
            Btn_Valor.UseVisualStyleBackColor = true;
            Btn_Valor.Click += Btn_Valor_Click;
            // 
            // Frm_VariaveisBoleto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Cdi_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(540, 238);
            Controls.Add(Btn_Valor);
            Controls.Add(Btn_Vencimento);
            Controls.Add(Btn_DocumentoDR);
            Controls.Add(Btn_IdDR);
            Controls.Add(Btn_Celular);
            Controls.Add(Btn_Email);
            Controls.Add(Btn_CNPJCPF);
            Controls.Add(Btn_PrimNome);
            Controls.Add(Btn_NomeSocial);
            Controls.Add(Btn_IdCliente);
            Controls.Add(label1);
            Controls.Add(label2);
            MaximizeBox = false;
            MaximumSize = new Size(556, 277);
            MinimizeBox = false;
            MinimumSize = new Size(556, 277);
            Name = "Frm_VariaveisBoleto";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Variaveis Boleto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Button Btn_IdCliente;
        private Button Btn_NomeSocial;
        private Button Btn_PrimNome;
        private Button Btn_CNPJCPF;
        private Button Btn_Email;
        private Button Btn_Celular;
        private Button Btn_IdDR;
        private Button Btn_DocumentoDR;
        private Button Btn_Vencimento;
        private Button Btn_Valor;
    }
}