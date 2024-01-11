using DomainProject.Data;
using DomainProject.Dto;
using DomainProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services
{
    public class BasketServices : IBasketServices
    {

        private readonly EshopDbContext _context;
        private readonly ILogger<BasketServices> _logger;

        public BasketServices(EshopDbContext context, ILogger<BasketServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseApi<Basket>> CreateBasketAsync(CustomerInfo customerInfo)
        {
            _logger.Log(LogLevel.Information, $"Adding a basket ");

             Basket? basket = null;
            int status = 0;
            string message = "";
            if (customerInfo == null)
            {

                status = CustomErrors.NULL_INPUT;
                message = "null input";
            }
            else
            {
                var customer = await _context.Customers.FindAsync(customerInfo.CustomerId);
                //validation
                if (customer != null)
                {
                    basket = new Basket
                    {
                        Customer = customer,
                        OrderTime = DateTime.Now,
                    };
                    
                    try
                    {
                        _context.Baskets.Add(basket);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        basket = null;
                        status = CustomErrors.EXCEPTION;
                        message = ex.Message;
                    }
                }
                else
                {
                    basket = null;
                    status = CustomErrors.NULL_INPUT;
                    message = "No such customer";
                }
            }
            var response =  new ResponseApi<Basket>
            {
                Data = basket,
                Status = status,
                Message =message
            };

            _logger.Log(LogLevel.Information, $"Adding a basket with response = {response} ends");
            return response;
        }

        public async Task<ResponseApi<Basket>> AddProductToBasketAsync(
            OrderItem orderItem)
        {
            _logger.Log(LogLevel.Information, $"Adding a product to  basket   starts");


            var productId = orderItem.ProductId;
            var basketId =orderItem.BasketId;
            var product = await _context.Products.FindAsync(productId);
            var basket = await _context.Baskets.FindAsync(basketId);
            int status;
            string message;
            if(product != null && basket != null) {
                basket.Products.Add(product);
                try
                {
                    await _context.SaveChangesAsync();
                    status = CustomErrors.OK;
                    message= "Item added to basket";   
                }
                catch (Exception ex) 
                { 
                   status = CustomErrors.EXCEPTION;
                   message= ex.Message;    
                }
            }
            else
            {
                status = CustomErrors.NULL_INPUT;
                message= "No sush product or basket";    
            }
            var result = new ResponseApi<Basket> { Data = basket, Status= status, Message = message };
            _logger.Log(LogLevel.Information, $"Adding a product {productId} to  basket {basketId} and result = {result} ends");
            return result;
        }

         

        
        public async Task<ResponseApi<Basket>> GetBaskettByIdAsync(int basketId)
        {
            _logger.Log(LogLevel.Information, "method starts");


           // _context.Baskets.Where(b => b.Id == basketId).Include(b => b.Customer).FirstOrDefaultAsync();

            var data = await _context.Baskets.FindAsync(basketId);

            var result = new ResponseApi<Basket>
            {
                Data = data ,
                Status = data==null? CustomErrors.NULL_INPUT : CustomErrors.OK,
                Message = data == null ?"Not found":""

            };
            _logger.Log(LogLevel.Information, "method ends");
            return result;
        }

        public Task<ResponseApi<List<Basket>>> GetBasketsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<bool>> DeleteBasketAsync(int basketId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<bool>> RemoveProductFromBasketAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseApi<decimal>> GetTotalCostAsync(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
