using System;

namespace FancyCalculator
{
    class Program
    {

        static dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }

        static bool RunCalculation(string input, out double answer)
        {
            var parts = input.Split(" ");

            //  Check if the inputs are valid
            var str1 = parts[0];
            var str2 = parts[2];
            double num1, num2;

            if (IsNumber(str1, out num1) & IsNumber(str2, out num2))
            {
                switch (parts[1])
                {
                    case "+":
                        answer = num1 + num2;
                        break;
                    case "-":
                        answer = num1 - num2;
                        break;
                    case "*":
                        answer = num1 * num2;
                        break;
                    case "/":
                        answer = num1 / num2;
                        break;
                    case "%":
                        answer = num1 % num2;
                        break;
                    default:
                        Console.WriteLine("Lets try that again...");
                        answer = 0;
                        return false;
                }
            }
            else
            {
                answer = 0;
                return false;
            }

            return true;
        }
        static dynamic QnA(string question)
        {
            do
            {
                Console.WriteLine(question);
                var result = Console.ReadLine();
                double answer;

                if (RunCalculation(result, out answer))
                    return answer;
                else
                    Console.WriteLine("Numbers are invalid. Lets try that again...");
            } while (true);
        }
        
        static void Main(string[] args)
        {
            var answer = QnA("Give me an equation (please, separate the parts with a space): ");

            Console.WriteLine($"Here's those numbers added together: {answer}");
            Console.ReadLine();
        }
    }
}
