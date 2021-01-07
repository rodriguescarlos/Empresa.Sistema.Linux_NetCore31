using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using System;
using System.Data;
using System.Data.Common;

namespace Empresa.Sistema.Infra.Shared.Data.Interfaces
{
    public interface IDbContext
    {
        IUnitOfWork CreateUnitOfWork();

        DbConnection GetConnection();
    }
}