using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Mapping
{
    public class TipoParametroSistemaProfile : Profile
    {
        public TipoParametroSistemaProfile()
        {
            CreateMap<TipoParametroSistemaDTO, TipoParametroSistema>();
            CreateMap<TipoParametroSistema, TipoParametroSistemaDTO>();
        }
    }

}
