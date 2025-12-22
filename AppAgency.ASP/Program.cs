using AppAgency.ASP.Services.Implementations;
using AppAgency.ASP.Services.Interfaces;

namespace AppAgency.ASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //IConfiguration config = builder.Configuration;

            //string baseAPIUrl = config.GetValue("BaseUrl", "");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Add httpClients with API Url
            builder.Services.AddHttpClient<DestinationAPIClient>();
            builder.Services.AddHttpClient<ActivityAPIClient>();
            builder.Services.AddHttpClient<BookingAPIClient>();
            // config httpClients
            builder.Services.AddScoped<IDestinationService, DestinationAPIClient>();
            builder.Services.AddScoped<IActivityService, ActivityAPIClient>();
            builder.Services.AddScoped<IBookingService, BookingAPIClient>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
