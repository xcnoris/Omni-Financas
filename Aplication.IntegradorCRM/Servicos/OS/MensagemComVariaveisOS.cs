using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Servicos.OS
{
    internal class MensagemComVariaveisOS
    {
        internal static string SubstituirVariaveis(string mensagem, RetornoOrdemServico retornoOS)
        {
            var variaveis = new Dictionary<string, string>
            {
                { "<Id_Cliente>", retornoOS.Id_entidade },
                { "<NomeComp_RazSocial>", retornoOS.Nome_RazSocial },
                { "<PrimNome_Fantasia>", retornoOS.PrimNome_Fantasia },
                { "<CNPJ_CPF>", retornoOS.Identificador_Cliente },
                { "<Email>", retornoOS.Email_Cliente },
                { "<Celular>", retornoOS.Celular },

                { "<Id_OS>", retornoOS.Id_Ordem_Servico },
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
