using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BayShoreEx.Models;
using BayShoreEx.Services.Temp;
using BayShoreEx.Services.File;
using BayShoreEx.Core.TemplateEngine;
using Microsoft.AspNetCore.Hosting;
using System.Dynamic;

namespace BayShoreEx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITempService _tempService;
        private readonly IFileService _fileService;
        private IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
            this._tempService = new TempService(new FileService(), new TempEngine(_hostingEnvironment));
            this._fileService = new FileService();
        }
        public IActionResult Index(TabsViewModel vm)
        {
            if (vm == null)
            {
                vm = new TabsViewModel
                {
                    ActiveTab = Tab.List
                };
            }
            return View(vm);
        }

        public IActionResult SwitchToTabs(string tabname)
        {
            var vm = new TabsViewModel();
            switch (tabname)
            {
                case "List":
                    vm.ActiveTab = Tab.List;
                    break;
                case "Temps":
                    vm.ActiveTab = Tab.Temps;
                    break;
                case "Test":
                    vm.ActiveTab = Tab.Test;
                    break;
                default:
                    vm.ActiveTab = Tab.List;
                    break;
            }
            return RedirectToAction("Index", vm);
        }


        [HttpPost]
        public IActionResult CreateTemplate(CreateTempViewModel model)
        {
            var tabModel = new TabsViewModel();
            var coModel = new TestViewModel();
            if (ModelState.IsValid)
            {
                _fileService.CreateFile(model.TemplateName, model.TemplateText);
                coModel.Template = model.TemplateName;
                tabModel.ActiveTab = Tab.Test;
                tabModel.TestModel = coModel;
            }
            else
            {
                tabModel.CreateTempModel = model;
                tabModel.ActiveTab = Tab.Temps;
                
            }

            return RedirectToAction("Index", tabModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Utils

        [HttpPost]
        public virtual IActionResult GetTemplate(string template)
        {
            if ( string.IsNullOrEmpty(template))
            {
                return Json(new { Success = false, Result = "Template name cannot be empty" });
            }
            try
            {
                var temp = _fileService.GetTemplate(template);

                return Json(new { Success = true, Result = temp });
            }
            catch (Exception ex)
            {
                return Json(new { Success = "Failed", Result = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public virtual IActionResult TestTemplate(string template, Dictionary<string, string> maps)
        {
            if (string.IsNullOrEmpty(template))
            {
                return Json(new { Success = false, Result = "Template name cannot be empty" });
            }

            try
            {
                var temp = _fileService.GetTemplate(template);
                if(temp==null)
                    return Json(new { Success = false, Result = "Template does not exist!!!" });

                var result = _tempService.ParseContent(template, maps);

                return Json(new { Success = true, Result = result });
            }
            catch (Exception ex)
            {
                return Json(new { Success = "Failed", Result = $"Error: {ex.Message}" });
            }
        }

        #endregion
    }
}
