using DataBase.IntegradorCRM.Data;
using DataBase.IntegradorCRM.Data.DataBase;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Retornos;
using System.Data;

namespace Aplication.IntegradorCRM.Servicos.Controle_Comissao
{
    internal class ComissaoService
    {

        internal async Task VerificarPedidoSemDR(
            Controle_Liberacao_ComissaoModel retComissao,
            List<Controle_Liberacao_ComissaoModel> controleComissaoList,
            DAL<Controle_Liberacao_ComissaoModel> dalComissao)
        {
            try
            {
                MetodosGerais.RegistrarLog("Comissao", $"PV {retComissao.Id_Pedido_Venda} não tem DR gerados.");
                // Verfifica se o Id do pedido de venda existe na tabela de controle de liberação de comissao.
                if (controleComissaoList.FirstOrDefault(x => x.Id_Pedido_Venda.Equals(retComissao.Id_Pedido_Venda)) is null)
                {
                    await dalComissao.AdicionarAsync(retComissao);
                    MetodosGerais.RegistrarLog("Comissao", $"PV {retComissao.Id_Pedido_Venda} foi add a TB de controle!");
                }
                else
                {

                    MetodosGerais.RegistrarLog("Comissao", $"PV {retComissao.Id_Pedido_Venda} já esta na TB de controle!");
                };
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao", $"Erro ao verificar PV {retComissao.Id_Pedido_Venda}:", ex);
                throw;
            }
        }

        internal async Task VerificarPedidoComDR(
            Controle_Liberacao_ComissaoModel retComissao,
            List<Controle_Liberacao_ComissaoModel> controleComissaoList,
            DAL<Controle_Liberacao_ComissaoModel> dalComissao)
        {
            try
            {
                Controle_Liberacao_ComissaoModel? ComissaoExistente = controleComissaoList.FirstOrDefault(x => x.Id_Documento_Receber.Equals(retComissao.Id_Documento_Receber));
                //if (ComissaoExistente is null)
                if (true)
                {
                    await dalComissao.AdicionarAsync(retComissao);
                    MetodosGerais.RegistrarLog("Comissao", $"Parcela/DR {retComissao.Id_Documento_Receber} do PV {retComissao.Id_Pedido_Venda} foi add a TB de controle!");
                }
                else
                {
                    if (retComissao.Data_Quitacao is not null && ComissaoExistente.Data_Quitacao is  null)
                    {
                        await dalComissao.AtualizarAsync(retComissao);
                        MetodosGerais.RegistrarLog("Comissao", $"Parcela/DR {retComissao.Id_Documento_Receber} do PV {retComissao.Id_Pedido_Venda} foi atualizada para quitada na TB de controle!");
                    }
                }
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao", $"Erro ao verificar Parcela/DR {retComissao.Id_Documento_Receber} do PV {retComissao.Id_Pedido_Venda}:", ex);
                throw;
            }
        }

    }
}
