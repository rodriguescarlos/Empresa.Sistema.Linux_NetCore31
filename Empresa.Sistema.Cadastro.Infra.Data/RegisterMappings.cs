using Empresa.Sistema.Cadastro.Infra.Data.Mapeamento;

namespace Empresa.Sistema.Cadastro.Infra.Data
{
    public static class RegisterMappings
    {
        public static void Register()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[]
            {
                typeof (ParametroSistemaMap).Assembly,
                typeof (TipoParametroSistemaMap).Assembly
            });

            DapperExtensions.DapperAsyncExtensions.SetMappingAssemblies(new[]
            {
                typeof(ParametroSistemaMap).Assembly,
                typeof(TipoParametroSistemaMap).Assembly
            });
        }
    }
}
