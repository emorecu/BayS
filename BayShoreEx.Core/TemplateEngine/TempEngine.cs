using Microsoft.AspNetCore.Hosting;
using RazorLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BayShoreEx.Core.TemplateEngine
{
    public class TempEngine : ITempEngine
    {
        private readonly RazorLightEngine _engine;
        private readonly IHostingEnvironment _hostingEnvironment;

        public TempEngine(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            var path = Path.Combine(_hostingEnvironment.ContentRootPath, "Temps");
            _engine = new RazorLightEngineBuilder()
                      .UseMemoryCachingProvider()
                      .UseFilesystemProject(path)
                      .Build();
        }

        public async Task<string> ParseFile(string key, string template, Dictionary<string, string> model)
        {
            try
            {
                return await _engine.CompileRenderAsync($"{key}", $"/{template}", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> ParseContent(string key, string template, Dictionary<string, string> model)
        {
            try
            {
                return await _engine.CompileRenderAsync(key,template, model);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
