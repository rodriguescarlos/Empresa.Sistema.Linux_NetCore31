using Application.Core.Entity;
using Application.Core.Interfae.Repository;
using Application.Core.ValueObjects;
using Application.Infrastructure.Data.Context.Dapper;
using Application.Infrastructure.Repositories.Base;
using Dapper;
using Empresa.Sistema.Infra.Shared.Data.Context.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories.Dapper
{
    class ClienteRepositorio : DapperRepository<Cliente>, IClienteRepository
    {
        public ClienteRepositorio(DapperContext dbContext)
            : base(dbContext)
        {

        }

        public override Cliente Adicionar(Cliente entidade)
        {
            Cliente cliente = null ;
            using (var db = _dbContext.GetConnection())
            {
                //if (db.State == ConnectionState.Closed)
                //{
                //    db.Open();
                //}
                //DynamicParameters p = new DynamicParameters();
                //p.Add("@FuncionarioID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.AddDynamicParams(new
                //{
                //    Nome = ofunci.Nome,
                //    Email = ofunci.Email,
                //    Endereco = ofunci.Endereco,
                //    Telefone = ofunci.Telefone,
                //    Cargo = ofunci.Cargo,
                //    ImagemUrl = ofunci.ImagemUrl
                //});
                //int resultado = db.Execute("sp_Funcionarios_Inserir", p, commandType: CommandType.StoredProcedure);
                //if (resultado != 0)
                //    return p.Get<int>("@FuncionarioID");
                //return 0;

                cliente = db.Query<Cliente>("SP_IN_CLIENTE"
                    , new
                    {
                        CLI_NOME = entidade.Nome
                        ,
                        CLI_EMAIL = entidade.Email
                        ,
                        CLI_ENDERECO = entidade.Logradouro
                        ,
                        CLI_BAIRRO = entidade.Bairro
                        ,
                        CLI_CIDADE = entidade.Cidade
                        ,
                        CLI_ESTADO = entidade.Estado
                    }
                    , commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return cliente;
        }

        public override Cliente Atualizar(Cliente entidade)
        {
            Cliente cliente = null;

            using (var db = _dbContext.GetConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@COD_CLIENTE", value: entidade.Id, dbType:DbType.Int32, ParameterDirection.Input);
                parameters.Add("@CLI_NOME", value: entidade.Nome);
                parameters.Add("@CLI_EMAIL", value: entidade.Email);
                parameters.Add("@CLI_ENDERECO", value: entidade.Logradouro);
                parameters.Add("@CLI_BAIRRO", value: entidade.Bairro);
                parameters.Add("@CLI_CIDADE", value: entidade.Cidade);
                parameters.Add("@CLI_ESTADO", value: entidade.Estado);

                cliente.Id = db.Execute("SP_UP_CLIENTE", parameters, commandType: CommandType.StoredProcedure);
            }

            return cliente;
        }

        public bool Existe(Expression<Func<Cliente, bool>> where)
        {
            using (var db = _dbContext.GetConnection())
            {
                IQueryable<Cliente> query = this.ObterTodos() as IQueryable<Cliente>;
                return query.Where(where).Count() > 0;
            }
        }

        public IEnumerable<Cliente> Obter(string nome)
        {
            IEnumerable<Cliente> resultado = null;

            using (var db = _dbContext.GetConnection())
            {
                resultado = db.Query<Cliente>("Select * from CLIENTE where CLI_NOME like '@COD_CLIENTE%'",
                    new { CLI_NOME = nome },
                    commandType: CommandType.Text).ToList();
            }

            return resultado;
        }

        public Cliente ObterPorEmailSenha(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public override Cliente ObterPorId(int id)
        {
            Cliente cliente = null;
            using (var db = _dbContext.GetConnection())
            {
                cliente = db.Query<Cliente>("SP_CO_CLIENTE_CODIGO"
                    , new
                    {
                        COD_CLIENTE = id
                    }
                    , commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }

            return cliente;
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            IEnumerable<Cliente> retorno = null;

            using (var db = _dbContext.GetConnection())
            {
                var sql = @"Select
                                 A.COD_CLIENTE 'ID'
                                , A.CLI_ENDERECO 'Logradouro'
                                , A.CLI_BAIRRO 'Bairro'
                                , A.CLI_CIDADE 'Cidade'
                                , A.CLI_ESTADO 'Estado'
                                , A.CLI_SENHA 'Senha'
                                , A.CLI_STATUS 'Status'
                                , C.COD_CLIENTE 'Cliente_ID'
                                , A.CLI_NOME 'NomeCompleto'
                                , E.COD_CLIENTE 'Email_ID'
                                , A.CLI_EMAIL 'Endereco'
                                from CLIENTE A INNER JOIN (SELECT B.COD_CLIENTE, B.CLI_NOME FROM CLIENTE B) C
                                ON A.COD_CLIENTE = C.COD_CLIENTE
                                INNER JOIN (SELECT D.COD_CLIENTE, D.CLI_NOME FROM CLIENTE D) E
                                ON A.COD_CLIENTE = E.COD_CLIENTE";

                retorno = db.Query<Cliente, Nome, Email, Cliente>(sql, (cliente, nome, email) => { cliente.Nome = nome; cliente.Email = email; return cliente; }, splitOn: "Cliente_ID,Email_ID", commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public override void Remover(Cliente entidade)
        {
            int resultado = 0;

            using (var db = _dbContext.GetConnection())
            {
                resultado = db.Execute("delete from CLIENTE where COD_CLIENTE= @COD_CLIENTE", 
                    new { COD_CLIENTE = entidade.Id},
                    commandType: CommandType.Text);
            }

            //resultado != 0;
        }
    }
}
