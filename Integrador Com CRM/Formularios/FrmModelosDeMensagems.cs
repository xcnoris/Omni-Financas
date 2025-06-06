

namespace CDI_OminiService.Formularios
{
    public partial class FrmModelosDeMensagems : Form
    {
        public FrmModelosDeMensagems()
        {
            InitializeComponent();
            CriacaoBolHTML();
        }

        private void CriacaoBolHTML()
        {
            Txt_CriacaoBolHTML.Text = @"<!DOCTYPE html>
<html lang=""pt-BR"">
<head>
    <meta charset=""UTF-8"">
    <title>Boleto CDI OmniService</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            color: #333;
            background-color: #f9f9f9;
            padding: 20px;
        }
        .container {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 30px;
            max-width: 600px;
            margin: 0 auto;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            color: #0066cc;
        }
        .section {
            margin-bottom: 20px;
        }
        .info {
            background-color: #f1f1f1;
            padding: 10px;
            border-radius: 8px;
        }
        .info p {
            margin: 5px 0;
        }
        .footer {
            font-size: 12px;
            color: #888;
            text-align: center;
            margin-top: 30px;
        }
        .logo {
            text-align: right;
            margin-top: -30px;
        }
    </style>
</head>
<body>
    <div class=""container"">
        <h2>Olá, <PrimNome_Fantasia> Segue o seu boleto! </h2>

        <div class=""section"">
            <h3>🧾 Dados do Boleto</h3>
            <div class=""info"">
                <p><strong>ID do Documento:</strong> <Id_DR></p>
                <p><strong>Número do Documento:</strong> <Documento_DR></p>
                <p><strong>Data de Vencimento:</strong> <Vencimento></p>
                <p><strong>Valor:</strong> R$ <Valor></p>
            </div>
        </div>

        <div class=""section"">
            <h3>👤 Dados do Cliente</h3>
            <div class=""info"">
                <p><strong>ID Cliente:</strong> <Id_Cliente></p>
                <p><strong>Razão Social:</strong> <NomeComp_RazSocial></p>
                <p><strong>CNPJ/CPF:</strong> <CNPJ_CPF></p>
                <p><strong>Email:</strong> <Email></p>
                <p><strong>Celular:</strong> <Celular></p>
            </div>
        </div>

        <div class=""section"">
            <p>O seu boleto esta anexado logo abaixo :)</p>
        </div>

        <div class=""footer"">
            Este é um e-mail automático enviado pelo sistema CDI OmniService. Não responda.
        </div>
    </div>
</body>
</html>
";
        }
    }
}
