using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                double firstNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());
                double secondNumber = inputConverter.ConvertInputToNumber(Console.ReadLine());
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, secondNumber, firstNumber);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                //In real world scenario, we would want to log this message.
                Console.WriteLine(ex.Message);
            }
        }
    }
}
