using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Cadastro.Infra.Data.Repositories;
using Empresa.Sistema.Infra.Shared.Data.Context.Dapper;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.IoC
{
    public class ConfigureRepository
    {
        //.AddTransient => Para cada operação que tiver uma injeção de dependência ele vai criar uma instância nova 
        //.AddScoped => Ele entrou na aplicação e em 10 requisições ele poderá reaproveitar a mesma instância (ciclo de vida)
        //.AddSingleton -> apartir do start da aplicação, ele não vai mudar (se o serviço for executar a nível de servidor uma única vez)
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //Context
            serviceCollection.AddScoped<IDbContext, DapperContext>();

            serviceCollection.AddScoped<IParametroSistemaRepository, ParametroSistemaRepository>();
            serviceCollection.AddScoped<ITipoParametroSistemaRepository, TipoParametroSistemaRepository>();
        }
    }
}
