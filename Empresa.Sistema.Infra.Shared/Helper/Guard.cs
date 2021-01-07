using System;

namespace Empresa.Sistema.Infra.Shared.Helper
{
    public sealed class Guard
    {
        public static void ArgumentNotIsNull(object parametro)
        {
            if (parametro == null)
            {
                throw new ArgumentNullException(string.Format("Parametro não informado."));
            }
        }
    }
}
