
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Students.DataAccess;
using Students.DataAccess.Interfaces;
using Students.DataAccess.Services;

namespace Students.Api
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

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<StudentDbContext>(o => o.UseSqlServer(cs));

            builder.Services.AddScoped<IStudentRepository, StudentRepositoryService>();

            // enable cors
            builder.Services.AddCors(o =>
            {
                o.AddDefaultPolicy(p => p.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
                });

                app.UseReDoc(options =>
                {
                    options.SpecUrl("/openapi/v1.json");
                });

                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // default cors policy
            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
