using Aplication.IntegradorCRM.Servicos.Controle_Comissao;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.Retornos;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    public class ControleComissoes
    {
        private readonly CrudPedidoSit _crudPedidoSit;
        private readonly CrudComissao _crudComissao;
        private readonly ComissaoService ComissaoService;
        public ControleComissoes()
        {
            _crudPedidoSit = new CrudPedidoSit();
            _crudComissao = new CrudComissao();
            ComissaoService =new ComissaoService();
        }

        public async Task VerificarComissoes( )
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("Comissao");

                // Busca serviços no DB
                List<RetornoPedidoSit> RetPedidoSit = await _crudPedidoSit.BuscarPedidosSitInDB();
                List<RetornoComissao> RetComissaoList = await _crudComissao.BuscarComissoesInDB();

                if (RetPedidoSit is null | RetComissaoList is null)
                {
                    MetodosGerais.RegistrarLog("Comissao", $"Error: Listas nulas...");
                    return;
                }

                MetodosGerais.RegistrarLog("Comissao", $"Foram encontrados {RetPedidoSit.Count} pedidos!\n");
                // Passa por cada Pedido que retornar no select
                foreach (var Pedido in RetPedidoSit)
                {
                    // Log para verificação
                    MetodosGerais.RegistrarLog("Comissao", $"Verificando Pedido {Pedido.id_pedido_venda}...");

                    RetornoComissao? Comissao = RetComissaoList.FirstOrDefault(x => x.Codigo_Pedido == Pedido.id_pedido_venda);

                    if (Comissao is null)
                    {
                        MetodosGerais.RegistrarLog("Comissao", $"Nenhum registro de comissao registrado para o pedido: {Pedido.id_pedido_venda}");
                        continue;
                    }

                    if (Pedido.situacao != Comissao.Situacao_Pedido)
                    {
                        MetodosGerais.RegistrarLog("Comissao", $"A situacao da comissao {Comissao.Codigo_Pedido} mudou de {Comissao.Situacao_Pedido} para {Pedido.situacao}.");
                        Comissao.Situacao_Pedido = Pedido.situacao;
                        await ComissaoService.AtualizarSituacaoComissao(Comissao);
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("Comissao", $"Comissao {Comissao.Codigo_Pedido} com a mesma situacao. Situacao {Comissao.Situacao_Pedido}");
                    }
                }
                   
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao", "Erro durante consulta das comissoes:", ex);
                throw;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("Comissao");
            }
        }
    }
}
