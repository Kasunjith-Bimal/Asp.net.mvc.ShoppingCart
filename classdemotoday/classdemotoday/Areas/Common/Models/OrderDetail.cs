namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderHeaderId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public virtual ItemDetail ItemDetail { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }
    }
}
