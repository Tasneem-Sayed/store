using Microsoft.EntityFrameworkCore;
using Store.DAL.Entity;

namespace Store.DAL.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) :base(opt)
        {

        }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Products>()
            //    .HasMany(p => p.Order)
            //    .WithMany(t => t.Products)
            //    .UsingEntity<ProductsOrder>(
            //    j => j 
            //    .HasOne(pt => pt.Order)
            //    .WithMany(t =>t.ProductsOrder)
            //    .HasForeignK
            //    ey(pt => pt.OrderProductsId)
            //    .OnDelete(DeleteBehavior.Restrict),
            //     j => j
            //    .HasOne(pt => pt.Products)
            //    .WithMany(t => t.ProductsOrder)
            //    .HasForeignKey(pt => pt.ProductsId)
            //    .OnDelete(DeleteBehavior.Restrict),
            //     j =>
            //     {
            //         j.HasKey(t => new { t.ProductsId, t.OrderProductsId });
            //     }

            //    );
            modelBuilder.Entity<ProductsOrder>()
                .HasKey(t => new { t.ProductsId, t.OrderProductsId });

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(pt => pt.Order)
                .WithMany(t => t.ProductsOrder)
                .HasForeignKey(pt => pt.OrderProductsId)
                .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired();

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(pt => pt.Products)
                .WithMany(t => t.ProductsOrder)
                .HasForeignKey(pt => pt.ProductsId)
                .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(); 





        }
        public DbSet<Order> Order { get; set; }
       
        public DbSet<Products> Products { get; set; }

        public DbSet<Stores> Stores { get; set; }


        public DbSet<ProductsOrder> ProductsOrder { get; set; }

    }
}
