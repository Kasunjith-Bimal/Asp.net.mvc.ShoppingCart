namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderHeader
    {
        public OrderHeader()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderHeaderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNo { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(500)]
        public string CustomerAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [StringLength(12)]
        public string CustomerTelephone { get; set; }

        [Required]
        [StringLength(12)]
        public string CustomerMobileNo { get; set; }

        [Required]
        [StringLength(16)]
        public string CreditCardNo { get; set; }

        public DateTime OrderDateTime { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
