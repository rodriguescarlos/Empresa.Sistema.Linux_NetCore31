using Empresa.Sistema.Infra.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Empresa.Sistema.Cadastro.Domain.Entidade
{
    public class TipoParametroSistema : EntityBase
    {
        public long Identificador { get; set; }

        public string Nome { get; set; }

        public DateTime DataHoraCriacao {get;set;}
    }
}
