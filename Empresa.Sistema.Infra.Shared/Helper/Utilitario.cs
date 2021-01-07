using System;
using System.Reflection;

namespace Empresa.Sistema.Infra.Shared.Helper
{
    public static class Utilitario
    {
        public static string GetParameterAppSettings(string chave)
        {
            if (string.IsNullOrEmpty(chave))
            {
                throw new ArgumentNullException("parametro Chave não informada");
            }

            //if (System.Configuration.ConfigurationManager.AppSettings != null
            //        && System.Configuration.ConfigurationManager.AppSettings.Count > 0)
            //{
            //    string valor = System.Configuration.ConfigurationManager.AppSettings[chave];
            //    if (!string.IsNullOrWhiteSpace(valor))
            //    {
            //        return valor;
            //    }
            //    else
            //    {
            //        throw new ArgumentNullException(string.Format("Chave[{0}] não localizada ou vazia", chave));
            //    }
            //}
            //else
            //{
            //    throw new IndexOutOfRangeException("Nenhuma entrada para a seção AppSettings foi encontrada no arquivo de configuração.");
            //}

            return string.Empty;
        }

        public static T GetDefaultValue<T>()
        {
            T retorno = default(T);

            switch (typeof(T).FullName.ToUpper())
            {
                case "SYSTEM.INT16":
                    {
                        retorno = (T)Convert.ChangeType(Int16.MinValue, typeof(T));
                    } break;
                case "SYSTEM.INT32":
                    {
                        retorno = (T)Convert.ChangeType(Int32.MinValue, typeof(T));
                    } break;
                case "SYSTEM.INT64":
                    {
                        retorno = (T)Convert.ChangeType(Int64.MinValue, typeof(T));
                    } break;
                case "SYSTEM.DECIMAL":
                    {
                        retorno = (T)Convert.ChangeType(decimal.MinValue, typeof(T));
                    } break;
                case "SYSTEM.BYTE":
                    {
                        retorno = (T)Convert.ChangeType(byte.MinValue, typeof(T));
                    } break;
                case "SYSTEM.BOOLEAN":
                    {
                        retorno = (T)Convert.ChangeType(false, typeof(T));
                    } break;
                case "SYSTEM.DOUBLE":
                    {
                        retorno = (T)Convert.ChangeType(double.MinValue, typeof(T));
                    } break;
                case "SYSTEM.SINGLE":
                    {
                        retorno = (T)Convert.ChangeType(float.MinValue, typeof(T));
                    } break;
                case "SYSTEM.SBYTE":
                    {
                        retorno = (T)Convert.ChangeType(sbyte.MinValue, typeof(T));
                    } break;
                case "SYSTEM.DATETIME":
                    {
                        retorno = (T)Convert.ChangeType(new DateTime(1800, 1, 1), typeof(T));
                    } break;
                case "SYSTEM.TIMESPAN":
                    {
                        retorno = (T)Convert.ChangeType(TimeSpan.MinValue, typeof(T));
                    } break;
                default:
                    {
                        throw new NotImplementedException("Tratamento para este tipo não implementado.");
                    }
            }

            return retorno;
        }

        public static Type ConvertStringToType(string strType)
        {
            if (string.IsNullOrEmpty(strType))
            {
                return null;
            }

            Type res = null;

            try
            {
                int firstCommaIndex = strType.IndexOf(",");
                if (firstCommaIndex > 0)
                {
                    string typeFullName = strType.Substring(0, firstCommaIndex);
                    string assemblyFullName = strType.Substring(firstCommaIndex + 1);

                    Assembly typeAssembly = Assembly.Load(assemblyFullName);
                    if (typeAssembly != null)
                    {
                        res = typeAssembly.GetType(typeFullName);
                    }
                }
            }
            catch
            {
            }

            return res;
        }

        public static bool IsParsable(Type t)
        {
            if (t == null)
            {
                return false;
            }

            MethodInfo mi = t.GetMethod("Parse", new[] { typeof(string) });
            return mi != null;
        }

        /// <summary>
        /// Converte valor para tempo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static TimeSpan ToTime(string valor)
        {
            string[] fracoes = null;
            TimeSpan tempo = new TimeSpan(0, 0, 0);

            if (string.IsNullOrEmpty(valor)) throw new ArgumentNullException("Não foi informado um valor para o parâmetro 'valor'.");

            if(valor.Contains(":"))
            {
                fracoes = valor.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                fracoes = new string[3] { "0", "0", "0" };
                if(valor.Length >= 4)
                {
                    fracoes[0] = valor.Substring(0, 2);
                    fracoes[1] = valor.Substring(2, 2);
                    if(valor.Length > 5)
                    {
                        fracoes[2] = valor.Substring(2, 2);
                    }
                    else
                    {
                        fracoes[2] = valor.Substring(2, 1);
                    }
                }
                else
                {
                    if(valor.Length <= 2)
                    {
                        fracoes[0] = "0";
                        fracoes[1] = valor;
                        fracoes[2] = "0";
                    }
                    else
                    {
                        fracoes[0] = valor.Substring(0, 1);
                        fracoes[1] = valor.Substring(1, 2);
                        fracoes[2] = "0";
                    }
                }
            }

            Int16 hora, minuto, segundo;
            if(Int16.TryParse(fracoes[0], out hora) && Int16.TryParse(fracoes[1], out minuto) && Int16.TryParse(fracoes[2], out segundo))
            {
                tempo = new TimeSpan(hora, minuto, segundo);
            }

            return tempo;
        }
    }
}
