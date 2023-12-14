using DomainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services;

public interface ICustomerServices
{
    public Customer? CreateCustomer(Customer customer);
    public List<Customer>  GetCustomers();
    public Customer? GetCustomerById(int customerId); 
    public Customer? GetCustomerByName(string name);
    public Customer? UpdateCustomer(int customerId, string newAddress);
    public void DeleteCustomer(int customerId);
}

public interface IProductServices
{
    public Product? CreateProduct(Product product);
    public List<Product> GetProducts();
    public Product? GetProductById(int productId);
    public Product? GetProductByName(string name);
    public Product? UpdateProduct(int productId, decimal newPrice);
    public void DeleteProduct(int productId);
}

public interface IServices<T>
{
    public T? CreateProduct(T t);
    public List<T> GetProducts();
    public T? GetTById(int tId);
    public T? GetTByName(string name);
 //   public Product? UpdateProduct(int productId, decimal newPrice);
    public void DeleteT(int tId);
}

public interface IBasketServices
{
    public Basket? CreateBasket(Basket Basket);
    public List<Basket> GetBaskets();
    public Basket? GetBaskettById(int basketId);
    public void DeleteBasket(int basketId);


    //
    public void AddProductToBasket(Product product, Basket basket);
    public void RemoveProductFromBasket(Product product, Basket basket);
    public decimal GetTotalCost(Basket basket);
    public void AssignCustomerToBasket(Customer customer, Basket basket);


    public void AddProductToBasketUsingIds(int productId, int basketID);
    public void RemoveProductFromBasketUsingIds(int productId, int basketID);
    public decimal GetTotalCostUsingIds(int basketID);
    public void AssignCustomerToBasketUsingIds(int customerId, int basketID);

}
