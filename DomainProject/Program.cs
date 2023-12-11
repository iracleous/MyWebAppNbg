// See https://aka.ms/new-console-template for more information
using DomainProject.Data;
using DomainProject.Models;
using DomainProject.Services;
using Microsoft.EntityFrameworkCore;


var context = new EshopDbContext();
ICustomerServices services = new CustomerServices(context);
Customer customer = new Customer() { Name = "Dimitris", Address = "" };
services.CreateCustomer(customer);



List<Customer> customers = services.GetCustomers();

customers.ForEach(customer =>
       Console.WriteLine($"customer Id = {customer.Id}" +
       $" customer name {customer.Name}" +
       $" customer address = {customer.Address} "));
Console.WriteLine();


Customer? customerA = services.GetCustomerById(1);
Console.WriteLine($"customer Id = {customerA?.Id}" +
       $" customer name {customerA?.Name}" +
       $" customer address = {customerA?.Address} ");