namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Category()
        {
            ItemDetails = new HashSet<ItemDetail>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(500)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string ImageURL { get; set; }

        public int? OrderId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? ModifiedDatetime { get; set; }

        public int? CreatedUserId { get; set; }

        public int? ModifiedUserId { get; set; }

        public int? Shopid { get; set; }

        public virtual ICollection<ItemDetail> ItemDetails { get; set; }
    }
}
