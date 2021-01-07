using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Infra.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Application.Servico
{
    public class TipoParametroSistemaServicoApplication : ITipoParametroSistemaApplication
    {
        private readonly IMapper _mapper;

        private ITipoParametroSistemaService _service;
        private ILogFacede _logger;

        public TipoParametroSistemaServicoApplication(ITipoParametroSistemaService tipoParametroSistemaService, IMapper mapper, ILogFacede logger)
        {
            this._service = tipoParametroSistemaService;
            this._mapper = mapper;
            this._logger = logger;
        }

        public TipoParametroSistemaDTORetorno Adicionar(TipoParametroSistemaCreateDTO tipoParametro)
        {
            var entidade = _mapper.Map<TipoParametroSistema>(tipoParametro);
            entidade.DataHoraCriacao = DateTime.Now;

            return _mapper.Map<TipoParametroSistemaDTORetorno>(_service.Adicionar(entidade));
        }

        public async Task<TipoParametroSistemaDTORetorno> AdicionarAsync(TipoParametroSistemaCreateDTO tipoParametro)
        {
            var entidade = _mapper.Map<TipoParametroSistema>(tipoParametro);
            entidade.DataHoraCriacao = DateTime.Now;

            return _mapper.Map<TipoParametroSistemaDTORetorno>(await _service.AdicionarAsync(entidade));
        }

        public TipoParametroSistemaDTORetorno Atualizar(TipoParametroSistemaUpdateDTO tipoParametro)
        {
            var entidade = _mapper.Map<TipoParametroSistema>(tipoParametro);

            return _mapper.Map<TipoParametroSistemaDTORetorno>(_service.Atualizar(entidade));
        }

        public async Task<TipoParametroSistemaDTORetorno> AtualizarAsync(TipoParametroSistemaUpdateDTO tipoParametro)
        {
            var entidade = _mapper.Map<TipoParametroSistema>(tipoParametro);

            return _mapper.Map<TipoParametroSistemaDTORetorno>(await _service.AtualizarAsync(entidade));
        }

        public TipoParametroSistemaDTO ObterPorId(int id)
        {
            var retultado = _service.ObterPorId(id);
            return _mapper.Map<TipoParametroSistemaDTO>(retultado);
        }

        public async Task<TipoParametroSistemaDTO> ObterPorIdAsync(int id)
        {
            var retultado = await _service.ObterPorIdAsync(id);
            return _mapper.Map<TipoParametroSistemaDTO>(retultado);
        }

        public IEnumerable<TipoParametroSistemaDTO> ObterTodos()
        {
            var retultado = _service.ObterTodos();
            return _mapper.Map<IEnumerable<TipoParametroSistemaDTO>>(retultado);
        }

        public async Task<IEnumerable<TipoParametroSistemaDTO>> ObterTodosAsync()
        {
            var retultado = await _service.ObterTodosAsync();
            return _mapper.Map<IEnumerable<TipoParametroSistemaDTO>>(retultado);
        }

        public bool Remover(int id)
        {
            TipoParametroSistema tipoParametro = new TipoParametroSistema();
            tipoParametro.Identificador = id;

            return _service.Remover(tipoParametro);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            TipoParametroSistema tipoParametro = new TipoParametroSistema();
            tipoParametro.Identificador = id;

            return await _service.RemoverAsync(tipoParametro);
        }
    }
}
