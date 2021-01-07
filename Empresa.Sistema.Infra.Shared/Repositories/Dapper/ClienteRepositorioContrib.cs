using Application.Core.Entity;
using Application.Core.Interfae.Repository;
using Application.Infrastructure.Data.Context.Dapper;
using Application.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace Application.Infrastructure.Dados.Repositories.Dapper
{
    public class ClienteRepositorioContrib : DapperRepository<Cliente>, IClienteRepository
    {
        public ClienteRepositorioContrib(DapperContext dbContext)
            : base(dbContext)
        {

        }
        public bool Existe(Expression<Func<Cliente, bool>> where)
        {
            SqlConnection db = _dbContext.GetConnection();
            IQueryable<Cliente> query = db.GetAll<Cliente>() as IQueryable<Cliente>;
            return query.Where(where).Count() > 0;
        }

        public IEnumerable<Cliente> Obter(string nome)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
