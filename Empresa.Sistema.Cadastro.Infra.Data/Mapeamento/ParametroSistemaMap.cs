using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class ParametroSistemaMap : ClassMapper<ParametroSistema>
    {
        public ParametroSistemaMap()
        {
            Table("TB_ParametroSistema");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.Identificador).Column("ID_PARM").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.Conteudo).Column("CNTD_PARM");
            Map(u => u.Descricao).Column("DSC_PARM");
            Map(u => u.Nome).Column("NOM_PARM");
            Map(u => u.DataCriacao).Column("DTHR_CRIA");
            Map(u => u.DataAlteracao).Column("DTHR_ALT");
            Map(u => u.UsuarioCriacao).Column("USR_CRIA");
            Map(u => u.UsuarioAlteracao).Column("USR_ALT");
        }
    }
}
