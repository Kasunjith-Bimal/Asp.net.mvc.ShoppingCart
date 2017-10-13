using classdemotoday.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace classdemotoday.Controllers
{
    public class BaseController : Controller
    {
        Emartweb db = new Emartweb();
        Dictionary<string, string> filtercriteria = new Dictionary<string, string>();


        public BaseController()
        {


            String siteUrl = db.Settings.FirstOrDefault(s => s.Code == "004").Value;
            String imagefolder = db.Settings.FirstOrDefault(x => x.Code == "001").Value;
            ViewBag.ImageUrl = siteUrl + imagefolder;
            
            var list = db.Categories.ToList();
            foreach (var item in list)
            {
                filtercriteria.Add(item.Id.ToString(), item.Name);

            }
            SelectList select = new SelectList(filtercriteria, "Key", "Value");
            ViewBag.data = select;
        }
      
      
    }
}