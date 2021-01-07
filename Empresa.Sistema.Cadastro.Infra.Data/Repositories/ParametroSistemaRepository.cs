using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Infra.Shared.Data.Interfaces;
using Empresa.Sistema.Infra.Shared.Data.Repositories.Base;
using Infra.Logging.Interface;

namespace Empresa.Sistema.Cadastro.Infra.Data.Repositories
{
    public class ParametroSistemaRepository : RepositoryBase<ParametroSistema>, IParametroSistemaRepository
    {
        public ParametroSistemaRepository(IDbContext dbContext, ILogFacede logger)
            : base(dbContext, logger)
        {

        }


        public ParametroSistema Obter(string parametro)
        {
            ParametroSistema parametroRetorno = null;
            try
            {
                parametroRetorno = base.Obter(p => p.Nome, parametro).FirstOrDefault();
            }
            catch(Exception ex)
            {
                base._logger.Write(ex);
                throw;
            }

            return parametroRetorno;
        }

        public async Task<ParametroSistema> ObterAsync(string paramento)
        {
            try
            {
                using (var db = _dbContext.GetConnection())
                {
                    var result = await db.QueryAsync<ParametroSistema>("SP_CO_Parametro_Nome"
                        , new
                        {
                            P_Nome = paramento
                        }
                        , commandType: System.Data.CommandType.StoredProcedure);

                    return result.ToList().FirstOrDefault<ParametroSistema>();
                }
            }
            catch (Exception ex)
            {
                base._logger.Write(ex);
                throw;
            }
        }
    }
}
