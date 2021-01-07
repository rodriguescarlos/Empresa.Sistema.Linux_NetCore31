using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Interface
{
    public interface IPetStoreIntegration
    {
        IEnumerable<Pet> ObterPet(IList<string> tags); 
    }
}
