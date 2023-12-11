// See https://aka.ms/new-console-template for more information
using DomainProject.Data;
using DomainProject.Models;
using DomainProject.Services;
using Microsoft.EntityFrameworkCore;


var context = new EshopDbContext();
ICustomerServices services = new CustomerServices(context);

List<Customer> customers = services.GetCustomers();

customers.ForEach(customer =>
       Console.WriteLine($"customer Id = {customer.Id}" +
       $" customer name {customer.Name}" +
       $" customer address = {customer.Address} "));
Console.WriteLine();


Customer? customerA = services.GetCustomerById(3);
Console.WriteLine($"customer Id = {customerA?.Id}" +
       $" customer name {customerA?.Name}" +
       $" customer address = {customerA?.Address} ");