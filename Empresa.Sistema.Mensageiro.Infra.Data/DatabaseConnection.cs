using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Empresa.Sistema.Infra.Shared.Data
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;

        private DatabaseConnection()
        {

        }

        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public string Provider { get; set; }

        public static DatabaseConnection CreateInstance(IConfiguration Configuration)
        {
            if(_instance == null)
            {
                _instance = new DatabaseConnection();
            }

            new ConfigureFromConfigurationOptions<DatabaseConnection>(
                Configuration.GetSection("DatabaseConnection"))
                .Configure(_instance);

            return _instance;
        }
    }
}
