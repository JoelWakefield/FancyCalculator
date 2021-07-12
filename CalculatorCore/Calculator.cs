using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private List<Evaluation> history = new List<Evaluation>();

        dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }

        bool Reject(string message = null)
        {
            if (!String.IsNullOrWhiteSpace(message))
                Console.WriteLine(message);
            //answer = 0;
            return false;
        }

        void AppendHistory(double num1, string opp, double num2, double ans)
        {
            history.Add(new Evaluation
            {
                Num1 = num1,
                Num2 = num2,
                Opperator = opp,
                Answer = ans
            });

            if (history.Count == 1)
                history.FirstOrDefault().IsHead = true;
        }

        public Evaluation Eval(string input)
        {
            double answer = 0;
            Evaluate(input, ref answer);
            return history.Last();
        }

        public bool Evaluate(string input, ref double answer)
        {
            //  Break apart the input
            var parts = input.Split(" ");

            //  Setup varaibles
            Evaluation calculation = new Evaluation();
            double num1 = 0;
            double num2 = 0;
            string opp;
            bool validInputs = false;

            //  Check to ensure the formatting is correct
            if (parts.Length == 3)
            {
                opp = parts[1];

                validInputs = IsNumber(parts[0], out num1) & IsNumber(parts[2], out num2);

                //  Since this is starts a new calculation, reset history
                history.Clear();
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

            //  Append history
            AppendHistory(num1, opp, num2, answer);

            return true;
        }

        void ShowHistory()
        {
            //  Get the longest string of commands
            history.ForEach(c => {
                Console.WriteLine(c.Result());
            });
        }

        public void Run()
        {
            var question = "Give me an equation in the following format: number opperator number";
            double answer = 0;

            do
            {
                //  Prompt user for input
                Console.WriteLine(question);
                var result = Console.ReadLine();


                if (result == "exit")   //  Check for quitters, lol
                    break;
                else if (result == "history")   //  Show history
                    ShowHistory();
                else if (Evaluate(result, ref answer)) //  Attempt calculation
                {
                    Console.WriteLine($"{result} = {answer}");
                }
                else
                    Reject();

            } while (true);
        }

    }
}
