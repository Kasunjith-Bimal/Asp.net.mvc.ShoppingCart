using classdemotoday.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classdemotoday.Models.ViewModels
{
    public class AdminViewModel
    {
       public List<Category> Categories { get; set; }

       public List<Login> Login { get; set; }
    }
}