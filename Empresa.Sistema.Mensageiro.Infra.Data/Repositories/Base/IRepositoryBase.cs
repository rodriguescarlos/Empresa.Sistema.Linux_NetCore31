using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Data.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity entidade);
        Task<TEntity> AdicionarAsync(TEntity entidade);
        TEntity Atualizar(TEntity entidade);
        Task<TEntity> AtualizarAsync(TEntity entidade);
        int Count(object predicate, bool buffered = false);
        int ExecuteNonQuery(string query);
        IEnumerable<TEntity> Obter(Expression<Func<TEntity, object>> expression, object value);
        TEntity ObterPorId(int id);
        Task<TEntity> ObterPorIdAsync(int id);
        IEnumerable<TEntity> ObterTodos();
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        bool Remover(TEntity entidade);
        Task<bool> RemoverAsync(TEntity entidade);
    }
}