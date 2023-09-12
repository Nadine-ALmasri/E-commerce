using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.Interface;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddControllers();
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<E_commerceDbContext>
                (opions => opions.UseSqlServer(connString));
            builder.Services.AddTransient<ICategory, CategoryServices>();
            builder.Services.AddTransient<IProduct, ProductServices>();
            builder.Services.AddTransient<IUser, IdentityUserService>();
            /// regstor the identty
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
      .AddEntityFrameworkStores<E_commerceDbContext>()
;

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();
            builder.Services.ConfigureApplicationCookie(options => {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/auth/LogIn";
            }) ;
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
         

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}