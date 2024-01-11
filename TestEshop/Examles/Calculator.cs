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
