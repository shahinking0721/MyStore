using Microsoft.EntityFrameworkCore;
using Mystore.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Data;


namespace Mystore.Data
{
        public class StoreDbContect : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MYDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Product>()
                    .HasOne<Category>(s => s.Category)
                    .WithMany(g => g.products)
                    .HasForeignKey(s => s.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);



                     modelBuilder.Entity<Category>()
                    .HasMany<Product>(g => g.products)
                    .WithOne(s => s.Category)
                    .HasForeignKey(s => s.CategoryId);
            }

                     public DbSet<Product> Products { get; set; }
                      public DbSet<Category> Categorys { get; set; }
        }

}
