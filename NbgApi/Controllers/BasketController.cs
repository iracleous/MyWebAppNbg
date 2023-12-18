using DomainProject.Models;
using DomainProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAppNbg.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{

    private readonly ICustomerServices _customerServices;
    private readonly IBasketServices _basketServices;
    private readonly ILogger<BasketController> _logger;

    public BasketController(ICustomerServices customerServices,
        IBasketServices basketServices, ILogger<BasketController> logger)
    {
        _customerServices = customerServices;
        _basketServices = basketServices;
        _logger = logger;
    }

    [HttpPost]
    [Route("addbasket/{id}")]
    public async Task<bool> AddBasket(int id)
    {
      Basket? basket =  await _basketServices.CreateBasket(id);
      return basket != null;
    }
    
}
