using DomainProject.Dto;
using DomainProject.Models;
using Microsoft.AspNetCore.Mvc;
using MyWebAppNbg.Models;
using MyWebAppNbg.Services;
using Newtonsoft.Json;
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

        public IActionResult Customers()
        {
            _logger.Log(LogLevel.Information, "customers view");

            using HttpClient client = new ();
            client.BaseAddress = new Uri("https://localhost:7252/api/customer/c");
            var response =  client.GetAsync("");
            response.Wait();
            var result = response.Result;

            List<Customer>? customers = [];
            if (result.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var EmpResponse = result.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list
                var data = JsonConvert.DeserializeObject<ResponseApi<List<Customer>>>(EmpResponse);
                customers = data?.Data;
            }
            return View(customers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
