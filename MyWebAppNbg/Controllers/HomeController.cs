using Microsoft.AspNetCore.Mvc;
using MyWebAppNbg.Models;
using MyWebAppNbg.Services;
using System.Diagnostics;

namespace MyWebAppNbg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactInfo()
        {
            _logger.Log( LogLevel.Information,"log info" );
            IContactInfoManager contactInfoManager = new ContactInfoManager();
            ContactInfo contact = contactInfoManager.ReadContactInfo();
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
