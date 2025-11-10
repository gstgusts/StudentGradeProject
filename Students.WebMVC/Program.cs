using Microsoft.EntityFrameworkCore;
using Students.DataAccess;
using Students.DataAccess.Interfaces;
using Students.DataAccess.Services;

namespace Students.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var dataDir = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "Students.DataAccess"));
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);

            var cs = builder.Configuration.GetConnectionString("StudentDatabase")
                     ?? throw new InvalidOperationException("Missing ConnectionStrings:StudentDatabase");
            if (cs.StartsWith("\"") && cs.EndsWith("\"")) cs = cs.Trim('"');

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<StudentDbContext>(o => o.UseSqlServer(cs));

            builder.Services.AddScoped<IStudentRepository, StudentRepositoryService>();

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
