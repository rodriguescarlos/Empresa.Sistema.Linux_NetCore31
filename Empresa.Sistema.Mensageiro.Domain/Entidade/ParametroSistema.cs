using System;
using Dapper.Contrib.Extensions;
using Empresa.Sistema.Infra.Shared.Domain;

namespace Empresa.Sistema.Cadastro.Domain.Entidade
{
    /// <summary>
    /// Representa uma entidade de Parâmetro do sistema
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class ParametroSistema : EntityBase, IEquatable<ParametroSistema>
    {
        public long Identificador { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public string UsuarioCriacao { get; set; }

        public string UsuarioAlteracao { get; set; }

        public bool Equals(ParametroSistema other)
        {
            return this.Identificador.Equals(other.Identificador)
                && (!string.IsNullOrEmpty(this.Descricao)? this.Descricao.Equals(other.Descricao) : string.IsNullOrEmpty(other.Descricao))
                && (!string.IsNullOrEmpty(this.Nome) ? this.Nome.Equals(other.Nome) : string.IsNullOrEmpty(other.Nome))
                && (!string.IsNullOrEmpty(this.Conteudo) ? this.Conteudo.Equals(other.Conteudo) : string.IsNullOrEmpty(other.Conteudo))
                && this.DataCriacao.Equals(other.DataCriacao);
        }
    }
}
