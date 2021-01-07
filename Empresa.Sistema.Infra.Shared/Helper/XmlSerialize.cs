using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Empresa.Sistema.Infra.Shared.Helper
{
    public static class XmlSerialize
    {
        /// <summary>
        /// Serializar um objeto
        /// </summary>
        /// <param name="objectToSerialize"></param>
        /// <returns>Objeto XML no formato de string</returns>
        public static string SerializeInMemory<TIn>(TIn objectToSerialize)
        {
            MemoryStream memStr = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(typeof(TIn));

            try
            {
                xml.Serialize(memStr, objectToSerialize);
                memStr.Position = 0;

                return System.Text.Encoding.UTF8.GetString(memStr.ToArray());
            }
            finally
            {
                memStr.Close();
            }
        }

        /// <summary>
        /// Serializar objeto em linha
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static string SerializeInLine<T>(T objeto)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = false;
            settings.Encoding = Encoding.UTF8;
            settings.NewLineHandling = NewLineHandling.None;
            settings.NewLineOnAttributes = false;

            string retorno = string.Empty;
            using (StringWriter sWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sWriter, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, objeto);
                    retorno = sWriter.ToString();
                }
            }
            return retorno;
        }

        /// <summary>
        /// Deserializar objeto
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Objeto Desejado</returns>
        public static TOut DeserializeInMemory<TOut>(string str)
        {
            byte[] b = System.Text.Encoding.UTF8.GetBytes(str);
            MemoryStream ms = new MemoryStream(b);
            XmlSerializer xml = new XmlSerializer(typeof(TOut));

            try
            {
                return (TOut)xml.Deserialize(ms);
            }
            finally
            {
                ms.Close();
            }
        }

        /// <summary>
        /// Serializar Objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static string Serialize<T>(T objeto)
        {
            string retorno = string.Empty;
            using (StringWriter writer = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);
                retorno = writer.ToString();
            }
            return retorno;
        }

        /// <summary>
        /// Deserializar Objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conteudo"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string conteudo) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;

            using (TextReader reader = new StringReader(conteudo))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
