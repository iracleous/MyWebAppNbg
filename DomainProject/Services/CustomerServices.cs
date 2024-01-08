using DomainProject.Data;
using DomainProject.Dto;
using DomainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainProject.Services;

    //CRUD implementation
public class CustomerServices : ICustomerServices
{
    private readonly EshopDbContext _context;
    private readonly ILogger<CustomerServices> _logger;

    public CustomerServices(EshopDbContext context, 
        ILogger<CustomerServices> logger)
    {
        _context = context; 
        _logger = logger;
    }


    // Create a new Customer
    public async Task<ResponseApi<Customer>> CreateCustomerAsync
        (Customer customer)
    {
        _logger.Log(LogLevel.Information, "CreateCustomerAsync started");
        int status =  CustomErrors.OK;
        string message;

        // simple validation
        if (customer != null && customer.Name!= null ) 
        { 
            _context.Customers.Add(customer);
            try
            {
                await _context.SaveChangesAsync();
                message = "the customer has been successfully created";
            }
            catch(Exception ex)
            {
                status = CustomErrors.EXCEPTION;
                message = ex.Message;
            }
            
        }
        else
        {
            status = CustomErrors.NULL_INPUT;
            message = "the input was null and the customer has has not been created";
        }
        _logger.Log(LogLevel.Information, "CreateCustomerAsync ended");
        return new ResponseApi<Customer>
        {
            Data = customer,
            Status = status,
            Message = message
        };
    }

  // Read All
    public async Task<ResponseApi<List<Customer>>> GetCustomersAsync() 
    {
        _logger.Log(LogLevel.Information, "GetCustomersAsync started/ended");

        try
        {
            return new ResponseApi<List<Customer>>
            {
                Data = await _context.Customers.ToListAsync(),
                Status = CustomErrors.OK,
            };
        }
        catch (Exception ex)
        {
            return new ResponseApi<List<Customer>>
            {
                Message = ex.Message,
                Status = CustomErrors.EXCEPTION,
            };
        }
         


        
    }


    ////Delete
    //public void DeleteCustomer(int customerId)
    //{
    //    Customer? customerForDelete = _context
    //        .Customers
    //        .Find(customerId);
    //    if (customerForDelete != null)
    //    {
    //        _context.Remove(customerForDelete);
    //        _context.SaveChanges();
    //    }
    //}

    //// Read by Id
    //public Customer? GetCustomerById(int customerId)
    //{
    //    Customer? customer = _context
    //        .Customers
    //        .Find(customerId);
    //    return customer;
    //}

    //public Customer? GetCustomerByName(string name)
    //{
    //    // Read by a
    //    Customer? customer = _context
    //        .Customers
    //        .Where(customer => name.Equals(customer.Name))
    //        .FirstOrDefault();
    //    return customer;
    //}

  
       
    //    //Update
    //public Customer? UpdateCustomer(int customerId, string newAddress)
    //{
    //    Customer? customerForUpdate = _context
    //     .Customers
    //     .Find(customerId);

    //    if (customerForUpdate != null)
    //    {
    //        customerForUpdate.Address = newAddress;
    //        _context.SaveChanges();
    //    }
    //    return customerForUpdate;
    //}
}
