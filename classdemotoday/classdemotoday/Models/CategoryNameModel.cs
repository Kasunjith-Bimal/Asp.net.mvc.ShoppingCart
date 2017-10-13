using classdemotoday.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace classdemotoday.Models
{
    public class CategoryNameModel{

     Emartweb emart =new Emartweb();

     public String CatName { get; set; }

        public List<Category> categorylist { get 
        {
            var x = emart.Categories.ToList();
        
        return x;
        } 

       
        }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get
            {
                var allFlavors = categorylist.Select(f => new SelectListItem
                {
                    Value = f.Name,
                    Text = f.Name
                });
                return allFlavors;

            }
        }

       
    }
}