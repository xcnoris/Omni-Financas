using Aplication.IntegradorCRM.Servicos;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models;
using Modelos.IntegradorCRM.Models.EF;
using Modelos.IntegradorCRM.Models.Retornos;
using Modelos.IntegradorCRMRM.Models;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    public class ControleComissoes
    {
        private readonly CrudPedidoSit _crudPedidoSit;
        private readonly CrudComissao _crudComissao;

        public ControleComissoes()
        {
            _crudPedidoSit = new CrudPedidoSit();
            _crudComissao = new CrudComissao();
        }

        public async Task VerificarNovosServicos(DadosAPIModels DadosAPI, DateTime Datetime)
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("Comissao");

                // Busca serviços no DB
                List<RetornoPedidoSit> RetPedidoSit = _crudPedidoSit.BuscarPedidosSitInDB();
                List<RetornoComissao> RetComissaoList = _crudComissao.BuscarComissoesInDB();

                // Passa por cada Pedido que retornar no select
                foreach ( var Pedido in RetPedidoSit)
                {
                    // Log para verificação
                    MetodosGerais.RegistrarLog("Comissao", $"Verificando Pedido {Pedido.id_pedido_venda}...");
                 



                 
                    if (Pedido.situacao != RetComissaoList.Equals(x => x.)
                    {
                        // Atualize a categoria na tabela de relação se necessário
                        EnviarOrdemServiçoForCRM.AtualizarAcao(AtualizarAcao, DadosAPI.Token, OSInTableRelacao);
                        MetodosGerais.RegistrarLog("OS", $"A categoria da ordem de serviço {id_ordemServico} mudou de {IdcategoriaExiste} para {id_Categoria}.");
                    }
                    else
                    {
                        MetodosGerais.RegistrarLog("OS", $"Ordem de serviço {id_ordemServico} já existe na tabela com a mesma categoria.");
                    }
                   
                 
                    
                
            }
            catch (Exception ex)
            {
                MetodosGerais.RegistrarErroExcecao("Comissao", "Erro durante consulta das OS:", ex);
                throw;
            }
            finally
            {
                MetodosGerais.RegistrarFinalLog("Comissao");
            }
        }
    }
}
