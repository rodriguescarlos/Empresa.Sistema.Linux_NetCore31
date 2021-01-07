using System.Collections.Generic;
using System;
using Infra.Logging.Interface;
using System.Threading.Tasks;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using System.Linq.Expressions;
using DapperExtensions;
using System.Data.SqlClient;
using System.Data.Common;

namespace Empresa.Sistema.Infra.Shared.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IDbContext _dbContext;
        protected readonly ILogFacede _logger;

        public RepositoryBase(IDbContext dbContext, ILogFacede logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public virtual TEntity Adicionar(TEntity entidade)
        {
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    DapperExtensions.DapperExtensions.Insert<TEntity>(conn, entidade);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return entidade;
        }

        public virtual TEntity ObterPorId(int id)
        {
            TEntity retorno = default(TEntity);

            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    retorno = DapperExtensions.DapperExtensions.Get<TEntity>(conn, id);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return retorno;
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            IEnumerable<TEntity> retorno = default(IEnumerable<TEntity>);
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    retorno = DapperExtensions.DapperExtensions.GetList<TEntity>(conn);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }
            return retorno;
        }

        public virtual bool Remover(TEntity entidade)
        {
            bool retorno = false;
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    DapperExtensions.DapperExtensions.Delete<TEntity>(conn, entidade);
                }

                retorno = true;
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return retorno;
        }

        public virtual TEntity Atualizar(TEntity entidade)
        {
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    DapperExtensions.DapperExtensions.Update<TEntity>(conn, entidade);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return entidade;
        }

        public async virtual Task<TEntity> AdicionarAsync(TEntity entidade)
        {
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    await DapperExtensions.DapperExtensions.Insert<TEntity>(conn as DbConnection, entidade);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return entidade;
        }

        public virtual async Task<TEntity> ObterPorIdAsync(int id)
        {
            TEntity retorno = default(TEntity);

            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    retorno = await DapperAsyncExtensions.GetAsync<TEntity>(conn, id);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return retorno;
        }

        public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            IEnumerable<TEntity> retorno = default(IEnumerable<TEntity>);
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    retorno = await DapperAsyncExtensions.GetListAsync<TEntity>(conn);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }
            return retorno;
        }

        public virtual async Task<bool> RemoverAsync(TEntity entidade)
        {
            bool retorno = false;
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    await DapperAsyncExtensions.DeleteAsync<TEntity>(conn, entidade);
                }

                retorno = true;
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return retorno;
        }

        public virtual async Task<TEntity> AtualizarAsync(TEntity entidade)
        {
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    await conn.UpdateAsync<TEntity>(entidade);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return entidade;
        }

        public virtual IEnumerable<TEntity> Obter(Expression<Func<TEntity, object>> expression, object value)
        {
            using (var conn = _dbContext.GetConnection())
            {
                var predicate = Predicates.Field<TEntity>(expression, Operator.Eq, value);
                return conn.GetList<TEntity>(predicate);
            }
        }

        public virtual IEnumerable<TEntity> Obter(Expression<Func<TEntity, object>> expression, Operator operador, object value)
        {
            using (var conn = _dbContext.GetConnection())
            {
                var predicate = Predicates.Field<TEntity>(expression, operador, value);
                return conn.GetList<TEntity>(predicate);
            }
        }

        public int Count(object predicate, bool buffered = false)
        {
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    return conn.Count<TEntity>(predicate);
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }
        }


        public int ExecuteNonQuery(string query)
        {
            int retorno = 0;
            try
            {
                using (var conn = _dbContext.GetConnection())
                {
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = System.Data.CommandType.Text;
                        command.Connection = conn;

                        retorno = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Write(ex);
                throw;
            }

            return retorno;
        }
    }
}
