using Infra.Logging.Conversor;
using Infra.Logging.Domain;
using Infra.Logging.ExtensionLogger;
using Infra.Logging.Interface;
using Infra.Logging.Util;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Empresa.Sistema.Infra.Shared.Logging
{
    public class LogFacede : ILogFacede
    {
        #region Atributo estático Singleton

        private static ILoggerProvider logProvider;

        #endregion

        #region Constantes
        private const string chaveHabilitarLog = "habilitarLog";
        #endregion

        #region Atributos

        private bool logEnabled = true;
        private bool loaded = false;
        private ILogger writer;

        #endregion

        #region Propriedade

        internal bool LogEnabled
        {
            get
            {
                if (!loaded)
                {
                    logEnabled = true;//string.IsNullOrEmpty(Shared.Helper.Utilitario.GetParameterAppSettings(chaveHabilitarLog));
                }
                return logEnabled;
            }
        }

        #endregion

        public LogFacede()
        {
            if (logProvider == null)
            {
                logProvider = new Log4NetProvider("log4net.config");
            }

            this.writer = logProvider.CreateLogger("NomeLogger"); //Rever para passar um nome
        }

        /// <summary>
        /// Não utilizar - Criado para fins de testes unitários
        /// </summary>
        /// <param name="log"></param>
        /// <param name="provider"></param>
        public LogFacede(ILogger logger)
        {
            this.writer = logger;
        }

        public void Write(string mensagem)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(
                    LogLevel.Trace
                    , TextLogFormater.GetTextMessage(nomeModulo, nomeClasse, nomeMetodo, mensagem)
                );
            }
            catch (Exception) { }
        }

        public void Write(string mensagem, params object[] args)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                string mensagemFormatada = string.Format(mensagem, args);

                Write(TextLogFormater.GetTextMessage(nomeModulo, nomeClasse, nomeMetodo, mensagemFormatada));
            }
            catch (Exception) { }
        }

        public void Write(LogType tipo, string mensagem)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(
                    LogTypeConverter.Converter(tipo)
                    , TextLogFormater.GetTextMessage(nomeModulo, nomeClasse, nomeMetodo, mensagem));
            }
            catch (Exception) { }
        }

        public void Write(Exception ex)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(LogLevel.Error, TextLogFormater.GetTextException(ex, nomeClasse, nomeModulo,  nomeMetodo));
            }
            catch (Exception) { }
        }

        public void Write(Exception ex, string infoAdicional)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(LogLevel.Error, TextLogFormater.GetTextException(ex, nomeModulo, nomeClasse, nomeMetodo, infoAdicional));
            }
            catch (Exception) { }
        }

        public void Write(Exception ex, string infoAdicional, params object[] args)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(LogLevel.Error, TextLogFormater.GetTextException(ex, nomeModulo, nomeClasse, nomeMetodo, string.Format(infoAdicional, args)));
            }
            catch (Exception) { }
        }

        public void Write(LogType tipo, Exception ex)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(LogTypeConverter.Converter(tipo), TextLogFormater.GetTextException(ex, nomeClasse, nomeModulo, nomeMetodo));
            }
            catch (Exception) { }
        }

        public void Write(LogType tipo, Exception ex, string infoAdicional)
        {
            MethodBase metodo = new StackTrace().GetFrame(1).GetMethod();

            string nomeMetodo = metodo.Name;
            string nomeModulo = metodo.Module.Name;
            string nomeClasse = metodo.DeclaringType.Name;

            try
            {
                writer.Log(LogTypeConverter.Converter(tipo), TextLogFormater.GetTextException(ex, nomeModulo, nomeClasse, nomeMetodo, infoAdicional));
            }
            catch (Exception) { }
        }

        public void WriteEnabledOnly(string mensagem)
        {
            if (LogEnabled)
            {
                Write(mensagem);
            }
        }

        public void WriteEnabledOnly(LogType tipo, string mensagem)
        {
            if (LogEnabled)
            {
                Write(tipo, mensagem);
            }
        }

        public void WriteEnabledOnly(string mensagem, params object[] args)
        {
            if (LogEnabled)
            {
                Write(mensagem, args);
            }
        }

        public void Dispose()
        {
            logProvider.Dispose();
        }
    }
}
