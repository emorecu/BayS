using BayShoreEx.Models;
using BayShoreEx.Services.File;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Components
{
    public class TestViewComponent : ViewComponent
    {
        private readonly IFileService _fileService;
        public TestViewComponent()
        {
            this._fileService = new FileService();
        }
        public IViewComponentResult Invoke(TestViewModel model)
        {
            var list = _fileService.GetAllTemplates();
            if (model == null)
            {
                model = new TestViewModel();
            }            
            model.Templates = list.Select(s => new SelectListItem { Text = s, Value = s }).ToList();
            
            return View(model);
        }
    }
}
