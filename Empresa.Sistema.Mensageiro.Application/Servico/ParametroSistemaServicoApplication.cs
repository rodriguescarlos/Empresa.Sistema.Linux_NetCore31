using AutoMapper;
using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Cadastro.Application.Interface.Base;
using Empresa.Sistema.Cadastro.Domain.Entidade;
using Empresa.Sistema.Cadastro.Domain.Interface.Services;
using Empresa.Sistema.Infra.Shared.Domain;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.Application.Servico
{
    public class ParametroSistemaServicoApplication : IParametroSistemaApplication
    {
        private readonly IMapper _mapper;

        private IParametroSistemaService _service;
        private ILogFacede _logger;

        private  AuthenticatedUser _user { get; }

        public ParametroSistemaServicoApplication(
            IParametroSistemaService parametroSistemaService, 
            IMapper mapper, 
            ILogFacede logger,
            AuthenticatedUser user
            )
        {
            this._service = parametroSistemaService;
            this._mapper = mapper;
            this._logger = logger;
            this._user = user;
        }

        public ParametroSistemaDTORetorno Adicionar(ParametroSistemaCreateDTO parametro)
        {
            var parametroEntity = _mapper.Map<ParametroSistema>(parametro);
            parametroEntity.DataCriacao = DateTime.Now;
            parametroEntity.DataAlteracao = DateTime.Now;
            parametroEntity.UsuarioCriacao = (string.IsNullOrEmpty(_user.Name)?string.Empty:_user.Name);
            parametroEntity.UsuarioAlteracao = parametroEntity.UsuarioCriacao;

            return _mapper.Map<ParametroSistemaDTORetorno>(_service.Adicionar(parametroEntity));
        }

        public ParametroSistemaDTORetorno Atualizar(ParametroSistemaUpdateDTO parametro)
        {
            var parametroEntity = _mapper.Map<ParametroSistema>(parametro);

            parametroEntity.DataAlteracao = DateTime.Now;
            parametroEntity.UsuarioAlteracao = (string.IsNullOrEmpty(_user.Name) ? string.Empty : _user.Name);

            return _mapper.Map<ParametroSistemaDTORetorno>(_service.Atualizar(parametroEntity));
        }

        public ParametroSistemaDTO ObterPorId(int id)
        {
            var retultado = _service.ObterPorId(id);
            return _mapper.Map<ParametroSistemaDTO>(retultado);
        }

        public IEnumerable<ParametroSistemaDTO> ObterTodos()
        {
            var resultado = _service.ObterTodos();
            return _mapper.Map<IEnumerable<ParametroSistemaDTO>>(resultado);
        }

        public bool Remover(int id)
        {
            ParametroSistema parametro = new ParametroSistema();
            parametro.Identificador = id;

            return _service.Remover(parametro);
        }

        public ParametroSistemaDTORetorno Obter(string paramento)
        {
            var resultado = _service.Obter(paramento);
            return _mapper.Map<ParametroSistemaDTORetorno>(resultado);
        }

        public async Task<ParametroSistemaDTORetorno> AdicionarAsync(ParametroSistemaCreateDTO parametro)
        {
            var parametroEntity = _mapper.Map<ParametroSistema>(parametro);
            parametroEntity.DataCriacao = DateTime.Now;
            parametroEntity.DataAlteracao = DateTime.Now;
            parametroEntity.UsuarioCriacao = (string.IsNullOrEmpty(_user.Name) ? string.Empty : _user.Name);
            parametroEntity.UsuarioAlteracao = parametroEntity.UsuarioCriacao;

            return _mapper.Map<ParametroSistemaDTORetorno>(await _service.AdicionarAsync(parametroEntity));
        }

        public async Task<ParametroSistemaDTORetorno> AtualizarAsync(ParametroSistemaUpdateDTO parametro)
        {
            var parametroEntity = _mapper.Map<ParametroSistema>(parametro);

            parametroEntity.DataAlteracao = DateTime.Now;
            parametroEntity.UsuarioAlteracao = (string.IsNullOrEmpty(_user.Name) ? string.Empty : _user.Name);

            return _mapper.Map<ParametroSistemaDTORetorno>(await _service.AtualizarAsync(parametroEntity));
        }

        public async Task<ParametroSistemaDTO> ObterPorIdAsync(int id)
        {
            var retultado = await _service.ObterPorIdAsync(id);
            return _mapper.Map<ParametroSistemaDTO>(retultado);
        }

        public async Task<IEnumerable<ParametroSistemaDTO>> ObterTodosAsync()
        {
            var resultado = await _service.ObterTodosAsync();
            return _mapper.Map<IEnumerable<ParametroSistemaDTO>>(resultado);
        }

        public async Task<bool> RemoverAsync(int id)
        {
            ParametroSistema parametro = new ParametroSistema();
            parametro.Identificador = id;

            return await _service.RemoverAsync(parametro);
        }

        public async Task<ParametroSistemaDTORetorno> ObterAsync(string paramento)
        {
            var resultado = await _service.ObterAsync(paramento);

            return _mapper.Map<ParametroSistemaDTORetorno>(resultado);
        }
    }
}
