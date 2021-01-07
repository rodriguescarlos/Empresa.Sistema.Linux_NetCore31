using System.Collections.Generic;

namespace Empresa.Sistema.Cadastro.Application.Interface.Base
{
    public interface IApplicationService<TEntityDTO, TEntityDTOCreate, TEntityDTOUpdate, TEntityDTORetorno> 
        where TEntityDTOCreate : class
        where TEntityDTOUpdate : class
        where TEntityDTO : class
        where TEntityDTORetorno : class
    {
        TEntityDTORetorno Adicionar(TEntityDTOCreate parametro);

        TEntityDTORetorno Atualizar(TEntityDTOUpdate parametro);

        TEntityDTO ObterPorId(int id);

        IEnumerable<TEntityDTO> ObterTodos();

        bool Remover(int id);
    }
}
