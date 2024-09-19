

using Integrador_Com_CRM.Metodos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Integrador_Com_CRM.Data
{
    internal class DAL<T> where T : class
    {
        private readonly IntegradorDBContext context;

        public DAL(IntegradorDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Listar()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch(Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T>> ListarAsync()
        {
            try
            {
                return await context.Set<T>().ToListAsync();

            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return null;
            }
        }

        public void Adicionar(T objeto)
        {
            try
            {
                context.Set<T>().Add(objeto);
                context.SaveChanges();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
            }
        }

        public async Task AdicionarAsync(T objeto)
        {
            try
            {
                await context.Set<T>().AddAsync(objeto);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                MetodosGerais.RegistrarLog("Conexao", ex.Message);
                throw;
            }
        }

        public void Atualizar(T objeto)
        {
            try
            {
                context.Set<T>().Update(objeto);
                context.SaveChanges();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
            }
        }

        public async Task AtualizarAsync(T objeto)
        {
            try
            {
                context.Set<T>().Update(objeto);
                await context.SaveChangesAsync();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
            }
        }

        public void Deletar(T objeto)
        {
            try
            {
                context.Set<T>().Remove(objeto);
                context.SaveChanges();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
            }
        }

        public async Task DeletarAsync(T objeto)
        {
            try
            {
                context.Set<T>().Remove(objeto);
                await context.SaveChangesAsync();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
            }
        }

        public T? BuscarPor(Func<T, bool> condicao)
        {
            try
            {
                return context.Set<T>().FirstOrDefault(condicao);
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return null;
            }
        }

        public async Task<T?> BuscarPorAsync(Expression<Func<T, bool>> condicao)
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(condicao);
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return null;
            }
        }

        public async Task<T?> RecuperarPorAsync(Expression<Func<T, bool>> condicao, string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = context.Set<T>();

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return await query.FirstOrDefaultAsync(condicao);
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T?>> RecuperarTodosPorAsync(Expression<Func<T, bool>> condicao, string includeProperties = "")
        {
            try
            {
                IQueryable<T> query = context.Set<T>();

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return await query.Where(condicao).ToListAsync();
            }
            catch (Exception Exception)
            {
                MetodosGerais.RegistrarLog("Conexao", Exception.Message);
                return Enumerable.Empty<T>();
            }
        }
    }
}
