using ECommerce.Tables;
using ECommerce.Tables.Customer;
using ECommerce.Tables.Identity;
using ECommerce.Tables.Products;
using Microsoft.EntityFrameworkCore;

namespace ECommerce;

/*
 1.Data Annoations 
 2.Fluent Api
*/

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<OrderItems> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CartItems> CartItems { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Product");
        
        modelBuilder.Entity<Product>().HasKey(i => i.Id);

        modelBuilder.Entity<Product>().HasIndex(i => i.Name);

        modelBuilder.Entity<Product>()
            .Property(i => i.Name)
            .HasColumnName("ProductName")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        modelBuilder.Entity<Category>()
            .HasMany(i => i.Products)
            .WithOne(i => i.Category)
            .HasForeignKey(p => p.CategoryId);

        /*
         Electronic =>
            - labtop
            - phone
            - tablet

        cannot delete category products still exits
        
        */

        modelBuilder.Entity<Product>()
            .HasOne(i => i.Category)
            .WithMany(i => i.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>()
            .HasMany(i => i.OrderItems)
            .WithOne(i => i.Order)
            .HasForeignKey(p => p.OrderId);

        modelBuilder.Entity<OrderItems>()
            .HasOne(i => i.Order)
            .WithMany(i => i.OrderItems)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        /*
        - CasCade Delete
        عند حذف السجل الاساسي يتم حذف كل البيانات المرتبطة به

        - Restrict
        يقوم بمنع حذف السجل الاساسي اذا كانت هناك بيانات مرتبطة به

        - SetNull
        */


        base.OnModelCreating(modelBuilder);
    }
}
