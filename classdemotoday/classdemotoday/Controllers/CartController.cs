using classdemotoday.Areas.Common.Models;
using classdemotoday.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace classdemotoday.Controllers
{
    public class CartController : BaseController
    {
        Emartweb db = new Emartweb();
        // GET: Cart
        public ActionResult Index()
        {
           List<CartItemViewModel> cvm = new List<CartItemViewModel>();


           if (Session["cart"] != null)
           {

               cvm = ((List<CartItemViewModel>)Session["cart"]);
           }


            return View(cvm);
        }

       [HttpPost]
        public ActionResult AddtoCart(int Itemid)
        {
            ItemDetail itemadd = db.ItemDetails.Where(i => i.Id == Itemid).FirstOrDefault();

            CartItemViewModel cart = new CartItemViewModel();


            if (Session["cart"] == null)
            {
                Session["cart"] = new List<CartItemViewModel>();

            }


         

            if (((List<CartItemViewModel>)Session["cart"]).Find(i =>i.item.Id ==Itemid)!=null)
            {
                int existingquanitiy;
              
                existingquanitiy= ((List<CartItemViewModel>)Session["cart"]).Find(i => i.item.Id == Itemid).quantity + 1;

                Update(Itemid, existingquanitiy);
               
            }
            else
            {

                cart.item = itemadd;
                cart.quantity = 1;
                cart.subTotal = itemadd.UnitPrice ?? 0 * 1;
                ((List<CartItemViewModel>)Session["cart"]).Add(cart);

            }



           Session["Count"] = ((List<CartItemViewModel>)Session["cart"]).Count();
           Session["Total"] = ((List<CartItemViewModel>)Session["cart"]).Sum(i => i.subTotal);



            return RedirectToAction("Index");

        }
      

        [HttpPost]
       public ActionResult Update(int itemid, int qty)
       {
        


          ((List<CartItemViewModel>)Session["cart"]).FirstOrDefault(i => i.item.Id == itemid).quantity=qty;
          ((List<CartItemViewModel>)Session["cart"]).FirstOrDefault(i => i.item.Id == itemid).subTotal = (((List<CartItemViewModel>)Session["cart"]).FirstOrDefault(i => i.item.Id == itemid).item.UnitPrice ?? 0) * qty;

          Session["Total"] = ((List<CartItemViewModel>)Session["cart"]).Sum(i => i.subTotal);


          return RedirectToAction("Index");
       }

      
    }
}