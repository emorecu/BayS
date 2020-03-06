using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Models
{
    public class TabsViewModel
    {
        public Tab ActiveTab { get; set; }
        public TestViewModel TestModel {get;set;}
        public CreateTempViewModel CreateTempModel { get; set; }
        public ListViewModel ListViewModel { get; set; }
    }

    public enum Tab
    {
        List,
        Temps,
        Test
    }
}
