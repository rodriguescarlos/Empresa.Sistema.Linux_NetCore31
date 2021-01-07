using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Interface.Services
{
    public interface IPetStoreService
    {
        IEnumerable<Pet> ObterPet();
    }
}
