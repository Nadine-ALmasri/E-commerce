using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace E_commerce.Data
{
    public class E_commerceDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public E_commerceDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedRoles(modelBuilder, "Administrator");
            SeedRoles(modelBuilder, "Editor");
            SeedRoles(modelBuilder, "User");


            modelBuilder.Entity<Category>().HasData(
             new Category { Id = 1, Name = "Electronics" },
             new Category { Id = 2, Name = "Computers & Tablets" },
             new Category { Id = 3, Name = "Makeup" }
             );

            modelBuilder.Entity<Products>().HasData(
            new Products { Id = 1, Name = "LG Microwave", Price = 155.00, Description = "Great , Large ,A++ electricity consuming", CategoryId = 1 , ImageUrl= "https://m.media-amazon.com/images/I/71qaGnOxACL._AC_UF1000,1000_QL80_.jpg" },
            new Products { Id = 2, Name = "Dish Washer", Price = 450.00, Description = "cleaning dishes in a foodservice environment to ensure that there is always plenty of clean tableware at hand", CategoryId = 1 , ImageUrl = "https://longeatonappliances.co.uk/wp-content/uploads/2021/04/smv4hvx38g.jpg" },
            new Products { Id = 3, Name = "SAMSUNG TV ", Price = 500.00, Description = "75\" Neo QLED 4K HDR Screen", CategoryId = 1, ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=Ao8YcK6t&id=2C1E1687CFBD43C8698D6F5659510F6A17BA1DC3&thid=OIP.Ao8YcK6tWt8d8JVTA1J91AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_hg43nj470mfxza_43_470_series_full_1444284.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.028f1870aead5adf1df0955303527dd4%3frik%3dwx26F2oPUVlWbw%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=samsung+tv&simid=608040461989200792&FORM=IRPRST&ck=4319176676534CADD333DE27C0446661&selectedIndex=1" },
            new Products { Id = 4, Name = "SAMSUNG Galaxy Tab A8", Price = 170.00, Description = "SAMSUNG Galaxy Tab A8 10.5” 32GB Android Tablet, LCD Screen, Kids Content, Smart Switch, Long Lasting Battery, US Version, 2022, Dark Gray", CategoryId = 2 , ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=QZRDX0P1&id=EA04027D8A449D5095FBC88D989F9C29E98794FA&thid=OIP.QZRDX0P1o7Pfswsyk9pA5AHaHa&mediaurl=https%3a%2f%2fwww.bhphotovideo.com%2fimages%2fimages2500x2500%2fsamsung_sm_t380nzkexar_8_0_tab_a_8_0_1363546.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.4194435f43f5a3b3dfb30b3293da40e4%3frik%3d%252bpSH6Smcn5iNyA%26pid%3dImgRaw%26r%3d0&exph=2500&expw=2500&q=SAMSUNG+Galaxy+Tab+A8&simid=607997091423989576&FORM=IRPRST&ck=23A2F0EFA68BAE47D447D01D91A0FD37&selectedIndex=2" },
            new Products { Id = 5, Name = "Maybelline Mascara", Price = 24.00, Description = " Lash Sensational Sky High Washable ,Volumizing, Lengthening, Defining,", CategoryId = 3, ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=IUaw2DIA&id=C2A654B6E576FBFBAEC770E1A43D6D7CED8F2A72&thid=OIP.IUaw2DIAAE7KHbt3MUkudwHaHa&mediaurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.2146b0d83200004eca1dbb7731492e77%3frik%3dciqP7XxtPaThcA%26riu%3dhttp%253a%252f%252fimages.chickadvisor.com%252fitem%252f2911%252foriginal%252fa1e9cc36fa3678ec8624377b41f9ec23.jpg%26ehk%3d3pGJs1RCFKTTmQ0Ha%252bQ9Skwrh3aiET0Gt6G9bM9lwnI%253d%26risl%3d%26pid%3dImgRaw%26r%3d0&exph=1000&expw=1000&q=Maybelline+Mascara&simid=607986371212023103&FORM=IRPRST&ck=2206643943BA3E4D8F5E36A698C6EA2F&selectedIndex=2" },
            new Products { Id = 7, Name = "acer 2023 Newest Chromebook 15.6\"", Price = 205.00, Description = "acer 2023 Newest Chromebook 15.6\" FHD 1080p IPS Touchscreen Light Computer Laptop, Due-core Intel Celeron N4020, 4GB RAM, 64GB", CategoryId = 2, ImageUrl = "https://www.bing.com/images/search?view=detailV2&ccid=1JRE%2bu7d&id=B998B5F4D67B37F04B7AAA141D6A29ADB43F5B63&thid=OIP.1JRE-u7dKu8XMd9zEGI_yQHaFF&mediaurl=https%3a%2f%2fpisces.bbystatic.com%2fimage2%2fBestBuy_US%2fimages%2fproducts%2f6170%2f6170703_sd.jpg&cdnurl=https%3a%2f%2fth.bing.com%2fth%2fid%2fR.d49444faeedd2aef1731df7310623fc9%3frik%3dY1s%252ftK0pah0Uqg%26pid%3dImgRaw%26r%3d0&exph=813&expw=1184&q=acer+2023+Newest+Chromebook+15.6&simid=607996769307082530&FORM=IRPRST&ck=7C9DB0F6618896E2BD2D321B20A25CDF&selectedIndex=3" },
            new Products { Id = 8, Name = "NYX PROFESSIONAL MAKEUP Epic Ink Liner", Price =9.00, Description = ", Waterproof Liquid Eyeliner - Black, Vegan Formula", CategoryId = 3, ImageUrl = "https://th.bing.com/th/id/R.159a99ed1bb4a1aadbf8b0eb25ac58f9?rik=YZUjrgNfX3Hjfw&pid=ImgRaw&r=0" }
            );

        
            modelBuilder.Entity<CartProducts>()
      .HasKey(cp => new { cp.Id ,cp.ProductId}); // Assuming CartId in CartProduct matches Cart's primary key

            modelBuilder.Entity<CartProducts>()
                .HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.Id);

            modelBuilder.Entity<CartProducts>()
                .HasOne(cp => cp.Product);
        }
        private void SeedRoles(ModelBuilder modelBuilder, string roleName)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };
            modelBuilder.Entity<IdentityRole>().HasData(role);
        }
        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Cart{ get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}

