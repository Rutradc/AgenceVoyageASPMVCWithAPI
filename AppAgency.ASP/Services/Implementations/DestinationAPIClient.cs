using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;

namespace AppAgency.ASP.Services.Implementations
{
    public class DestinationAPIClient : IDestinationService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Destination/";

        public DestinationAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", ""));
        }

        public async Task<IEnumerable<Destination>> GetAll()
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Destination>>();
        }

        public async Task<Destination> GetById(int id)
        {
            HttpResponseMessage response = await _http.GetAsync(_defaultRoute + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Destination>();
        }

        public async Task<Destination> Insert(CreateDestinationForm destination)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, destination);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Destination>();
        }
    }
}
