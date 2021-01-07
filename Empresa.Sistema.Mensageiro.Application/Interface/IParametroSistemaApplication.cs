using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface.Base;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Application.Interface
{
    public interface IParametroSistemaApplication : 
        IApplicationService<ParametroSistemaDTO, ParametroSistemaCreateDTO, ParametroSistemaUpdateDTO, ParametroSistemaDTORetorno> ,
        IApplicationServiceAsync<ParametroSistemaDTO, ParametroSistemaCreateDTO, ParametroSistemaUpdateDTO, ParametroSistemaDTORetorno>
    {
        Task<ParametroSistemaDTORetorno> ObterAsync(string paramento);

        ParametroSistemaDTORetorno Obter(string paramento);
        

    }
}
