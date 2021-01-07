using Empresa.Sistema.Cadastro.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Infra.Logging.Interface;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Empresa.Sistema.Cadastro.Application.Interface;

namespace Empresa.Sistema.Cadastro.API.Controllers
{
    //Ex.: http://localhost:5000/api/PetStore
    [Route("api/PetStore/")]
    [ApiController]
    public class PetStore : ControllerBase
    {
        private ILogFacede log;
        private IPetStoreApplication app;

        public PetStore(IPetStoreApplication app, ILogFacede log)
        {
            this.log = log;
            this.app = app;
        }

        [HttpGet()]
        [Route("ObterPet/")]
        public ActionResult<IEnumerable<PetDTO>> ObterPet()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 - bad request - solicitação inválida
            }

            try
            {
                log.Write("ObterTodos");
                return Ok(this.app.ObterPet());
            }
            catch (ArgumentException aEx)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, aEx.Message);
            }
        }
    }
}
