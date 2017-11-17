using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace asp_project1.Models
{
    public partial class asp_proj1Context : DbContext
    {
        public asp_proj1Context(DbContextOptions<asp_proj1Context> abc):base(abc)
        {

        }



        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItem { get; set; }
        public virtual DbSet<SaleHistory> SaleHistory { get; set; }
        public virtual DbSet<SaleItem> SaleItem { get; set; }
        public virtual DbSet<ShopStaff> ShopStaff { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B3IASG2;Database=asp_proj1;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_name")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasColumnName("Category_type")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("Customer_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CustomerPhoneno)
                    .IsRequired()
                    .HasColumnName("Customer_phoneno")
                    .HasColumnType("varchar(13)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("Item_id");

                entity.Property(e => e.ItemCategory)
                    .IsRequired()
                    .HasColumnName("Item_category")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ItemColor)
                    .IsRequired()
                    .HasColumnName("Item_color")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("Item_description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ItemModel)
                    .IsRequired()
                    .HasColumnName("Item_model")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("Item_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("Item_price")
                    .HasColumnType("money");

                entity.Property(e => e.ItemQuantity).HasColumnName("Item_quantity");
            });

            modelBuilder.Entity<PurchaseHistory>(entity =>
            {
                entity.HasKey(e => e.Sr)
                    .HasName("PK_Purchase_history");

                entity.ToTable("Purchase_history");

                entity.Property(e => e.Sr).HasColumnName("SR#");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_date")
                    .HasColumnType("date");

                entity.Property(e => e.PurchaseItemName)
                    .IsRequired()
                    .HasColumnName("Purchase_item_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("Purchase_price")
                    .HasColumnType("money");

                entity.Property(e => e.PurchaseQuantity).HasColumnName("Purchase_quantity");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("Vendor_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.VendorPhoneno)
                    .IsRequired()
                    .HasColumnName("Vendor_phoneno")
                    .HasColumnType("varchar(13)");
            });

            modelBuilder.Entity<PurchaseItem>(entity =>
            {
                entity.HasKey(e => e.PurchaseId)
                    .HasName("PK_Purchase_item");

                entity.ToTable("Purchase_item");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_id");

                entity.Property(e => e.PurchaseItemName)
                    .IsRequired()
                    .HasColumnName("Purchase_item_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("Purchase_price")
                    .HasColumnType("money");

                entity.Property(e => e.PurchaseQuantity).HasColumnName("Purchase_quantity");

                entity.Property(e => e.PurchasingDate)
                    .HasColumnName("Purchasing_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<SaleHistory>(entity =>
            {
                entity.HasKey(e => e.Sr)
                    .HasName("PK_Sale_history");

                entity.ToTable("Sale_history");

                entity.Property(e => e.Sr).HasColumnName("SR#");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("Customer_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CustomerPhoneno)
                    .IsRequired()
                    .HasColumnName("Customer_phoneno")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("Sale_date")
                    .HasColumnType("date");

                entity.Property(e => e.SaleItemName)
                    .IsRequired()
                    .HasColumnName("Sale_item_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("Sale_price")
                    .HasColumnType("money");

                entity.Property(e => e.SaleQuantity).HasColumnName("Sale_quantity");
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.HasKey(e => e.SaleId)
                    .HasName("PK_Sale_item");

                entity.ToTable("Sale_item");

                entity.Property(e => e.SaleId).HasColumnName("Sale_id");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("Sale_date")
                    .HasColumnType("date");

                entity.Property(e => e.SaleItemName)
                    .IsRequired()
                    .HasColumnName("Sale_item_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.SalePrice)
                    .HasColumnName("Sale_price")
                    .HasColumnType("money");

                entity.Property(e => e.SaleQuantity).HasColumnName("Sale_quantity");
            });

            modelBuilder.Entity<ShopStaff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK_Shop_Staff");

                entity.ToTable("Shop_Staff");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("Phone_number")
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorId).HasColumnName("Vendor_id");

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("Vendor_name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.VendorPhoneno)
                    .IsRequired()
                    .HasColumnName("Vendor_phoneno")
                    .HasColumnType("varchar(13)");
            });
        }
    }
}