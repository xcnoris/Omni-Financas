using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Mail;

namespace Gerador_de_Linceça
{
    public partial class Form1 : Form
    {
        private static string SecretKey = "casadainformaticacdisoftware2005123654789JeovaDeusPorTodaEternidade@#$%";

        public Form1()
        {
            InitializeComponent();
        }

        public static string GenerateToken(string macAddress)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SecretKey));
            var tokenBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(macAddress));
            return Convert.ToBase64String(tokenBytes);
        }

        private void Btn_Gerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_EndMac.Text))
            {
                MessageBox.Show("Endereço MAC inválido.","Endereço Mac Nulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gerar o token
            string enderecomac = Txt_EndMac.Text.Replace("-","").Trim().Replace(".","");

            string token = GenerateToken(enderecomac);
            Txt_Token.Text = token;
            MessageBox.Show("Token Gerado!", "Endereço Mac Gerado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Txt_EndMac.Text = "";
        }
    }
}
