using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Sistema.Infra.Shared.Helper
{
    public static class Arquivo
    {
        public static void Escrever(string path, string conteudo)
        {
            Escrever(path, conteudo, true);
        }

        public static void Escrever(string path, string conteudo, bool adicionar)
        {
            try
            {
                if (!File.Exists(path) && adicionar)
                {
                    File.Create(path);
                }
                else
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    File.Create(path);
                }

                using (StreamWriter sw = new StreamWriter(path, adicionar, Encoding.Default))
                {
                    sw.Write(conteudo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Ler(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(string.Format("Arquivo[{0}] não existe", path));

            string retorno = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.Default))
                {
                    retorno = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public static List<string> LerLinhas(string path, bool removerHeader, int qtdLinhasCabecalho)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(string.Format("Arquivo[{0}] não existe", path));

            List<string> retorno = new List<string>();
            string linha = string.Empty;

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    linha = reader.ReadLine();
                    retorno.Add(linha);
                }
            }

            if (removerHeader)
            {
                for (int contadorLinha = 0; contadorLinha < qtdLinhasCabecalho; contadorLinha++)
                {
                    retorno.RemoveAt(0);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Compacta arquivo para arquivo zip
        /// </summary>
        /// <param name="arquivoOrigem"></param>
        /// <param name="diretorioDestino"></param>
        public static void Compactar(string arquivoOrigem, string diretorioDestino)
        {
            string arquivoDestino = Path.Combine(diretorioDestino, string.Concat(Path.GetFileNameWithoutExtension(arquivoOrigem), ".zip"));
            string arquivoInterno = Path.GetFileName(arquivoOrigem);

            if (!Directory.Exists(diretorioDestino))
            {
                Directory.CreateDirectory(diretorioDestino);
            }

            using (FileStream fileStream = new FileStream(arquivoDestino, FileMode.Create, FileAccess.Write))
            {
                using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                {
                    var demoFile = archive.CreateEntry(arquivoInterno);

                    using (var entryStream = demoFile.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            streamWriter.AutoFlush = true;
                            using (StreamReader reader = new StreamReader(arquivoOrigem, Encoding.Default))
                            {
                                streamWriter.Write(reader.ReadToEnd());
                                reader.Close();
                            }
                            streamWriter.Close();
                        }
                        entryStream.Close();
                    }
                    archive.Dispose();
                }
                fileStream.Close();
            }
        }

        /// <summary>
        /// Compacta arquivo para arquivo zip utilizando MemoryStream
        /// </summary>
        /// <param name="arquivoOrigem"></param>
        /// <param name="diretorioDestino"></param>
        public static void CompactarMemoria(string arquivoOrigem, string diretorioDestino)
        {
            string arquivoDestino = Path.Combine(diretorioDestino, string.Concat(Path.GetFileNameWithoutExtension(arquivoOrigem), ".zip"));
            string arquivoInterno = Path.GetFileName(arquivoOrigem);

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    var demoFile = archive.CreateEntry(arquivoInterno);

                    using (var entryStream = demoFile.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            using (StreamReader reader = new StreamReader(arquivoOrigem, Encoding.Default))
                            {
                                streamWriter.Write(reader.ReadToEnd());

                                reader.Close();
                            }

                            streamWriter.Close();
                        }

                        entryStream.Close();
                    }
                }

                if (!Directory.Exists(diretorioDestino))
                {
                    Directory.CreateDirectory(diretorioDestino);
                }

                using (var fileStream = new FileStream(arquivoDestino, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);

                    fileStream.Close();
                }

                memoryStream.Close();
            }
        }
    }
}
