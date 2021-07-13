using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class Calculator
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
        }

        bool RunCalculation(string input, ref double answer)
        {
            Evaluation ev = new Evaluation();

            //  Break apart the input
            var parts = input.Split(" ");

            //  Setup varaibles
            double num1;
            double num2;
            bool validInputs;

            //  Check to ensure the formatting is correct
            if (parts.Length == 3)
            {
                ev.Opperator = parts[1];

                validInputs = IsNumber(parts[0], out num1) & IsNumber(parts[2], out num2);

                //  Since this is starts a new calculation, reset history
                history.Clear();

                ev.IsHead = true;
            }
            else if (parts.Length == 2)
            {
                ev.Opperator = parts[0];
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
                switch (ev.Opperator)
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

                ev.Num1 = num1;
                ev.Num2 = num2;
                ev.Answer = answer;
            }
            else
            {
                return Reject("Numbers are invalid. Lets try that again...");
            }

            //  Append history
            history.Add(ev);

            return true;
        }

        void ShowHistory(string input)
        {
            //  Filter down requested operators
            List<Evaluation> filteredHistory;
            var inputParts = input.Split(" ");
            if (inputParts.Length > 1)
                filteredHistory = history.Where(e => e.Opperator == inputParts[1]).ToList();
            else
                filteredHistory = history;

            //  Get the longest string of commands
            var longestNum1 = 0;
            var longestNum2 = 0;

            filteredHistory.ForEach(e =>
            {
                if (e.Num1.ToString().Length > longestNum1)
                    longestNum1 = e.Num1.ToString().Length;

                if (e.Num2.ToString().Length > longestNum2)
                    longestNum2 = e.Num2.ToString().Length;
            });

            var tabSpaces = 8;
            var tab1 = (longestNum1 / tabSpaces) + 1;
            var tab2 = (longestNum2 / tabSpaces) + 1;

            //  Write formatted results
            filteredHistory.ForEach(e => Console.WriteLine(e.Result(tab1,tab2)));
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
                else if (result.Contains("history"))   //  Show history
                    ShowHistory(result);
                else if (RunCalculation(result, ref answer)) //  Attempt calculation
                    Console.WriteLine($"{result} = {answer}");
                else
                    Reject();

            } while (true);
        }
    }
}
