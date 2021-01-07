using System;

namespace Empresa.Sistema.Cadastro.Application.DTOs
{
    public class ParametroSistemaDTORetorno
    {
        public long Identificador { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
