using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;

namespace AppAgency.ASP.Services.Implementations
{
    public class BookingAPIClient : IBookingService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Booking/";

        public BookingAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", ""));
        }

        public async Task Delete(int id)
        {
            await _http.DeleteAsync(_defaultRoute + id);
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Booking>>();
        }

        public async Task<Booking> Insert(CreateBookingForm booking)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, booking);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Booking>();
        }
    }
}
