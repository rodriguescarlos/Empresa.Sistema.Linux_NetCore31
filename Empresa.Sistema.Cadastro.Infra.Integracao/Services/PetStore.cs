using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface;
using Empresa.Sistema.Cadastro.Infra.Integracao.ApiClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Cadastro.Infra.Integracao.Services
{
    public class PetStore : IPetStoreIntegration
    {

        private readonly ISwaggerPetstore swaggerPetstore;

        public PetStore(ISwaggerPetstore petStore)
        {
            swaggerPetstore = petStore;
        }

        public IEnumerable<Pet> ObterPet(IList<string> tags)
        {
            IList<ApiClient.Models.Pet> pets = swaggerPetstore.FindPetsByStatus(new List<string> { "pending" });

            List<Pet> retorno = new List<Pet>();
            foreach(ApiClient.Models.Pet pet in pets)
            {
                retorno.Add(Traduzir(pet));
            }

            return retorno;
        }

        private Pet Traduzir(ApiClient.Models.Pet item)
        {
            Pet pet = new Pet();

            pet.Id = item.Id;
            pet.Name = item.Name;
            pet.PhotoUrls = item.PhotoUrls;
            pet.Category = Traduzir(item.Category);

            Pet.StatusEnum status = Pet.StatusEnum.PendingEnum;
            Enum.TryParse<Pet.StatusEnum>(item.Status, out status);

            pet.Status = status;

            if (item.Tags != null)
            {
                List<Tag> tags = new List<Tag>();
                foreach (ApiClient.Models.Tag tagItem in item.Tags)
                {
                    tags.Add(Traduzir(tagItem));
                }

                pet.Tags = tags;
            }

            return pet;
        }

        private Tag Traduzir(ApiClient.Models.Tag item)
        {
            Tag tag = null;

            if (item != null)
            {
                tag = new Tag();
                tag.Id = item.Id;
                tag.Name = item.Name;
            }

            return tag;
        }

        private Category Traduzir(ApiClient.Models.Category item)
        {
            Category cat = null;

            if (item != null)
            {
                cat = new Category();
                cat.Id = item.Id;
                cat.Name = item.Name;
            }

            return cat;
        }
    }
}
