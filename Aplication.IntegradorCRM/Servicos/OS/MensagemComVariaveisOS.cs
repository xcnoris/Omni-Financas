using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class MensagemComVariaveisOS
    {
        internal static string SubstituirVariaveis(string mensagem, RetornoOrdemServico retornoOS)
        {
            var variaveis = new Dictionary<string, string>
            {
                { "<ClienteNome>", retornoOS.Nome_Cliente },
                { "<ClientePrimeiroNome>", retornoOS.Nome_Cliente.Split(' ')[0] },
                { "<NSU>", retornoOS.NSU },
                { "<Categoria>", retornoOS.Categoria }
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
