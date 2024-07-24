using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using MyWebApi.Models;

namespace ApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(InputModel model)
        {
            Console.WriteLine($"Received: {model.InputValue}");
            return Ok($"Received value: {model.InputValue}");
        }
    }
}