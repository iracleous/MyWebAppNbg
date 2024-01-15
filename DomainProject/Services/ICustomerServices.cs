using DomainProject.Dto;
using DomainProject.Models;

namespace DomainProject.Services;

public interface ICustomerServices
{
    public Task<ResponseApi<Customer>> CreateCustomerAsync(Customer customer);
 //   object CreateCustomerAsync(Func<Customer> isAny);
    public Task<ResponseApi<List<Customer>>>  GetCustomersAsync();
    //public Task<ResponseApi<Customer?>> GetCustomerByIdAsync(int customerId); 
    //public Task<ResponseApi<Customer?>> GetCustomerByNameAsync(string name);
    //public Task<ResponseApi<Customer?>> UpdateCustomerAsync(int customerId, string newAddress);
    //public Task DeleteCustomerAsync(int customerId);
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
