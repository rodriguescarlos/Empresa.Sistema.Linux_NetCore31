using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Services
{
    public interface IParametroSistemaService : IRepository<ParametroSistema>, IRepositoryAsync<ParametroSistema>
    {
        ParametroSistema Obter(string paramento);

        Task<ParametroSistema> ObterAsync(string paramento);
    }
}
