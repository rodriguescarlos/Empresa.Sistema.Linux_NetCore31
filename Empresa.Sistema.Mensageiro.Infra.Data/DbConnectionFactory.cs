using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Data
{
    public class DbConnectionFactory : IConnectionFactory
    {
        protected readonly DbProviderFactory _provider;
        protected readonly string _connectionString;
        protected readonly string _name;

        public DbConnectionFactory(DatabaseConnection dbConnection)
        {
            if (dbConnection == null)
                throw new ConfigurationErrorsException("Falha ao tentar carregar a sessão DatabaseConnection do arquivo de configuração.");

            if (dbConnection.ConnectionString == null) throw new ArgumentNullException("ConnectionString");
                       
            DbProviderFactories.RegisterFactory(dbConnection.Provider, SqlClientFactory.Instance);
            IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames();

            _name = dbConnection.Name;
            _provider = DbProviderFactories.GetFactory(invariants.FirstOrDefault());
            _connectionString = dbConnection.ConnectionString;
        }

        public virtual DbConnection Create()
        {
            var connection = _provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException(string.Format("Falha ao tentar criar a conexão utilizando a string de conexão '{0}' do arquivo de configuração.", _name));

            connection.ConnectionString = _connectionString;
            return connection;
        }
    }
}
