using classdemotoday.Areas.Common.Models;
using classdemotoday.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace classdemotoday.Areas.Administration.Controllers
{
    public class AdminController : Controller
    {
        Emartweb db = new Emartweb();
        // GET: Administration/Admin
        public ActionResult Index()
        {

            AdminViewModel Adminviewmodels = new AdminViewModel();

            Adminviewmodels.Categories = db.Categories.Where(x => x.IsActive).ToList();
            Adminviewmodels.Login = db.Logins.Where(x => x.Active == false).ToList();
            return View(Adminviewmodels);
        }

        public ActionResult ActiveShop()
        {
            List<Category> category = db.Categories.Where(x => x.IsActive).ToList();

            return View(category);
        }

        public ActionResult PendingActiveShop()
        {
            List<Login> logins = db.Logins.Where(x => x.Active == false).ToList();

            return View(logins);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Login login = db.Logins.Where(x => x.ShopId == id).FirstOrDefault();
            return View(login);
        }
        [HttpPost]
        public ActionResult Edit(Login login)
        {
            if (ModelState.IsValid)
            {


                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();

                if (db.Logins.Where(x => x.ShopId == login.ShopId && x.Active == true).Any())
                {
                    Category Categoryobj = new Category();

                    Categoryobj.Name = login.ShopName;
                    Categoryobj.Shopid = login.ShopId;
                    Categoryobj.IsActive = true;
                    Categoryobj.Description = "Test";
                    db.Categories.Add(Categoryobj);
                    db.SaveChanges();
                    //Category CateDb = db.Categories.Where(x => x.Shopid == login.ShopId).FirstOrDefault();
                    //CateDb.Name = login.ShopName;
                    //CateDb.Shopid = login.ShopId;
                    //CateDb.IsActive = true;
                    //db.Entry(CateDb).State = EntityState.Modified;
                    //db.SaveChanges();

                    return RedirectToAction("index", "Admin");

                }


            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateShop()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateShop(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.Active == null)
                {
                    login.Active = false;
                }

                string password = GetMD5HashData(login.ShopPassword);
                login.ShopPassword = password;
                db.Logins.Add(login);
                db.SaveChanges();

                if (db.Logins.Where(x => x.ShopId == login.ShopId && x.Active == true).Any())
                {
                    Category Categoryobj = new Category();

                    Categoryobj.Name = login.ShopName;
                    Categoryobj.Shopid = login.ShopId;
                    Categoryobj.IsActive = true;
                    db.Categories.Add(Categoryobj);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Admin");


                }
                else
                {

                    return RedirectToAction("PendingActiveShop", "Admin");
                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Login login = db.Logins.Where(x => x.ShopId == id).FirstOrDefault();

            return View(login);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteOf(int? id)

        {


            Category category = db.Categories.Where(x => x.Shopid == id).FirstOrDefault();
            ItemDetail item = db.ItemDetails.Where(x => x.CategoryId == category.Id).FirstOrDefault();
            if(item != null)
            {

                List<MoreItemDetail> moreitem = db.MoreItemDetails.ToList().Where(x => x.ItemId == item.Id).ToList();
                if (moreitem.Count() > 0)
                {
                    foreach (var MoreItemDetail in moreitem)
                    {
                        MoreItemDetail moreitemddata = db.MoreItemDetails.Where(x => x.Id == MoreItemDetail.Id).FirstOrDefault();
                        db.MoreItemDetails.Remove(moreitemddata);
                        db.SaveChanges();

                    }

                }
            }
          

           

            if (item !=null)
            {
                db.ItemDetails.Remove(item);
                db.SaveChanges();
            }

            Login logins = db.Logins.Where(x => x.ShopId == id).FirstOrDefault();
            db.Logins.Remove(logins);
            db.SaveChanges();
            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("Index", "Admin");

        }

        private string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        [HttpGet]
        public ActionResult EditShopData(int id)
        {
            ShopViewModel shopviewmodels = new ShopViewModel();

            shopviewmodels.CategoryData = db.Categories.Where(x => x.Shopid == id).FirstOrDefault();
            shopviewmodels.logindata = db.Logins.Where(y => y.ShopId == id).FirstOrDefault();
            return View(shopviewmodels);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditShopData(HttpPostedFileBase file, Category cat, Login login)
        {
            Category category = db.Categories.Where(x => x.Shopid == cat.Shopid).FirstOrDefault();
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/360/Images/Shop/") + file.FileName);

                category.ImageURL = file.FileName;

            }
            category.ImageURL = category.ImageURL;
            category.CreatedUserId = 1;
            category.OrderId = 2;



               
                Login log = db.Logins.Where(x => x.ShopId == cat.Shopid).FirstOrDefault();

                category.Name = cat.Name;
                category.Description = cat.Description;
                category.IsActive = cat.IsActive;
                
                
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


                return RedirectToAction("Index", "Admin");
           
        }




    }
}