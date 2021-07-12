using System;

namespace FancyCalculator
{
    class Program
    {
        static dynamic QnA(string question)
        {
            do
            {
                Console.WriteLine(question);
                var result = Console.ReadLine();
                double answer;

                if (Double.TryParse(result, out answer))
                    return answer;
                else
                    Console.WriteLine("Lets try that again...");
            } while (true);
            
        }

        static void Main(string[] args)
        {
            var num1 = QnA("Give me a number: ");
            var num2 = QnA("Give me a second number: ");

            Console.WriteLine($"Here's those numbers added together: {num1 + num2}");
            Console.ReadLine();
        }
    }
}
