using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface;
using Empresa.Sistema.Infra.Shared.Domain;
using Empresa.Sistema.Infra.Shared.Extensions;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.API.Controllers
{
    //Ex.: http://localhost:5000/api/ParametroSistema
    [Route("api/ParametroSistema/")]
    [ApiController]
    public class ParametroSistemaController : ControllerBase
    {
        private IParametroSistemaApplication parametroApp;
        private ILogFacede log;

        public ParametroSistemaController(IParametroSistemaApplication parametro, ILogFacede log)
        {
            parametroApp = parametro;
            this.log = log;
        }

        #region Async

        [HttpGet]
        [Route("ObterTodosAsync/")]
        public async Task<ActionResult<IEnumerable<ParametroSistemaDTO>>> ObterTodosAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterTodos");
                return Ok(await this.parametroApp.ObterTodosAsync());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpGet]
        [Route("ObterPorIdAsync/{id}")]
        public async Task<ActionResult<ParametroSistemaDTO>> ObterPorIdAsync(int id)
        {
            log.Write("ObterPorId({0})", id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await this.parametroApp.ObterPorIdAsync(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpPost]
        [Route("AdicionarAsync/")]
        public async Task<ActionResult> AdicionarAsync([FromBody] ParametroSistemaCreateDTO parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await parametroApp.AdicionarAsync(parametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("AtualizarAcync/")]
        public async Task<ActionResult> AtualizarAcync([FromBody] ParametroSistemaUpdateDTO parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await parametroApp.AtualizarAsync(parametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("RemoverAsync/{id}")]
        public async Task<ActionResult<bool>> RemoverAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await parametroApp.RemoverAsync(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterAsync/{nome}")]
        public async Task<ActionResult<ParametroSistemaDTO>> ObterAsync(string nome)
        {
            log.Write("ObterAsync({0})", nome);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await this.parametroApp.ObterAsync(nome));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        #endregion

        #region Sincrono

        [HttpGet()]
        [Route("obterTodos/")]
        public ActionResult<IEnumerable<ParametroSistemaDTO>> ObterTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterTodos");
                return Ok(this.parametroApp.ObterTodos());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpGet()]
        [Route("ObterPorId/{id}")]
        public ActionResult<ParametroSistemaDTO> ObterPorId(int id)
        {
            log.Write("ObterPorId({0})", id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(this.parametroApp.ObterPorId(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        [HttpPost]
        [Route("Adicionar/")]
        public ActionResult<ParametroSistemaDTORetorno> Adicionar([FromBody] ParametroSistemaCreateDTO parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                
                return Ok(parametroApp.Adicionar(parametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut()]
        [Route("Atualizar/")]
        public ActionResult<ParametroSistemaDTORetorno> Atualizar([FromBody] ParametroSistemaUpdateDTO parametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(parametroApp.Atualizar(parametro));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Remover/{id}")]
        public ActionResult<bool> Remover(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(parametroApp.Remover(id));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("Obter/{nome}")]
        public ActionResult<ParametroSistemaDTO> Obter(string nome)
        {
            log.Write("ObterAsync({0})", nome);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(this.parametroApp.Obter(nome));
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }

        #endregion
    }
}
