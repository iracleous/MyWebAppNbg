using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/**
Product
    Id, Name, Price
Customer
    Id, Name, Email, RegistrationDate

OrderItem
    Id, Product, Quantity
Basket
    Id, CreationDate, Customer, List<OrderItem>
*/



namespace DomainProject.Models;

public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateOnly RegistrationDate { get; set; }

    public virtual List<Basket> Baskets { get; set; } = [];
}


public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public virtual List<Basket> Baskets { get; set; } = [];
}

public class Basket
{
    public int Id { get; set; }
    public DateTime OrderTime {  get; set; }

    public virtual List<Product> Products { get; set; } = [];
    public virtual Customer? Customer { get; set; }
}
