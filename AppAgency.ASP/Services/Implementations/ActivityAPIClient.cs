using AppAgency.ASP.Entities;
using AppAgency.ASP.Models;
using AppAgency.ASP.Services.Interfaces;

namespace AppAgency.ASP.Services.Implementations
{
    public class ActivityAPIClient : IActivityService
    {
        private readonly HttpClient _http;
        private readonly string _defaultRoute = "/api/Activity/";

        public ActivityAPIClient(HttpClient http, IConfiguration config)
        {
            _http = http;
            _http.BaseAddress = new Uri(config.GetValue("BaseUrl", ""));
        }
        public async Task<Activity> Insert(CreateActivityForm activity)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_defaultRoute, activity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Activity>();
        }
    }
}
