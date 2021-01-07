using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Service
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetStoreIntegration _petStore;
        private readonly ILogFacede _logger;

        public PetStoreService(ILogFacede logger, IPetStoreIntegration petStore)
        {
            this._petStore = petStore;
            this._logger = logger;
        }

        public IEnumerable<Pet> ObterPet()
        {
            List<string> listaTags = new List<string> { "Teste" };

            return _petStore.ObterPet(listaTags);
        }
    }
}
