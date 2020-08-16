using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Text01_Web01
    {

        [Display(Name = "名字")]
        public int strName { get; set; }

        [Display(Name = "生日(年)")]
        public string strYear { get; set; }

        [Display(Name = "生日(月)")]
        public string strMonth { get; set; }

        [Display(Name = "生日(日)")]
        public string strDay { get; set; }


    }
}
