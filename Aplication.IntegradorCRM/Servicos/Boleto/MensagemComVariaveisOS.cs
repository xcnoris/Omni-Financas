using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class MensagemComVariaveisBoleto
    {
        internal static string SubstituirVariaveis(string mensagem, RetornoBoleto retornoBoleto)
        {
            var variaveis = new Dictionary<string, string>
            {
                { "<Documento>", retornoBoleto.Documento },
                { "<EmailCliente>", retornoBoleto.Email },
                { "<NomeComp_RazSocial>", retornoBoleto.Nome_RazSocial },
                { "<PrimNome_Fantasia>", retornoBoleto.PrimNome_Fantasia },
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
