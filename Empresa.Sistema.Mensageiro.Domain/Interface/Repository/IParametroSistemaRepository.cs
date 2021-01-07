using Empresa.Sistema.Cadastro.Domain.Entidade;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Repository
{
    public interface IParametroSistemaRepository : IRepository<ParametroSistema>, IRepositoryAsync<ParametroSistema>
    {
        ParametroSistema Obter(string paramento);

        Task<ParametroSistema> ObterAsync(string paramento);

    }
}
