using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEshop.Examles;

public interface ICalculationService
{
    int Add(int a, int b);
    int Subtract(int a, int b);
}

public class Calculator
{
    private readonly ICalculationService _calculationService;

    public Calculator(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }

    public int PerformComplexCalculation(int a, int b)
    {
        // Some complex calculation involving the external service
        int result = _calculationService.Add(a, b) * _calculationService.Subtract(a, b);

        return result;
    }
}
public class CalculatorItem
{
    private decimal _a;
    private decimal _b;
    public CalculatorItem(decimal a, decimal b)
    {
        _a = a;
        _b = b;
    }

    public decimal PerformComplexCalculation()
    {
        //// Some complex calculation involving the external service
        //if (_b == 0)
        //{
        //    throw new Exception();
        //}
        decimal result = _a / _b;

        return result;
    }
}


