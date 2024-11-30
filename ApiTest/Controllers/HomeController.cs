using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApiTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
