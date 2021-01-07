using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Empresa.Sistema.Cadastro.Application.DTOs
{
    public class TipoParametroSistemaDTORetorno
    {
        public long Identificador { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
