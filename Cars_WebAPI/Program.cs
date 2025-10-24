using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Cars_WebAPI.Data;
using Cars_WebAPI.Areas.Identity.Data;
namespace Cars_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("Cars_WebAPIContextConnection") ?? throw new InvalidOperationException("Connection string 'Cars_WebAPIContextConnection' not found.");;

            builder.Services.AddDbContext<Cars_WebAPIContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<Cars_WebAPIUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Cars_WebAPIContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
