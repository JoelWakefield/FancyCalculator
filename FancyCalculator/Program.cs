using System;

namespace FancyCalculator
{
    class Program
    {
        static dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }

        static bool Reject(string message = null)
        {
            if (!String.IsNullOrWhiteSpace(message))
                Console.WriteLine(message);
            //answer = 0;
            return false;
        }

        static bool RunCalculation(string input, ref double answer)
        {
            //  Break apart the input
            var parts = input.Split(" ");

            //  Setup varaibles
            double num1 = 0;
            double num2 = 0;
            string opp;
            bool validInputs = false;

            //  Check to ensure the formatting is correct
            if (parts.Length == 3)
            {
                opp = parts[1];

                validInputs = IsNumber(parts[0], out num1) & IsNumber(parts[2], out num2);
            }
            else if (parts.Length == 2)
            {
                opp = parts[0];
                num1 = answer;

                validInputs = IsNumber(parts[1], out num2);
            }
            else
            {
                return Reject("There must be one opperator and one or two numbers, " +
                    "\n\teither as a new opperation { 5 + 2 }," +
                    "\n\tor appending an existing value { + 2 }");
            }

            //  Check if the inputs are valid
            
            if (validInputs)
            {
                //  Check the opperator
                switch (opp)
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
                        return Reject("Please, enter a valid opperator; ie, one listed here [ + , - , * , / , % ].");
                }
            }
            else
            {
                return Reject("Numbers are invalid. Lets try that again...");
            }

            return true;
        }
        static void Run()
        {
            var question = "Give me an equation in the following format: number opperator number";
            double answer = 0;
            
            do
            {
                //  Prompt user for input
                Console.WriteLine(question);
                var result = Console.ReadLine();

                //  Check for quitters, lol
                if (result == "exit")
                    break;

                //  Attempt calculation
                if (RunCalculation(result, ref answer))
                    Console.WriteLine($"{result} = {answer}");
                else
                    Reject();
            } while (true);
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Fancy Calculator (enter 'exit' to quit)\n");

            Run();
        }
    }
}
