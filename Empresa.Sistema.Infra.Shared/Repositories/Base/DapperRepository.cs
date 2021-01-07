using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Empresa.Sistema.Infra.Shared.Domain;
using Empresa.Sistema.Infra.Shared.Data.Mapper;
using System;
using Empresa.Sistema.Infra.Shared.Repositories.Base;
using Empresa.Sistema.Infra.Shared.Data.Context.Dapper;

namespace Empresa.Sistema.Infra.Shared.Repositories.Base
{
    public abstract class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly DapperContext _dbContext;

        public DapperRepository(DapperContext dbContext)
        {
            _dbContext = dbContext;

            //Mapeamento da entidade com a tabela correspondente no banco de dados
            SqlMapperExtensions.TableNameMapper = new SqlMapperExtensions.TableNameMapperDelegate(
                (Type entityType) =>
                {
                    return DapperMapper.TableNameMapper(entityType);
                }
                );
        }

        public virtual void Adicionar(TEntity entidade)
        {
            _dbContext.GetConnection().Insert<TEntity>(entidade);
        }

        public virtual TEntity ObterPorId(int id)
        {
            TEntity retorno = _dbContext.GetConnection().Get<TEntity>(id);

            return retorno;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return _dbContext.GetConnection().GetAll<TEntity>();
        }

        public virtual void Remover(TEntity entidade)
        {
            _dbContext.GetConnection().Delete<TEntity>(entidade);
        }

        public virtual void Atualizar(TEntity entidade)
        {
            _dbContext.GetConnection().Update<TEntity>(entidade);
        }
    }
}
