using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Calculator
    {
        private double CurrentResult;

        public Evaluation Evaluate(string input, string lastResult = null)
        {
            //  If the input has the first part missing, then add the last result
            if (input.Split(" ").Length == 2 && lastResult != null)
                input = lastResult + ' ' + input;

            //Break apart the input
            var parts = input.Split(" ");

            //  Setup varaibles
            Evaluation ev = new Evaluation();
            double num1;
            double num2;

            //  Check to ensure the formatting is correct
            if (parts.Length == 3)
            {
                ev.Opperator = parts[1];

                //  Check if the inputs are valid
                if (!IsNumber(parts[0], out num1))
                    return new Evaluation { ErrorMessage = $"{parts[0]} must be a numeric value." };
                
                if (!IsNumber(parts[2], out num2))
                    return new Evaluation { ErrorMessage = $"{parts[2]} must be a numeric value." };
            }
            else
            {
                return new Evaluation
                {
                    ErrorMessage = "There must be one opperator and one or two numbers, " +
                        "\n\teither as a new opperation: [ 5 + 2 ]," +
                        "\n\tor appending an existing value: [ + 2 ]"
                };
            }

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

            //  Set the ongoing result
            CurrentResult = ev.Answer;

            return ev;
        }

        dynamic IsNumber(string str, out double answer)
        {
            return Double.TryParse(str, out answer);
        }
    }
}
