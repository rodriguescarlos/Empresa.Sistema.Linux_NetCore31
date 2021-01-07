using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Repository;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Domain.Service
{
    public class ParametroSistemaService : IParametroSistemaService
    {
        private readonly IParametroSistemaRepository _repository;
        private readonly ILogFacede _logger;

        public ParametroSistemaService(IParametroSistemaRepository repository, ILogFacede logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public ParametroSistema Adicionar(ParametroSistema entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            return _repository.Adicionar(entidade);
        }

        public ParametroSistema Atualizar(ParametroSistema entidade)
        {
            return _repository.Atualizar(entidade);
        }

        public ParametroSistema ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<ParametroSistema> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public bool Remover(ParametroSistema entidade)
        {
            return _repository.Remover(entidade);
        }

        public ParametroSistema Obter(string paramento)
        {
            return _repository.Obter(paramento);
        }

        public async Task<ParametroSistema> AdicionarAsync(ParametroSistema entidade)
        {
            return await _repository.AdicionarAsync(entidade);
        }

        public async Task<ParametroSistema> AtualizarAsync(ParametroSistema entidade)
        {
            return await _repository.AtualizarAsync(entidade);
        }

        public async Task<ParametroSistema> ObterPorIdAsync(int id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<ParametroSistema>> ObterTodosAsync()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<bool> RemoverAsync(ParametroSistema entidade)
        {
            return await _repository.RemoverAsync(entidade);
        }

        public async Task<ParametroSistema> ObterAsync(string paramento)
        {
            return await _repository.ObterAsync(paramento);
        }

        public void Dispose()
        {
            new NotImplementedException();
        }
    }
}
