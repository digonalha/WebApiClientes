using System.Collections.Generic;
using System.IO;

namespace WebApiClientes.Utilities
{
    public static class FileHelper
    {
        public static List<string> readFile(string fileName)
        {
            List<string> linhasArquivo = new List<string>();

            string content, path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            using (FileStream file = new FileStream($"{path}\\{fileName}", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while ((content = sr.ReadLine()) != null)
                    {
                        linhasArquivo.Add(content);
                    }

                    sr.Close();
                }

                file.Close();
            }

            return linhasArquivo;
        }
    }
}
