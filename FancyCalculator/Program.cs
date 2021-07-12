using System;

namespace FancyCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a number: ");
            var num1 = Console.ReadLine();

            Console.WriteLine("Give me a second number: ");
            var num2 = Console.ReadLine();

            Console.WriteLine($"Here's those numbers added together: {num1 + num2}");
            Console.ReadLine();
        }
    }
}
