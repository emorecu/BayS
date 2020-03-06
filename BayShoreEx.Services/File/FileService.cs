using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.IO.File;

namespace BayShoreEx.Services.File
{
    public class FileService : IFileService
    {
        public string ReadAllText(string fileName) => System.IO.File.ReadAllText(fileName);

        public bool FileExists(string fileName) => Exists(fileName);

        public string GetCurrentDirectory() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public string CreateFile(string fileName, string content)
        {
            string path = $"Temps/{fileName}.cshtml";
            try
            {
                if (!FileExists(path))
                {

                    using (StreamWriter sw = CreateText(path))
                    {
                        sw.Write(content);
                    }
                }
                using (StreamReader sr = OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch(Exception e)
            {
                return $"Error creating template {fileName}, error message: {e.Message}";
            }

            return "Success creating templated!!!";
        }

        public List<string> GetAllTemplates()
        {
            string path = $"Temps";
            var fileEntries = Directory.GetFiles(path).Select(f => Path.GetFileName(f)); ;

            return fileEntries.ToList();
        }

        public string GetTemplate(string name)
        {
            string path = $"Temps/{name}";
            return ReadAllText(path);
        }
    }
}
