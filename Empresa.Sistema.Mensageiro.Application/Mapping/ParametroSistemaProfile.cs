using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Mapping
{
    public class ParametroSistemaProfile : Profile
    {
        public ParametroSistemaProfile()
        {
            CreateMap<ParametroSistemaDTO, ParametroSistema>();
            CreateMap<ParametroSistema, ParametroSistemaDTO>();

            CreateMap<ParametroSistema, ParametroSistemaCreateDTO>();
            CreateMap<ParametroSistemaCreateDTO, ParametroSistema>();

            CreateMap<ParametroSistema, ParametroSistemaUpdateDTO>();
            CreateMap<ParametroSistemaUpdateDTO, ParametroSistema>();

            CreateMap<ParametroSistema, ParametroSistemaDTORetorno>();
            CreateMap<ParametroSistemaDTORetorno, ParametroSistema>();
        }
    }
}
