namespace classdemotoday.Areas.Common.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Emartweb : DbContext
    {
        public Emartweb()
            : base("name=Emartweb")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ItemDetail> ItemDetails { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<MoreItemDetail> MoreItemDetails { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDetail>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.ItemDetail)
                .HasForeignKey(e => e.ItemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopName)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopEmaill)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopTelephoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopUserName)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.ShopPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Login>()
                .Property(e => e.LoginType)
                .IsUnicode(false);

            modelBuilder.Entity<MoreItemDetail>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<MoreItemDetail>()
                .Property(e => e.ImgPart)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CustomerAddress)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CustomerEmail)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CustomerTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CustomerMobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .Property(e => e.CreditCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<OrderHeader>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.OrderHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
