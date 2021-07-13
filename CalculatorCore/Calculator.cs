using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {

        public Evaluation Evaluate(string input)
        {
            //Break apart the input
            var parts = input.Split(" ");

            //  Setup varaibles
            Evaluation ev = new Evaluation();
            double num1;
            double num2;
            bool validInputs;

            //  Check to ensure the formatting is correct
            if (parts.Length == 3)
            {
                ev.Opperator = parts[1];

                //  Check if the inputs are valid
                if (!IsNumber(parts[0], out num1))
                    return new Evaluation { ErrorMessage = $"{parts[0]} must be a numeric value." };
                
                if (!IsNumber(parts[2], out num2))
                    return new Evaluation { ErrorMessage = $"{parts[2]} must be a numeric value." };

                ev.Num1 = num1;
                ev.Num2 = num2;

                //  Check the opperator
                switch (ev.Opperator)
                {
                    case "+":
                        ev.Answer = num1 + num2;
                        break;
                    case "-":
                        ev.Answer = num1 - num2;
                        break;
                    case "*":
                        ev.Answer = num1 * num2;
                        break;
                    case "/":
                        ev.Answer = num1 / num2;
                        break;
                    case "%":
                        ev.Answer = num1 % num2;
                        break;
                    default:
                        return new Evaluation { ErrorMessage = $"{ev.Opperator} is an invalid operator. Please, only use the following: [ + , - , * , / , % ]." };
                }
            }
            else
            {
                return new Evaluation
                {
                    ErrorMessage = "There must be one opperator and one or two numbers, " +
                    "\n\teither as a new opperation { 5 + 2 }," +
                    "\n\tor appending an existing value { + 2 }"
                };
            }



            return ev;
        }

        dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }

        public void Run()
        {
            var question = "Give me an equation in the following format: number opperator number";

            do
            {
                Console.WriteLine(question);
                var input = Console.ReadLine();

                var result = Evaluate(input);

                Console.WriteLine(result.Result());

            } while (true);
        }
    }
}
