using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Logging.Domain
{
    public enum LogType
    {
        /// <summary>
        /// Erro
        /// </summary>
        Error = 1,

        /// <summary>
        /// Trace
        /// </summary>
        Trace = 2,

        /// <summary>
        /// Atenção
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Modo Debug
        /// </summary>
        Debug = 4,

        /// <summary>
        /// Critico
        /// </summary>
        Critical = 5
    }
}
