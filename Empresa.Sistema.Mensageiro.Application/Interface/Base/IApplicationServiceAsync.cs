using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Application.Interface.Base
{
    public interface IApplicationServiceAsync<TEntityDTO, TEntityDTOCreate, TEntityDTOUpdate, TEntityDTORetorno>
        where TEntityDTOCreate : class
        where TEntityDTOUpdate : class
        where TEntityDTO : class
        where TEntityDTORetorno : class
    {
        Task<TEntityDTORetorno> AdicionarAsync(TEntityDTOCreate entidadeDto);

        Task<TEntityDTORetorno> AtualizarAsync(TEntityDTOUpdate entidadeDto);

        Task<TEntityDTO> ObterPorIdAsync(int id);

        Task<IEnumerable<TEntityDTO>> ObterTodosAsync();

        Task<bool> RemoverAsync(int id);
    }
}
