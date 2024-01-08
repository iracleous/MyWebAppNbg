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
        return await _basketServices.GetBaskettById(basketId);
    }

    [HttpPost]
    [Route("addbasket/{customerId}")]
    public async Task<ResponseApi<Basket>> CreateBasket(int customerId)
    {
        _logger.Log(LogLevel.Information, "method CreateBasket starts/ends");
        return await _basketServices.CreateBasketAsync(customerId);
    }

    [HttpPost]
    [Route("addTobasket/{basketId}/{productId}")]
    public async Task<ResponseApi<Basket>> AddToBasket(int productId, int basketId)
    {
        _logger.Log(LogLevel.Information, "method AddToBasket starts/ends");
        return await _basketServices.AddProductToBasketAsync(productId, basketId);
    }
}
