
using AppAgency.BLL.Services.Implementations;
using AppAgency.BLL.Services.Interfaces;
using AppAgency.DAL;
using AppAgency.DAL.Repositories;
using AppAgency.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AppAgency.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = builder.Configuration;

            // Add services to the container.

            //config services EF
            builder.Services.AddDbContext<AgenceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Agence.EntityFramework")));
            //config services DAL
            builder.Services.AddScoped<IDestinationRepo, SqlDestinationRepo>();
            builder.Services.AddScoped<IActivityRepo, SqlActivityRepo>();
            builder.Services.AddScoped<IBookingRepo, SqlBookingRepo>();
            //config services BLL
            builder.Services.AddScoped<IDestinationService, DestinationService>();
            builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IBookingService, BookingService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(opt =>
            {
                // Déclaration d'une policy CORS nommée "MvcCors"
                opt.AddPolicy("MvcCors", p =>
                {
                    var origins = builder.Configuration
                        .GetSection("Cors:AllowedOrigins")
                        .Get<string[]>() ?? [];

                    p.WithOrigins(origins)
                     .AllowAnyHeader()
                     .AllowAnyMethod();
                    //.WithMethods("GET", "POST", "PUT");
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MvcCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
