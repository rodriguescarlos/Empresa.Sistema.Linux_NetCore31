using Infra.Logging.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Logging.Interface
{
    public interface ILogFacede
    {
        void Write(Exception ex);
        void Write(Exception ex, string infoAdicional);
        void Write(Exception ex, string infoAdicional, params object[] args);
        void Write(LogType tipo, Exception ex);
        void Write(LogType tipo, Exception ex, string infoAdicional);
        void Write(LogType tipo, string mensagem);
        void Write(string mensagem);
        void Write(string mensagem, params object[] args);
        void WriteEnabledOnly(LogType tipo, string mensagem);
        void WriteEnabledOnly(string mensagem);
        void WriteEnabledOnly(string mensagem, params object[] args);
    }
}
