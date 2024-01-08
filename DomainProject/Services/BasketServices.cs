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

        public async Task<ResponseApi<Basket>> CreateBasketAsync(int customerId)
        {
            _logger.Log(LogLevel.Information, $"Adding a basket to {customerId}");
            Basket? basket = null;
            int status = 0;
            string message = "";
            var customer = await _context.Customers.FindAsync(customerId);
            //validation
            if (customer != null)
            {
                basket = new Basket
                {
                    Customer = customer,
                    OrderTime = DateTime.Now,
                };
                _context.Baskets.Add(basket);
                try
                {
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

            var response =  new ResponseApi<Basket>
            {
                Data = basket,
                Status = status,
                Message =message
            };

            _logger.Log(LogLevel.Information, $"Adding a basket with response = {response} ends");
            return response;
        }

        public async Task<ResponseApi<Basket>> AddProductToBasketAsync(int productId, int basketId)
        {
            _logger.Log(LogLevel.Information, $"Adding a product {productId} to  basket {basketId} starts");
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

        public void AddProductToBasketUsingIds(int productId, int basketID)
        {
            throw new NotImplementedException();
        }

        public void AssignCustomerToBasket(Customer customer, Basket basket)
        {
            throw new NotImplementedException();
        }

        public void AssignCustomerToBasketUsingIds(int customerId, int basketID)
        {
            throw new NotImplementedException();
        }

       

        public void DeleteBasket(int basketId)
        {
            throw new NotImplementedException();
        }

        public List<Basket> GetBaskets()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseApi<Basket>> GetBaskettById(int basketId)
        {
            _logger.Log(LogLevel.Information, "method starts");
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

        public decimal GetTotalCost(Basket basket)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalCostUsingIds(int basketID)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromBasket(Product product, Basket basket)
        {
            throw new NotImplementedException();
        }

        public void RemoveProductFromBasketUsingIds(int productId, int basketID)
        {
            throw new NotImplementedException();
        }
    }
}
