using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using System;
using System.Data;

namespace Empresa.Sistema.Infra.Shared.Data.Transactions.Dapper
{
    public class DapperUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbContext _context;
        private bool _disposed = false;
        private IDbTransaction _transacao;

        public DapperUnitOfWork(IDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if(_context != null)
            {
                _transacao = _context.GetConnection().BeginTransaction(IsolationLevel.ReadCommitted);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if(_transacao != null)
                {
                    _transacao.Dispose();
                }
            }

            _disposed = true;
        }

        public void SaveChanges()
        {
            if(_transacao != null)
            {
                _transacao.Commit();
            }
        }
    }
}
