using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class IndexModel
    {
        [Display(Name = "Some Date", Description = "This is a description, it'll show up in the info tooltip")]
        public DateTime SomeDate { get; set; }
    }
}