using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fancy Calculator (enter 'exit' to quit)\n");

            Calculator calculator = new Calculator();
            calculator.Run();
        }
    }
}
