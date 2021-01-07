using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.Servico
{
    public class PetStoreApplication : IPetStoreApplication
    {
        private readonly IMapper _mapper;

        private IPetStoreService _service;
        private ILogFacede _logger;


        public PetStoreApplication(IPetStoreService petStore, IMapper mapper, ILogFacede logger)
        {
            this._service = petStore;
            this._mapper = mapper;
            this._logger = logger;
        }

        public IEnumerable<PetDTO> ObterPet()
        {
            var retorno = _service.ObterPet();

            return _mapper.Map<IEnumerable<PetDTO>>(retorno);
        }
    }
}
