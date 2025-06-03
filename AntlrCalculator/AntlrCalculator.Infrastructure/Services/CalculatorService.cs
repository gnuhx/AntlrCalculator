using AntlrCalculator.WinForms;

namespace AntlrCalculator.Infrastructure.Services
{
    public interface ICalculatorService
    {
        double Calculate(string expression);
        string GetVersion();
    }

    public class CalculatorService : ICalculatorService
    {
        public double Calculate(string expression)
        {
            return CalculatorHelper.Calculate(expression);
        }

        public string GetVersion()
        {
            return CalculatorHelper.GetVersion();
        }
    }
} 