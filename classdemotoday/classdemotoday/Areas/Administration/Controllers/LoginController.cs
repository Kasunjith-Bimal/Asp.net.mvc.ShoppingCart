using classdemotoday.Areas.Common.Models;
using classdemotoday.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace classdemotoday.Areas.Administration.Controllers
{
    public class LoginController : BaseController
    {
        Emartweb db = new Emartweb();
        // GET: Administration/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
           

                login.ShopPassword = GetMD5HashData(login.ShopPassword);
                if((db.Logins.Where(x=>x.ShopUserName.Equals(login.ShopUserName) && x.ShopPassword.Equals(login.ShopPassword)).Any())){

                    Login loginusre = (db.Logins.Where(x => x.ShopUserName.Equals(login.ShopUserName) && x.ShopPassword.Equals(login.ShopPassword))).FirstOrDefault();

                    if (loginusre.Active==true)
                    {
                        if (loginusre.LoginType == "Admin")
                        {

                            return RedirectToAction("Index", "Admin", new { area = "Administration" });
                        }
                        else
                        {

                            return RedirectToAction("Index", "Shop", new { area = "Shop" ,id =loginusre.ShopId});
                        }
                     
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    ViewBag.Massage = "Password Or User Name Incerect Or Not Input the Currectly";
                }


            


            return View();
        }
        [HttpGet]
        public ActionResult SigunUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SigunUp(Login login)
        {
            login.Active = false;
            if (ModelState.IsValid)
            {
                login.ShopPassword = GetMD5HashData(login.ShopPassword);

                db.Logins.Add(login);
                db.SaveChanges();
               

                return RedirectToAction("Login");


            }


            return View();
        }
        private string GetMD5HashData(string data)
        {
            if(data == null || data == "")
            {

                return "";

            }
            else
            {
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
            //create new instance of md5


        }

       
    }
}