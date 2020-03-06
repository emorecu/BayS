using BayShoreEx.Core.TemplateEngine;
using BayShoreEx.Models;
using BayShoreEx.Services.File;
using BayShoreEx.Services.Temp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Components
{
    public class TempsViewComponent : ViewComponent
    {
        private readonly IFileService _fileService;
        private IHostingEnvironment _hostingEnvironment;
        public TempsViewComponent(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            this._fileService = new FileService();
        }
        public IViewComponentResult Invoke(CreateTempViewModel model)
        {
            if (model != null)
                model.TemplateText = _fileService.GetTemplate(model.TemplateName);
            else
                model = new CreateTempViewModel();

            return View(model);
        }
    }
}
