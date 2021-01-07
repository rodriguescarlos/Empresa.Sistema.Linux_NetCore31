using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Adicionar(TEntity entidade);

        bool Remover(TEntity entidade);

        TEntity Atualizar(TEntity entidade);

        TEntity ObterPorId(int id);

        IEnumerable<TEntity> ObterTodos();
    }
}
