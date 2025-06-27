using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<CategoryToProduct> categoryToProducts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetial> OrderDetails { get; set; }

        #region SeedData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>();
            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.CategoryId, t.ProductId });
            modelBuilder.Entity<Category>().HasData
                (
                new Category()
                {
                    ID = 1,
                    Name = "داستان و رمان",
                },
                new Category()
                {
                    ID = 2,
                    Name = "ادبیات"
                },
                new Category()
                {
                    ID = 3,
                    Name = "سبک زندگی"
                }
                );
            modelBuilder.Entity<Product>().HasData
                (
                new Product()
                {
                    Id = 1,
                    ItemId = 1,
                    Name = "هر دو در نهایت میمیرند",
                    Description = "کتاب هر دو در نهایت میمیرند نوشته آدام سیلور نویسنده امریکایی معاصر است"
                },
                new Product()
                {
                    Id = 2,
                    ItemId = 2,
                    Name = "هزار و یک شب",
                    Description = "جلد اول هزار و یک شب نوشته عبداللطیف طسوجی"
                },
                new Product()
                {
                    Id = 3,
                    ItemId = 3,
                    Name = "عیبی ندارد اگر حالت خوش نیست",
                    Description = "عیبی ندارد اگر حالت خوش نیست یا مواجه با اندوه و فقدان در فرهنگی که این را برنمی تابد"
                }
                );
            modelBuilder.Entity<Item>().HasData
                (
                new Item()
                {
                    OrderId = 1,
                    Price = 240000,
                    Quantity = 3
                },
                new Item()
                {
                    OrderId = 2,
                    Price = 500000,
                    Quantity = 1
                },
                new Item()
                {
                    OrderId = 3,
                    Price = 320000,
                    Quantity = 6,
                }
                );
            modelBuilder.Entity<CategoryToProduct>().HasData
                (
                new CategoryToProduct() { CategoryId = 1, ProductId = 1 },
               // new CategoryToProduct() { CategoryId = 2, ProductId = 1 },
               // new CategoryToProduct() { CategoryId = 3, ProductId = 1 },
               // new CategoryToProduct() { CategoryId = 1, ProductId = 2 },
                new CategoryToProduct() { CategoryId = 2, ProductId = 2 },
               // new CategoryToProduct() { CategoryId = 3, ProductId = 2 },
               // new CategoryToProduct() { CategoryId = 1, ProductId = 3 },
               // new CategoryToProduct() { CategoryId = 2, ProductId = 3 },
                new CategoryToProduct() { CategoryId = 3, ProductId = 3 }
                );

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}