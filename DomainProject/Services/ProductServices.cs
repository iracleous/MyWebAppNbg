using DomainProject.Data;
using DomainProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services;

public class ProductServices: IProductServices
{

    private readonly EshopDbContext context;
    public ProductServices(EshopDbContext context)
    {
        this.context = context;
    }


    // Create a new Product
    public Product? CreateProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
        return product;
    }

    //Delete
    public void DeleteProduct(int productId)
    {
        Product? productForDelete = context
            .Products
            .Find(productId);
        if (productForDelete != null)
        {
            context.Remove(productForDelete);
            context.SaveChanges();
        }
    }

    // Read by Id
    public Product? GetProductById(int productId)
    {
        Product? product = context
            .Products
            .Find(productId);
        return product;
    }

    public Product? GetProductByName(string name)
    {
        // Read by a
        Product? product = context
            .Products
            .Where(product => name.Equals(product.Name))
            .FirstOrDefault();
        return product;
    }

    // Read All
    public List<Product> GetProducts()
    {

        return context.Products.ToList();
    }

    //Update
    public Product? UpdateProduct(int productId, decimal newPrice)
    {
        Product? productForUpdate = context
         .Products
         .Find(productId);

        if (productForUpdate != null)
        {
            productForUpdate.Price = newPrice;
            context.SaveChanges();
        }
        return productForUpdate;
    }


}
