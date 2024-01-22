using Castle.Core.Logging;
using DomainProject.Data;
using DomainProject.Dto;
using DomainProject.Models;
using DomainProject.Services;
using Microsoft.Extensions.Logging;
using Moq;
using RockLib.Logging.LogProcessing;
using System;
using TestEshop.Examles;

namespace TestEshop;

public class UnitTestCustomerService
{

    [Fact]
    public void  Test1()
    {
        var expected = 1.10m;
        var calculated = 1.102m;
        Assert.Equal(expected, calculated,2);
    }

    [Fact]
    public void Test2()
    {
        var calculator = new CalculatorItem(1.001m, 0m);

        void calculated() => calculator.PerformComplexCalculation();
        Assert.Throws<DivideByZeroException>(calculated);
  
        var calculator2 = new CalculatorItem(1.001m, 2.0m);
        Assert.Equal(0.5m, calculator2.PerformComplexCalculation(), 2);
    }


    //[Fact]
    //public async Task TestAddCustomer()
    //{
    //    var customer = new Customer { };

    //    var customers = new List<Customer>
    //    {
    //        new() { Id = 1, Name = "D1" },
    //        new() { Id = 2, Name = "D2" }
    //    };

    //    Assert.NotNull(customer);

    //    var mockDbContext = new Mock<EshopDbContext>();
    //    var mockLogger = new Mock<ILogger<CustomerServices>>();

    //    mockDbContext.Setup(db => db.Customers.Find(It.IsAny<int>()))
    //            .Returns<Customer>(customer => customers.SingleOrDefault(
    //                searchCustomer => searchCustomer.Id == customer.Id));

    //    ICustomerServices services = new CustomerServices(
    //        mockDbContext.Object, mockLogger.Object);
    //    Act
    //   var result = await services.GetCustomersAsync();

    //    Assert
    //    Assert.NotNull(result);
    //    Assert.Equal(0, result.Status);
    //}

    [Theory]
    [InlineData(3, 2, 5)]  // (3 + 2) * (3 - 2) = 5
    [InlineData(0, 5, -25)]  // (0 + 5 )* (0 - 5) = -25
    [InlineData(10, 5, 75)]  // (10 + 5) * (10 - 5) = 75
    [InlineData(0, 0, 0)]  // (0 + 0) * (0 - 0) = 0
    [InlineData(-10, -50, -2400)]  // (-10 + -50) * (-10 - -50) = -2400
    public void PerformComplexCalculation_ShouldReturnExpectedResult
        (int a, int b, int expectedResult)
    {
        // Arrange
        var mockCalculationService = new Mock<ICalculationService>();

        mockCalculationService.Setup(service => service.Add(It.IsAny<int>(), It.IsAny<int>()))
                              .Returns<int, int>((x, y) => x + y);
        mockCalculationService.Setup(service => service.Subtract(It.IsAny<int>(), It.IsAny<int>()))
                              .Returns<int, int>((x, y) => x - y);

        var calculator = new Calculator(mockCalculationService.Object);

        // Act
        int result = calculator.PerformComplexCalculation(a, b);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}