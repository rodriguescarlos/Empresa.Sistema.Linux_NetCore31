using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        void Adicionar(TEntity item);

        void Remover(TEntity item);

        void Atualizar(TEntity item);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos();
    }
}
