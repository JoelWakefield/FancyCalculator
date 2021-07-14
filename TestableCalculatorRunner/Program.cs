using System;
using CalculatorCore;

namespace TestableCalculatorRunner
{
    class Program
    {
        public static void Run()
        {
            var calculator = new Calculator();

            var question = "Give me an equation in the following format: number opperator number";

            do
            {
                Console.WriteLine(question);
                var input = Console.ReadLine();

                var result = calculator.Evaluate(input);

                Console.WriteLine(result.Result());

            } while (true);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This is the testable runner.\n");
            Run();
        }
    }
}
