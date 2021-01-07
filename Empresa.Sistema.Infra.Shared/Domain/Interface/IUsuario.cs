using System.Collections.Generic;
using System.Security.Claims;

namespace Empresa.Sistema.Infra.Shared.Domain.Interface
{
    public interface IUsuario
    {
        string Name { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}
