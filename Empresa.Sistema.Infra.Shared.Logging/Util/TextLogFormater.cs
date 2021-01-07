using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Logging.Util
{
    public sealed class TextLogFormater
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string GetTextException(Exception exception, string nomeModulo, string nomeClasse, string nomeMetodo, string additionalInfo)
        {
            string strEx = GetTextException(exception, nomeClasse, nomeModulo, nomeMetodo);
            return string.Format("{0};AdditionalInfo[{1}];", strEx, additionalInfo);
        }

        public static string GetTextException(Exception ex, string nomeClasse, string nomeModulo, string nomeMetodo)
        {
            string strEx = GetTextException(ex);
            return string.Format("{0};{1};{2};{3}", nomeClasse, nomeModulo, nomeMetodo, strEx);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="texto"></param>
        /// <returns></returns>
        private static string GetTextException(Exception ex)
        {
            string texto = string.Empty;
            if (ex != null)
            {
                if (ex is AggregateException)
                {
                    texto = GetTextAggregateException(ex);
                }
                else
                {
                    texto = GetText(ex);
                }
            }
            else
            {
                return GetTextException(new ArgumentNullException("ex", "Parâmetro ex não informado"));
            }

            return texto;
        }

        private static string GetTextAggregateException(Exception ex)
        {
            StringBuilder str = new StringBuilder();
            if (ex is AggregateException)
            {
                AggregateException ae = ex as AggregateException;
                ae.Handle((x) =>
                {
                    if (x is AggregateException)
                    {
                        str.Append(GetTextAggregateException(x));
                    }
                    else
                    {
                        str.Append(GetText(x));
                    }
                    return true;
                });
            }
            return str.ToString();
        }

        private static string GetText(Exception ex)
        {
            StringBuilder str = new StringBuilder();

            str.AppendFormat("[#### Exception|Type[{0}]|Source[{1}]|TargetSite[{2}]|Message[{3}]|HResult[{4}]|StackTrace[{5}]"
                , (ex.GetType() == null ? "NULL" : ex.GetType().ToString())
                , ex.Source
                , (ex.TargetSite == null ? "NULL" : ex.TargetSite.ToString())
                , ex.Message
                , ex.HResult
                , ex.StackTrace);

            if (ex.InnerException != null)
            {
                str.AppendFormat(";InnerException[{0}]", GetTextException(ex.InnerException));
            }

            str.Append("###]");

            return str.ToString();
        }

        public static string GetTextMessage(string nomeModulo, string nomeClasse, string nomeMetodo, string mensagem)
        {
            return string.Format("{0};{1};{2};{3}", nomeModulo, nomeClasse, nomeMetodo, mensagem);
        }
    }
}
