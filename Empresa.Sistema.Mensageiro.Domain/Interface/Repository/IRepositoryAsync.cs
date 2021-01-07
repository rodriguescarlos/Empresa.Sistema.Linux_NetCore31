using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Repository
{
    public interface IRepositoryAsync<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> AdicionarAsync(TEntity entidade);

        Task<TEntity> ObterPorIdAsync(int id);

        Task<IEnumerable<TEntity>> ObterTodosAsync();

        Task<bool> RemoverAsync(TEntity entidade);

        Task<TEntity> AtualizarAsync(TEntity entidade);
    }
}
