using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Infra.Shared.Data.Context.Dapper;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Empresa.Sistema.Infra.Shared.Data.Repositories.Base;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.Data.Repositories
{
    public class TipoParametroSistemaRepository : RepositoryBase<TipoParametroSistema>, ITipoParametroSistemaRepository
    {
        public TipoParametroSistemaRepository(IDbContext dbContext, ILogFacede logger)
            : base(dbContext, logger)
        {

        }



    }
}
