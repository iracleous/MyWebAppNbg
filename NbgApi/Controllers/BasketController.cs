using DomainProject.Dto;
using DomainProject.Models;
using DomainProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAppNbg.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    private readonly IBasketServices _basketServices;
    private readonly ILogger<BasketController> _logger;

    public BasketController( 
        IBasketServices basketServices, ILogger<BasketController> logger)
    {
        _basketServices = basketServices;
        _logger = logger;
    }

    [HttpGet]
    [Route("getBasket/{basketId}")]
    public async Task<ResponseApi<Basket>> GetBasket(int basketId)
    {
        _logger.Log(LogLevel.Information, "method GetBasket starts/ends");
        return await _basketServices.GetBaskettByIdAsync(basketId);
    }

    [HttpPost]
    [Route("addbasket")]
    public async Task<ResponseApi<Basket>> CreateBasket(CustomerInfo customerInfo)
    {
        _logger.Log(LogLevel.Information, "method CreateBasket starts/ends");
        return await _basketServices.CreateBasketAsync(customerInfo);
    }

    [HttpPost]
    [Route("addTobasket")]
    public async Task<ResponseApi<Basket>> AddToBasket(OrderItem orderItem)
    {
        _logger.Log(LogLevel.Information, "method AddToBasket starts/ends");
        return await _basketServices.AddProductToBasketAsync(orderItem);
    }
}
