using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Models
{
    public class TestViewModel
    {
        public TestViewModel()
        {
            Maps = new Dictionary<string, string>();
        }


        public List<SelectListItem> Templates { get; set; }
        public string Template { get; set; }

        public string TemplateText { get; set; }
        public Dictionary<string,string> Maps { get; set; }

        
    }
}
