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
        static void Run()
        {
            var question = "Give me an equation in the following format: number opperator number";
            
            do
            {
                //  Prompt user for input
                Console.WriteLine(question);
                var result = Console.ReadLine();

                //  Check for quitters, lol
                if (result == "exit")
                    break;

                //  Attempt calculation
                double answer;
                if (RunCalculation(result, out answer))
                    Console.WriteLine($"Result: {answer}");
                else
                    Reject(out answer);
            } while (true);
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Fancy Calculator (enter 'exit' to quit)\n");

            Run();
        }
    }
}
