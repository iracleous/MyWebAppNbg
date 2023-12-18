using DomainProject.Data;
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

        public async Task<Basket?> CreateBasket(int customerId)
        {
            _logger.Log(LogLevel.Information, $"Adding a basket to {customerId}");
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null) { return null; }
            var basket = new Basket
            {
                Customer = customer,
                OrderTime = DateTime.Now,
            };
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();
            return basket;
        }




        public void AddProductToBasket(Product product, Basket basket)
        {
            throw new NotImplementedException();
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

        public Basket? GetBaskettById(int basketId)
        {
            throw new NotImplementedException();
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
