using BayShoreEx.Core.TemplateEngine;
using BayShoreEx.Models;
using BayShoreEx.Services.File;
using BayShoreEx.Services.Temp;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Components
{
    public class ListViewComponent: ViewComponent
    {
        private readonly IFileService _fileService;

        public ListViewComponent()
        {
            this._fileService = new FileService();
        }

        public IViewComponentResult Invoke()
        {
            var model = new ListViewModel();
            model.Temp = _fileService.GetAllTemplates();

            return View(model);
        }
    }
}
