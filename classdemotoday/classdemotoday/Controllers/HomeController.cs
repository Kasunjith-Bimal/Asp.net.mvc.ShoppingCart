

using classdemotoday.Areas.Common.Models;
using classdemotoday.Models;
using classdemotoday.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.IO;

namespace classdemotoday.Controllers
{

    public class HomeController : BaseController
    {

        Emartweb db = new Emartweb();





        public ActionResult Index(int? categoryid, String searchstring, int? searchcriteria, int? itemPage, int? cateory, int? catPage, string sortoftion = "id", string sortoder = "asc")
        {



            HomePageViewModel viewmodel = new HomePageViewModel();

            viewmodel.SidenavbarCategory = db.Categories.Where(c => c.IsActive == true).ToList();




            if (searchstring != null && searchcriteria != null && categoryid ==null)
                viewmodel.Items = (from recode in db.ItemDetails where (recode.Name.Contains(searchstring) && recode.CategoryId == searchcriteria) select recode).OrderBy(c => c.Id).ToPagedList(itemPage ?? 1, 16);
            else if (searchstring != null && searchcriteria == null && categoryid == null)
            {


                viewmodel.Items = (from recode in db.ItemDetails where recode.Name.Contains(searchstring) select recode).OrderBy(c => c.Id).ToPagedList(itemPage ?? 1, 16);



            }
            else
            {




                IPagedList iPagedList = null;


                if (categoryid.HasValue && categoryid != null)
                {
                    if (sortoftion == "name" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderBy(c => c.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "name" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderByDescending(c => c.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "category" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderBy(c => c.Category.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "name" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderByDescending(c => c.Category.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }


                    else if (sortoftion == "price" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderBy(c => c.UnitPrice).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "price" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderByDescending(c => c.UnitPrice).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else
                        viewmodel.Items = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true && i.CategoryId == categoryid).OrderBy(c => c.Id).ToPagedList(itemPage ?? 1, 16);
                }
                else
                {
                    if (sortoftion == "category" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderBy(c => c.Category.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "category" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderByDescending(c => c.Category.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }


                    else if (sortoftion == "name" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderBy(c => c.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "name" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderByDescending(c => c.Name).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }




                    else if (sortoftion == "price" && sortoder == "asc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderBy(c => c.UnitPrice).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else if (sortoftion == "price" && sortoder == "desc")
                    {
                        iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderByDescending(c => c.UnitPrice).ToPagedList(itemPage ?? 1, 16);
                        viewmodel.Items = iPagedList;
                    }
                    else
                    {
                        //iPagedList = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderByDescending(c => c.Name).ToPagedList(itemPage ?? 1, 16);
                        //viewmodel.Items = iPagedList;





                        viewmodel.Items = db.ItemDetails.Where(i => i.Category.IsActive == true && i.IsActive == true).OrderBy(c => c.Id).ToPagedList(itemPage ?? 1, 16);

                    }





                }
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult MoreDetails(int Itemid)
        {
            ItemDetail Item = db.ItemDetails.Where(c => c.Id.Equals(Itemid)).FirstOrDefault();
            String imgUrl = db.MoreItemDetails.Where(y=>y.ItemId.Equals(Itemid)).Select(x => x.ImgPart).FirstOrDefault();  
            String siteUrl =db.Settings.FirstOrDefault(s => s.Code == "004").Value;
            String imagefolder = db.Settings.FirstOrDefault(x => x.Code == "001").Value;
            ViewBag.ImageUrls = siteUrl + imagefolder +imgUrl;
            ViewBag.counts = db.MoreItemDetails.Where(y => y.ItemId.Equals(Itemid)).ToList().Count();
            return View(Item);
        }


    }
}