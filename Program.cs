using E_commerce.Data;
using E_commerce.Models;
using E_commerce.Models.Interface;
using E_commerce.Models.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace E_commerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<E_commerceDbContext>
                (opions => opions.UseSqlServer(connString));
            builder.Services.AddTransient<CartServices>();
            builder.Services.AddTransient<ICategory, CategoryServices>();
            builder.Services.AddTransient<ICart,CartServices>();
            builder.Services.AddTransient<IProduct, ProductServices>();
            builder.Services.AddTransient<IUser, IdentityUserService>();
            builder.Services.AddTransient<IOrder, OrderServices>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddRazorPages();
            /// regstor the identty
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
      .AddEntityFrameworkStores<E_commerceDbContext>()
;
           
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                    options.LoginPath = "/auth/LogIn"; // Set the login path
                    options.AccessDeniedPath = "/Account/auth/AccessDenied"; // Set the access denied path
                });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorPolicy", policy =>
                    policy.RequireRole("Administrator"));
                options.AddPolicy("EditorPolicy", policy =>
                    policy.RequireRole("Editor"));
                options.AddPolicy("UserPolicy", policy =>
                    policy.RequireRole("User"));
            });

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
            app.UseAuthentication(); // Place UseAuthentication before UseAuthorization
            app.UseAuthorization(); // Place UseAuthorization here
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");
            app.Run();
        }
    }
}