using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Interface
{
    public interface ITipoParametroSistemaApplication :
        IApplicationService<TipoParametroSistemaDTO, TipoParametroSistemaCreateDTO, TipoParametroSistemaUpdateDTO, TipoParametroSistemaDTORetorno>,
        IApplicationServiceAsync<TipoParametroSistemaDTO, TipoParametroSistemaCreateDTO, TipoParametroSistemaUpdateDTO, TipoParametroSistemaDTORetorno>
    {


    }
}
