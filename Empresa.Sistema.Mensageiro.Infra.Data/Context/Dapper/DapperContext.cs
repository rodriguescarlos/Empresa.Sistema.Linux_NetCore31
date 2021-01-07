using Empresa.Sistema.Infra.Shared.Data.Context.Dapper.Base;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Empresa.Sistema.Infra.Shared.Data.Context.Dapper
{
    public class DapperContext : DbContext
    {
        public DapperContext(IConfiguration Configuration)
            :base(new DbConnectionFactory(DatabaseConnection.CreateInstance(Configuration)))
        {

        }

        public DapperContext(IConnectionFactory connectionFactory)
            :base(connectionFactory)
        {

        }

    }
}
