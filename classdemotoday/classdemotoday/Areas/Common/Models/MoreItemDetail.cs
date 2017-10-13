namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MoreItemDetail
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string ImgUrl { get; set; }

        [StringLength(100)]
        public string ImgPart { get; set; }
    }
}
