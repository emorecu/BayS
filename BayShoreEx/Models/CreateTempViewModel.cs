using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BayShoreEx.Models
{
    public class CreateTempViewModel
    {
        [Required]
        [Display(Name = "Template Name:")]
        public string TemplateName { get; set; }
        [Required]
        [MaxLength(5000)]
        [Display(Name = "Template Content:")]
        public string TemplateText { get; set; }
    }
}
