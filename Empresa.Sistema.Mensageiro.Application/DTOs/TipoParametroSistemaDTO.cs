using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.DTOs
{
    public class TipoParametroSistemaDTO : TipoParametroSistemaDTORetorno
    {
        public DateTime DataHoraCriacao { get; set; }
    }
}
