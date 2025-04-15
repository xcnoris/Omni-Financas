using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class MensagemComVariaveisBoleto
    {
        internal static string SubstituirVariaveis(string mensagem, RetornoBoleto retornoBoleto)
        {
            var variaveis = new Dictionary<string, string>
            {
                { "<Id_Cliente>", retornoBoleto.Id_Entidade },
                { "<NomeComp_RazSocial>", retornoBoleto.Nome_RazSocial },
                { "<PrimNome_Fantasia>", retornoBoleto.PrimNome_Fantasia },
                { "<CNPJ_CPF>", retornoBoleto.Identificador_Cliente },
                { "<Email>", retornoBoleto.Email },
                { "<Celular>", retornoBoleto.Celular },

                { "<Id_DR>", retornoBoleto.Id_DocReceber },
                { "<Documento_DR>", retornoBoleto.Documento },
                { "<Vencimento>", retornoBoleto.Data_Vencimento.ToString("dd/MM/yyyy")},
                { "<Valor>", retornoBoleto.Valor }
                // Adicione mais variáveis aqui, se precisar
            };

            foreach (var item in variaveis)
            {
                mensagem = mensagem.Replace(item.Key, item.Value);
            }
            return mensagem;
        }
    }
}
