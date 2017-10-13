namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        [Key]
 
        public int ShopId { get; set; }

        [StringLength(50)]
        [Display(Name="Shop Name")]
        [Required]
        public string ShopName { get; set; }

        [StringLength(100)]
        [Display(Name="Shop Address")]
        [Required]
        public string ShopAddress { get; set; }

        [StringLength(100)]
        [Display(Name = "Shop Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ShopEmaill { get; set; }

        [StringLength(50)]
        [MaxLength(10,ErrorMessage ="Phone Number Not Valide")]
        [Display(Name = "Shop Telephone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ShopTelephoneNumber { get; set; }

        [StringLength(100)]
        [Display(Name = "Shop User Name")]
        [Required]
        public string ShopUserName { get; set; }

        [StringLength(100)]
        [Display(Name = "Shop Password")]
        //[DataType(DataType.Password)]
        [Required]
        [DataType(DataType.Password)]
       
        public string ShopPassword { get; set; }

        //[NotMapped]
        //[Required]
        //[Compare("ShopPassword", ErrorMessage = "The password and confirmation password do not match.")]
       
        //[DataType(DataType.Password)]
       
        //public string ShopConfirmPassword { get; set; }

        [Display(Name = "Active")]
        public bool? Active { get; set; }

        [StringLength(30)]
        [Display(Name = "Login Type")]
        public string LoginType { get; set; }
    }
}
