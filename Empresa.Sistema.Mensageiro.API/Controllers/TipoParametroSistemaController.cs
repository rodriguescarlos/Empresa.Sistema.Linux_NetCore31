using Empresa.Sistema.Cadastro.Application.DTOs;
using Empresa.Sistema.Cadastro.Application.Interface;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Empresa.Sistema.Cadastro.API.Controllers
{
    //Ex.: http://localhost:5000/api/TipoParametroSistema
    [Route("api/TipoParametroSistema/")]
    [ApiController]
    public class TipoParametroSistemaController : ControllerBase
    {
        private ITipoParametroSistemaApplication parametroApp;
        private ILogFacede log;

        public TipoParametroSistemaController(ITipoParametroSistemaApplication parametro, ILogFacede log)
        {
            parametroApp = parametro;
            this.log = log;
        }

        #region Async

        [HttpGet()]
        [Route("ObterTodosTipoParametroAsync")]
        public async Task<ActionResult<IEnumerable<TipoParametroSistemaDTO>>> ObterTodosAsync()
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

        [HttpGet()]
        [Route("ObterTipoParametroPorIdAsync/{id}")]
        public async Task<ActionResult<TipoParametroSistemaDTO>> ObterPorIdAsync(int id)
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

        [HttpPost()]
        [Route("AdicionarTipoParametroAsync/")]
        public async Task<ActionResult<TipoParametroSistemaDTORetorno>> AdicionarAsync([FromBody] TipoParametroSistemaCreateDTO tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await parametroApp.AdicionarAsync(tipoParametro));
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
        [Route("AtualizarTipoParametroAcync/")]
        public async Task<ActionResult<TipoParametroSistemaDTORetorno>> AtualizarAcync([FromBody] TipoParametroSistemaUpdateDTO tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(await parametroApp.AtualizarAsync(tipoParametro));
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

        [HttpDelete()]
        [Route("RemoverTipoParametroAsync/{id}")]
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

        #endregion

        #region Sincrono

        [HttpGet()]
        [Route("ObterTodosTipoParametro/")]
        public ActionResult<IEnumerable<TipoParametroSistemaDTO>> ObterTodos()
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
        [Route("ObterTipoParametroPorId/{id}")]
        public ActionResult<TipoParametroSistemaDTO> ObterPorId(int id)
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

        [HttpPost()]
        [Route("AdicionarTipoParametro/")]
        public ActionResult<TipoParametroSistemaDTORetorno> Adicionar([FromBody] TipoParametroSistemaCreateDTO tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(parametroApp.Adicionar(tipoParametro));
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
        [Route("AtualizarTipoParametro/")]
        public ActionResult<TipoParametroSistemaDTORetorno> Atualizar([FromBody] TipoParametroSistemaUpdateDTO tipoParametro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                return Ok(parametroApp.Atualizar(tipoParametro));
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

        [HttpDelete()]
        [Route("RemoverTipoParametro/{id}")]
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

        #endregion
    }
}
