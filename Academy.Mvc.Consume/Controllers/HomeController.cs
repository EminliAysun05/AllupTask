using Academy.Mvc.Consume.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Academy.Mvc.Consume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExternalApiService _externalApiService;

        public HomeController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<object> Index(int id)
        {
            var url = $"https://localhost:7259/api/Students/{id}";

            var student = await _externalApiService.GetAsync(url);

            return student;
        }
    }
}
