using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BayShoreEx.Core.TemplateEngine
{
    public interface ITempEngine
    {
        Task<string> ParseFile(string key, string template, Dictionary<string, string> model);
        Task<string> ParseContent(string key, string template, Dictionary<string, string> model);
    }
}
