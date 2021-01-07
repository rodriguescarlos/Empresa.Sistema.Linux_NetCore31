using DapperExtensions.Mapper;
using Empresa.Sistema.Cadastro.Domain.Entidade;

namespace Empresa.Sistema.Cadastro.Infra.Data.Mapeamento
{
    public class TipoParametroSistemaMap : ClassMapper<TipoParametroSistema>
    {
        public TipoParametroSistemaMap()
        {
            Table("TipoParametro");
            this.AddIdentityColumn();
            this.AddColumnMap();
        }

        public virtual void AddIdentityColumn()
        {
            Map(u => u.Identificador).Column("idTipoParametro").Key(KeyType.Identity);
        }

        public virtual void AddColumnMap()
        {
            Map(u => u.Nome).Column("NomeTipoParametro");
            Map(u => u.DataHoraCriacao).Column("DataHoraInclusao");
        }
    }
}
