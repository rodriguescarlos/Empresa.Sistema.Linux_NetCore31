using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IDbTransaction Transacao { get; }

        void SaveChanges();
    }
}
