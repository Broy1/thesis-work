using DemoSalesApp.Data;
using FilterManagerPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FilterManagerPortal.Areas.Identity.Data;
using FimaService.FimaEmailService;
using FilterManagerPortal.Repository;

namespace FilterManagerPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            var connectionString = builder.Configuration.GetConnectionString("FimaDbContextConnection") ?? throw new InvalidOperationException("Connection string 'TestRegisterDbContextConnection' not found.");

            builder.Services.AddDbContext<FimaDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<FimaUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<FimaDbContext>();

            builder.Services.AddDbContext<TagsDbContext>(options =>
                 options.UseSqlServer(
             builder.Configuration.GetConnectionString("TagsDbConnection")
             ));

            builder.Services.AddDbContext<SalesAppDbContext>(options =>
                 options.UseSqlServer(
             builder.Configuration.GetConnectionString("SalesAppConnection")
             ));

            builder.Services.AddSingleton<IFimaEmailService,FimaEmailService>();
           
            builder.Services.AddScoped<IFimaRepo, FimaRepo>();
            builder.Services.AddScoped<IScanLogic, ScanLogic>();
            builder.Services.AddScoped<ITimerService, TimerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Start/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Start}/{action=Start}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}