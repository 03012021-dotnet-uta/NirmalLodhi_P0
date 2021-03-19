using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaBox.Domain.Models
{
    public partial class OPOSContext : DbContext
    {
        public OPOSContext()
        {
        }

        public OPOSContext(DbContextOptions<OPOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaCrust> PizzaCrusts { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<PizzaOrderDetail> PizzaOrderDetails { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<PizzaStore> PizzaStores { get; set; }
        public virtual DbSet<PizzaTopping> PizzaToppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=QBLAP100\\SQL1;Database=OPOS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(40);

                entity.Property(e => e.LastName).HasMaxLength(40);

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.PizzaCrustId).HasColumnName("PizzaCrustID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.Property(e => e.Price).HasComputedColumnSql("(((((isnull([dbo].[GetCrustPrice]([PizzaCrustID]),(0))+isnull([dbo].[GetToppingPrice]([PizzaTopping1]),(0)))+isnull([dbo].[GetToppingPrice]([PizzaTopping2]),(0)))+isnull([dbo].[GetToppingPrice]([PizzaTopping3]),(0)))+isnull([dbo].[GetToppingPrice]([PizzaTopping4]),(0)))+isnull([dbo].[GetToppingPrice]([PizzaTopping5]),(0)))", false);

                entity.HasOne(d => d.PizzaCrust)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaCrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_PizzaSize_PizzaCrustID");

                entity.HasOne(d => d.PizzaTopping1Navigation)
                    .WithMany(p => p.PizzaPizzaTopping1Navigations)
                    .HasForeignKey(d => d.PizzaTopping1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_ToppingID1");

                entity.HasOne(d => d.PizzaTopping2Navigation)
                    .WithMany(p => p.PizzaPizzaTopping2Navigations)
                    .HasForeignKey(d => d.PizzaTopping2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pizza_ToppingID2");

                entity.HasOne(d => d.PizzaTopping3Navigation)
                    .WithMany(p => p.PizzaPizzaTopping3Navigations)
                    .HasForeignKey(d => d.PizzaTopping3)
                    .HasConstraintName("FK_Pizza_ToppingID3");

                entity.HasOne(d => d.PizzaTopping4Navigation)
                    .WithMany(p => p.PizzaPizzaTopping4Navigations)
                    .HasForeignKey(d => d.PizzaTopping4)
                    .HasConstraintName("FK_Pizza_ToppingID4");

                entity.HasOne(d => d.PizzaTopping5Navigation)
                    .WithMany(p => p.PizzaPizzaTopping5Navigations)
                    .HasForeignKey(d => d.PizzaTopping5)
                    .HasConstraintName("FK_Pizza_ToppingID5");
            });

            modelBuilder.Entity<PizzaCrust>(entity =>
            {
                entity.ToTable("PizzaCrust");

                entity.Property(e => e.PizzaCrustId).HasColumnName("PizzaCrustID");

                entity.Property(e => e.PizzaCrustDescription)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.PizzaCrusts)
                    .HasForeignKey(d => d.PizzaSizeId);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.ToTable("PizzaOrder");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderStatus).HasMaxLength(10);

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder_Store_StoreID");
            });

            modelBuilder.Entity<PizzaOrderDetail>(entity =>
            {
                entity.HasKey(e => e.PizzaOrderId)
                    .HasName("PK_PizzaOrderDetail_PizzaOrderId");

                entity.Property(e => e.PizzaOrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderStatus).HasMaxLength(10);

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.PizzaOrderDetailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PizzaOrderDetailID");

                entity.Property(e => e.Price).HasComputedColumnSql("(isnull([dbo].[GetPizzaPrice]([PizzaID]),(0))*isnull([PizzaQuantity],(0)))", false);

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrderDetails)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder_Pizza_PizzaID");

                entity.HasOne(d => d.PizzaOrder)
                    .WithOne(p => p.PizzaOrderDetail)
                    .HasForeignKey<PizzaOrderDetail>(d => d.PizzaOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder_PizzaOrderDetail_PizzaOrderDetailID");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.ToTable("PizzaSize");

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.Property(e => e.Dimenssions)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.PizzaSize1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("PizzaSize");
            });

            modelBuilder.Entity<PizzaStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK_Store_StoreID");

                entity.ToTable("PizzaStore");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.ToTable("PizzaTopping");

                entity.Property(e => e.PizzaToppingId).HasColumnName("PizzaToppingID");

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.Property(e => e.PizzaToppingDescription)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .HasConstraintName("FK_PizzaSize_PizzaSizeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
