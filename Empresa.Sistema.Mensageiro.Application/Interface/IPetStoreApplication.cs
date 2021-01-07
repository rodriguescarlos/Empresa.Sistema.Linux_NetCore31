using Empresa.Sistema.Cadastro.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Interface
{
    public interface IPetStoreApplication
    {
        IEnumerable<PetDTO> ObterPet();
    }
}
