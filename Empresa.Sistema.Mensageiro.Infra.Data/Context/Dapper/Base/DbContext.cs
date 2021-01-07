using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Empresa.Sistema.Infra.Shared.Data.Transactions.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Data.Context.Dapper.Base
{
    public class DbContext : IDbContext
    {
        private readonly IConnectionFactory _connectionFactory;
        private bool _disposed = false;

        public DbContext(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public DbConnection GetConnection()
        {
            var _connection = _connectionFactory.Create();
            _connection.Open();

            return _connection;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            DapperUnitOfWork unit = new DapperUnitOfWork(this);
            unit.Create();
            return unit;
        }

    }
}
