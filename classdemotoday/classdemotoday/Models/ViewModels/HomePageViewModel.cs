using classdemotoday.Areas.Common.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace classdemotoday.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<Category> SidenavbarCategory { get; set; }
        public IPagedList Items { get; set; }
    }
}