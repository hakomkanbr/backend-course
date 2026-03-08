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

        // Roles
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<Role>().HasData(
            new Role() { Id = 1, Name = "Admin"},
            new Role() { Id = 2, Name = "Manager"},
            new Role() { Id = 3, Name = "Customer"}
        );


        // Users
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>().HasKey(i => i.Id);


        //modelBuilder.Entity<User>().HasIndex(i => new { i.Email , i.UserName});

        modelBuilder.Entity<User>()
            .Property(i => i.UserName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
             .Property(i => i.Email)
             .IsRequired()
             .HasMaxLength(200);


        modelBuilder.Entity<User>()
            .HasOne(i => i.Role)
            .WithMany(i => i.Users)
            .HasForeignKey(i => i.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        //modelBuilder.Entity<Product>().ToTable("ProductTable");

        //modelBuilder.Entity<Product>().HasKey(i => i.Id);

        //modelBuilder.Entity<Product>().HasIndex(i => i.Name);


        // Category 1 ----- * Products

        //modelBuilder.Entity<Product>()
        //    .Property(i => i.Name)
        //    .HasColumnName("ProductName")
        //    .HasColumnType("decimal(18,2)")
        //    .IsRequired();

        //modelBuilder.Entity<Product>()
        //    .HasOne(i => i.Category)
        //    .WithMany(i => i.Products)
        //    .HasForeignKey(p => p.CategoryId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //modelBuilder.Entity<Category>()
        //    .HasMany(i => i.Products)
        //    .WithOne(i => i.Category)
        //    .HasForeignKey(p => p.CategoryId)
        //    .OnDelete(DeleteBehavior.NoAction);


        /*
        - Categorie
         * Electronic => 1
         * Clothes => 2
         
        - Products
         * Labtop => CategoryId = 1
         * Phone => CategoryId = 1
         * TShirt => CategoryId = 2
         
        Request To Sql Server => Delete From Categories Where Id = 1
        

        cannot delete category products still exits
        
        */

        //modelBuilder.Entity<Product>()
        //    .HasOne(i => i.Category)
        //    .WithMany(i => i.Products)
        //    .HasForeignKey(p => p.CategoryId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //modelBuilder.Entity<Order>()
        //    .HasMany(i => i.OrderItems)
        //    .WithOne(i => i.Order)
        //    .HasForeignKey(p => p.OrderId);

        //modelBuilder.Entity<OrderItems>()
        //    .HasOne(i => i.Order)
        //    .WithMany(i => i.OrderItems)
        //    .HasForeignKey(p => p.OrderId)
        //    .OnDelete(DeleteBehavior.Cascade);


        /*
        - CasCade Delete
        عند حذف السجل الاساسي يتم حذف كل البيانات المرتبطة به

        - Restrict
        يقوم بمنع حذف السجل الاساسي اذا كانت هناك بيانات مرتبطة به

        - SetNull
        ممكن مسح السجل الاساسي مع تبديل قيمة ForeignKey الى null

        - NoAction
        لا يمكن حذف القسم لان هناك منتجات مرتبطة بها
        */



        base.OnModelCreating(modelBuilder);
    }
}
