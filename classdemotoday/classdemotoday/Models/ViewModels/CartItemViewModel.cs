using classdemotoday.Areas.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace classdemotoday.Models.ViewModels
{
    public class CartItemViewModel
    {
        public ItemDetail item { get; set; }
    [DataType(DataType.Text)]
        public int quantity { get; set; }
        public decimal subTotal { get; set; }
    }
}