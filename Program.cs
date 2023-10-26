using CollegeGrievanceCell.Models;
using CollegeGrievanceCell.Repository;

namespace CollegeGrievanceCell
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            //Register HomeDbContextClass using dependency injection
            builder.Services.AddScoped<HomeDbContextClass>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                string connectionString = configuration.GetConnectionString("ConStr");
                return new HomeDbContextClass(connectionString);
            });

            //Register AnotherDbContextClass using dependency injection
            builder.Services.AddScoped<ComplaintFormDbContext>(provider =>
            {
                var configuration = provider.GetService<IConfiguration>();
                string connectionString = configuration.GetConnectionString("ConStr");
                return new ComplaintFormDbContext(connectionString);
            });


            var app = builder.Build();
            //Types Of Logs
            app.Logger.LogInformation("");
            app.Logger.LogWarning("");
            app.Logger.LogError("");
            //Logging Framework
            /*
             * Console
             * Debug
             * Event Log
             * file
             * Database
             */

            app.UseStaticFiles();
            app.MapControllerRoute(
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}/{id?}"
                );
            app.Run();

        }
    }
}