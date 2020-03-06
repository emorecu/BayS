using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace BayShoreEx.Services.Temp
{
    public interface ITempService
    {
        Task<string> ParseContent(string templateName, Dictionary<string, string> model);
        Task<string> ParseFile(string templateName, Dictionary<string,string> model);
    }

}
