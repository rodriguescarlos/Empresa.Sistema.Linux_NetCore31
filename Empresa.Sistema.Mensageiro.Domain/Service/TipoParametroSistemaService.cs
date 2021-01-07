using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Service
{
    public class TipoParametroSistemaService : ITipoParametroSistemaService
    {
        private readonly ITipoParametroSistemaRepository _repository;
        private readonly ILogFacede _logger;


        public TipoParametroSistemaService(ITipoParametroSistemaRepository repository, ILogFacede logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public TipoParametroSistema Adicionar(TipoParametroSistema entidade)
        {
            return _repository.Adicionar(entidade);
        }

        public TipoParametroSistema Atualizar(TipoParametroSistema entidade)
        {
            return _repository.Atualizar(entidade);
        }

        public TipoParametroSistema ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TipoParametroSistema> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public bool Remover(TipoParametroSistema entidade)
        {
            return _repository.Remover(entidade);
        }

        public async Task<TipoParametroSistema> AdicionarAsync(TipoParametroSistema entidade)
        {
            return await _repository.AdicionarAsync(entidade);
        }

        public async Task<TipoParametroSistema> AtualizarAsync(TipoParametroSistema entidade)
        {
            return await _repository.AtualizarAsync(entidade);
        }

        public async Task<TipoParametroSistema> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<TipoParametroSistema>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<bool> RemoverAsync(TipoParametroSistema entidade)
        {
            return await _repository.RemoverAsync(entidade);
        }

        public void Dispose()
        {
            new NotImplementedException();
        }

    }
}
