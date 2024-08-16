using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsAcademy.Models;

namespace SportsAcademy.Controllers
{
    public class WeatherModelsController : Controller
    {
        private readonly HttpClient _httpClient;

        public WeatherModelsController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string city)
        {
            string apiKey = "YOUR_API_KEY"; // Replace with your actual API key
            string apiUrl = $"http://api.weatherapi.com/v1/current.json?key=d84d5cb791cf4db694b131732233011&q=${city}&aqi=no";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                WeatherModel weather = JsonConvert.DeserializeObject<WeatherModel>(jsonResponse);

                return View(weather);
            }

            return View("Error");
        }
    }
}