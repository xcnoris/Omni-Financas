using Aplication.IntegradorCRM.Servicos.Controle_Comissao;
using DataBase.IntegradorCRM.Data;
using Metodos.IntegradorCRM.Metodos;
using Modelos.IntegradorCRM.Models.EF;

namespace Aplication.IntegradorCRM.Metodos.ControleComissao
{
    public class ControleComissoes
    {
        private readonly CrudControlComissao _crudControleComissao;
        private readonly DAL<Controle_Liberacao_ComissaoModel> dalComissao;
        private readonly ComissaoService comissaoService;
        public ControleComissoes()
        {
            _crudControleComissao = new CrudControlComissao();
            comissaoService = new ComissaoService();
            dalComissao = new DAL<Controle_Liberacao_ComissaoModel>(new IntegradorDBContext());
        }

        public async Task VerificarComissoes( )
        {
            try
            {
                MetodosGerais.RegistrarInicioLog("Comissao");

                // Busca serviços no DB
                List<Controle_Liberacao_ComissaoModel> RetControleCoissao = await _crudControleComissao.BuscarPedidosSitInDB();
                List<Controle_Liberacao_ComissaoModel> controleComissaoList = (await dalComissao.ListarAsync()).ToList();

                using DAL<Controle_Liberacao_ComissaoModel> _dalComissao = new DAL<Controle_Liberacao_ComissaoModel>(new IntegradorDBContext());
                foreach (var retComissao in RetControleCoissao)
                {
                    MetodosGerais.RegistrarLog("Comissao", $"Verificando PV {retComissao.Id_Pedido_Venda}...");
                    // Verifica se existe documento criado, caso não exista significa que o cliente pagou avista.
                    if (retComissao.Id_Documento_Receber == 0)
                    {
                         comissaoService.VerificarPedidoSemDR(retComissao, controleComissaoList, dalComissao);
                    }
                    else
                    {
                         comissaoService.VerificarPedidoComDR(retComissao, controleComissaoList, dalComissao);
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
