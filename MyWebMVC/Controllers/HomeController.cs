using Microsoft.AspNetCore.Mvc;
using MyWebMVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(InputModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Use the internal Docker network hostname "mywebapi"
            var response = await _httpClient.PostAsync("http://mywebapi/api/values", content);
            var responseString = await response.Content.ReadAsStringAsync();

            ViewBag.Response = responseString;
            return View("Result");
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}