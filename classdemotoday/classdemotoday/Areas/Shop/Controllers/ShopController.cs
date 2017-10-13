using classdemotoday.Areas.Common.Models;
using classdemotoday.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace classdemotoday.Areas.Shop.Controllers
{
    public class ShopController : Controller
    {
        Emartweb db = new Emartweb();
        // GET: Shop/Shop
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            ShopViewModel shopviewmodel = new ShopViewModel();

            shopviewmodel.CategoryData = db.Categories.Where(x => x.Shopid == id).FirstOrDefault();
            shopviewmodel.logindata = db.Logins.Where(y => y.ShopId == id).FirstOrDefault();
            return View(shopviewmodel);
        }

        [HttpGet]
        public ActionResult EditShopDetails(int id)
        {
            ShopViewModel shopviewmodels = new ShopViewModel();

            shopviewmodels.CategoryData = db.Categories.Where(x => x.Shopid == id).FirstOrDefault();
            shopviewmodels.logindata = db.Logins.Where(y => y.ShopId == id).FirstOrDefault();
            return View(shopviewmodels);
           
        }

        [HttpPost]
        public ActionResult EditShopDetails(HttpPostedFileBase file,Category cat, Login login)
        {
           
                Category category = db.Categories.Where(x => x.Shopid==cat.Shopid).FirstOrDefault();
                Login log = db.Logins.Where(x => x.ShopId==cat.Shopid).FirstOrDefault();

                category.Name = cat.Name;
                category.Description = cat.Description;
                category.IsActive = cat.IsActive;
                category.ImageURL = category.ImageURL;
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/360/Images/Shop/") + file.FileName);

                    category.ImageURL = file.FileName;

                }
                log.ShopEmaill = login.ShopEmaill;
                log.ShopName = cat.Name;
                log.ShopAddress = login.ShopAddress;
                log.ShopTelephoneNumber = login.ShopTelephoneNumber;
              
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                db.Entry(log).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                if (cat.IsActive == false)
                {
                    log.Active = false;
                    db.Entry(log).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    cat.IsActive = false;
                    db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


                return RedirectToAction("Index", new { id=cat.Shopid});
            
          
        }

        public ActionResult ShopProfile()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetItemList(int id, string search)
        {
            ViewBag.shopid = id;
             List<ItemDetail> itemlist =new List<ItemDetail>();
            int categoryid = db.Categories.Where(x => x.Shopid == id).FirstOrDefault().Id;
            if (search == "" || search == null)
            {

                itemlist = db.ItemDetails.Where(x => x.CategoryId == categoryid).ToList();
            }
            else
            {
                itemlist = db.ItemDetails.Where(x => x.CategoryId == categoryid && x.Name == search).ToList();
               
            }
         
            return View(itemlist);
        }

        [HttpGet]
        public ActionResult Create(int ids) {

            ItemDetail item = new ItemDetail();

             int categoryid = db.Categories.Where(x => x.Shopid == ids).FirstOrDefault().Id;
             //item.CategoryId = categoryid;
           
             ViewBag.catIdData = categoryid;
            return View();
        
        }


        [HttpPost]
        public ActionResult Create(ItemDetail Itemlist, HttpPostedFileBase ImageURL)
        {
            if (ModelState.IsValid)
            {
                if (Itemlist.IsActive == null )
                {
                    Itemlist.IsActive = false;
                }
                if (ImageURL != null)
                {
                    var path = Server.MapPath("~/360/Images/"+Itemlist.ItemCode);
                    var directory = new DirectoryInfo(path);

                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }

                    ImageURL.SaveAs(HttpContext.Server.MapPath("~/360/Images/" + Itemlist.ItemCode+"/") + ImageURL.FileName);

                    Itemlist.ImageURL = Itemlist.ItemCode+"/"+ImageURL.FileName;

                }
                db.ItemDetails.Add(Itemlist);
                db.SaveChanges();
               ItemDetail itemdaat= db.ItemDetails.ToList().Last();
               return RedirectToAction("LordMorePhoto", new { Id = itemdaat.Id});
            }


            return View();

        }

        [HttpGet]
        public ActionResult LordMorePhoto(int id)
        {
            MoreItemDetail moreitemdetails = new MoreItemDetail();
           //ItemDetail item = db.ItemDetails.Where(x => x.ItemCode == ItemCode).FirstOrDefault();
            moreitemdetails.ItemId = id;

            return View(moreitemdetails);
        }

        [HttpPost]
        public ActionResult LordMorePhoto(MoreItemDetail moredetails, HttpPostedFileBase ImgUrl)
        {
            if (ModelState.IsValid)
            {

                if (ImgUrl != null)
                {

                    ItemDetail Item = db.ItemDetails.Where(x=>x.Id==moredetails.ItemId).FirstOrDefault();
                    var path = Server.MapPath("~/360/Images/" + Item.ItemCode+"/sub/");
                    var directory = new DirectoryInfo(path);

                    if (directory.Exists == false){
                   
                        directory.Create();
                    }

                    ImgUrl.SaveAs(HttpContext.Server.MapPath("~/360/Images/" + Item.ItemCode + "/Sub/") + ImgUrl.FileName);

                    moredetails.ImgUrl = Item.ItemCode + "/Sub/"+ ImgUrl.FileName;
                    moredetails.ImgPart = Item.ItemCode + "/Sub/";

                }


                db.MoreItemDetails.Add(moredetails);
                db.SaveChanges();

            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id,int catid)
        {
            ItemDetail itemDetail = db.ItemDetails.Where(x=>x.Id==id && x.CategoryId ==catid).FirstOrDefault();

            return View(itemDetail);
        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, ItemDetail Item)
        {
            ItemDetail itemDetail = db.ItemDetails.Where(x => x.Id == Item.Id && x.CategoryId == Item.CategoryId).FirstOrDefault();
            if (file != null)
            {
                var path = Server.MapPath("~/360/Images/" + Item.ItemCode);
                var directory = new DirectoryInfo(path);

                if (directory.Exists == false)
                {
                    directory.Create();
                }

                file.SaveAs(HttpContext.Server.MapPath("~/360/Images/" + Item.ItemCode + "/") + file.FileName);

                Item.ImageURL = Item.ItemCode + "/" + file.FileName;
                itemDetail.ImageURL = Item.ImageURL;
            }
            else
            {
                itemDetail.ImageURL = itemDetail.ImageURL;
            }

            
               
                if (Item.IsActive == null)
                {
                    Item.IsActive = false;
                }
               
                

                itemDetail.ItemCode = Item.ItemCode;
                itemDetail.Name = Item.Name;
                itemDetail.UnitPrice = Item.UnitPrice;
                itemDetail.IsActive = Item.IsActive;
                itemDetail.CategoryId = Item.CategoryId;
                itemDetail.Id = Item.Id;
                
                db.Entry(itemDetail).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

           

            return View();
        }
    }
}