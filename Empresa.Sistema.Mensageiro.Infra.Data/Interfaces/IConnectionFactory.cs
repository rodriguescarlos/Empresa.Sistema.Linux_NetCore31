using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Data.Interfaces
{
    public interface IConnectionFactory
    {
        DbConnection Create();
    }
}
