using System;

namespace FancyCalculator
{
    class Program
    {
        static dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }

        static bool Reject(out double answer, string message = null)
        {
            if (!String.IsNullOrWhiteSpace(message))
                Console.WriteLine(message);
            answer = 0;
            return false;
        }

        static bool RunCalculation(string input, out double answer)
        {
            var parts = input.Split(" ");

            //  Check to ensure enough pieces are present
            if (parts.Length != 3)
                return Reject(out answer, "Please, make sure there are 3 pieces to your input.");
 
            //  Check if the inputs are valid
            var str1 = parts[0];
            var str2 = parts[2];
            double num1, num2;

            if (IsNumber(str1, out num1) & IsNumber(str2, out num2))
            {
                //  Check the opperator
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
                        return Reject(out answer, "Please, enter a valid opperator; ie, one listed here [ + , - , * , / , % ].");
                }
            }
            else
            {
                return Reject(out answer, "Numbers are invalid. Lets try that again...");
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
                    Reject(out answer);
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
