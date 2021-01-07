using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Mapping
{
    public class PetStoreProfile : Profile
    {
        public PetStoreProfile()
        {
            CreateMap<PetDTO, Pet>();
            CreateMap<Pet, PetDTO>();
        }
    }
}
