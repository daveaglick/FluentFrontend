using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class IndexModel
    {
        [Display(Name = "My Foo", Description = "Querty")]
        public DateTime Foo { get; set; }
    }
}