namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string Value { get; set; }
    }
}
