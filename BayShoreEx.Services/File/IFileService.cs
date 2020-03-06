using System;
using System.Collections.Generic;
using System.Text;

namespace BayShoreEx.Services.File
{
    public interface IFileService
    {
        string ReadAllText(string fileName);
        bool FileExists(string fileName);
        string CreateFile(string fileName, string content);
        string GetCurrentDirectory();
        List<string> GetAllTemplates();
        string GetTemplate(string name);
    }
}
