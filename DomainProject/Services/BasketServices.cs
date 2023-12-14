using DomainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services
{
    public class BasketServices : IBasketServices
    {
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

        public Basket? CreateBasket(Basket Basket)
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
