using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace classdemotoday.Models.ViewModels
{
    public class CategoryLoginViewModel
    {
       
        public int Shopid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public bool IsActive { get; set; }


       
        public string ShopAddress { get; set; }

       
        public string ShopEmaill { get; set; }

       
        public string ShopTelephoneNumber { get; set; }

       
        public string ShopUserName { get; set; }

      
        public string ShopPassword { get; set; }
    }
}