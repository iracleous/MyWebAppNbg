using DomainProject.Dto;
using DomainProject.Models;

namespace DomainProject.Services;

public interface IBasketServices
{
    public Task<ResponseApi<Basket>> CreateBasketAsync(CustomerInfo customer);
    public Task<ResponseApi<Basket>> GetBaskettByIdAsync(int basketId);

    public Task<ResponseApi<List<Basket>>> GetBasketsAsync();
    public Task<ResponseApi<bool>> DeleteBasketAsync(int basketId);

    //
    public Task<ResponseApi<Basket>> AddProductToBasketAsync(OrderItem orderItem);
    public Task<ResponseApi<bool>> RemoveProductFromBasketAsync(OrderItem orderItem);
    public Task<ResponseApi<decimal>> GetTotalCostAsync(int basketId);

}
