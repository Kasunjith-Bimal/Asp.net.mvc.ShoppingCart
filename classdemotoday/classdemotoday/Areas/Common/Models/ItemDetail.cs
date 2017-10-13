namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemDetail
    {
        public ItemDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        [Required]
        public string ItemCode { get; set; }

        [StringLength(500)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int? UnitPrice { get; set; }
        [Required]
        public string ImageURL { get; set; }

        public int? OrderId { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? ModifiedDatetime { get; set; }

        public int? CreatedUserId { get; set; }

        public int? ModifiedUserId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
