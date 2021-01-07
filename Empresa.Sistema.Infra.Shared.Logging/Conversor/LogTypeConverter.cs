using Infra.Logging.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Logging.Conversor
{
    internal class LogTypeConverter
    {
        public static LogLevel Converter(LogType logType)
        {
            switch (logType)
            {
                case LogType.Critical:
                    return LogLevel.Critical;
                case LogType.Debug:
                    return LogLevel.Debug;
                case LogType.Error:
                    return LogLevel.Error;
                case LogType.Trace:
                    return LogLevel.Trace;
                case LogType.Warning:
                    return LogLevel.Warning;
                default:
                    throw new ArgumentOutOfRangeException(nameof(LogType));
            }
        }
    }
}
