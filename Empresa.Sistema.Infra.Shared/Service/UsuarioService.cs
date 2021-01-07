using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Empresa.Sistema.Infra.Shared.Domain.Interface;
using Microsoft.AspNetCore.Http;

namespace Empresa.Sistema.Infra.Shared.Service
{
    public class UsuarioService : IUsuario
    {
        private readonly IHttpContextAccessor _accessor;

        public UsuarioService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Email => _accessor.HttpContext.User.Identity.Name;

        public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

        public string IP => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Authentication)?.Value;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
