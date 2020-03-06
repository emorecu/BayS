using BayShoreEx.Core.TemplateEngine;
using BayShoreEx.Services.File;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace BayShoreEx.Services.Temp
{
    public class TempService : ITempService
    {
        private const string TemplatesDirectoryName = "Temps/{0}";


        private readonly IFileService _fileSystemService;
        private readonly ITempEngine _tempEngine;

        public TempService(IFileService fileService, ITempEngine tempEngine)
        {
            _fileSystemService = fileService;
            _tempEngine = tempEngine;
        }

        public async Task<string> ParseContent(string tempName, Dictionary<string, string> model)
        {
            var templateContent = GetContent(tempName);

            return await _tempEngine.ParseContent(tempName.Replace(".cshtml", ""), templateContent, model);
        }

        public async Task<string> ParseFile(string tempName, Dictionary<string, string> model)
        {
            return await _tempEngine.ParseFile(tempName.Replace(".cshtml",""), tempName, model);
        }

        private string GetContent(string templateName)
        {
            if (string.IsNullOrEmpty(templateName))
            {
                throw new FileNotFoundException(string.Format("Template file not found for template '{0}' in '{1}'", templateName, TemplatesDirectoryName));
            }

            return _fileSystemService.ReadAllText(string.Format(TemplatesDirectoryName,templateName));
        }
    }
}
