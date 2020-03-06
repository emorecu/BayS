using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Models
{
    public class ListViewModel
    {
        [Display(Name = "Templates")]
        public List<string> Temp { get; set; }
    }
}
