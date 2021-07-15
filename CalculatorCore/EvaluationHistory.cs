using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class EvaluationHistory
    {
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

        public List<Evaluation> Get(string filterOperand = null)
        {
            switch (filterOperand)
            {
                case "add":
                    filterOperand = "+";
                    break;
                case "sub":
                    filterOperand = "-";
                    break;
                case "mul":
                    filterOperand = "*";
                    break;
                case "div":
                    filterOperand = "/";
                    break;
                case "mod":
                    filterOperand = "%";
                    break;
                default:
                    return Evaluations;
            }

            return Evaluations.Where(e => e.Opperator == filterOperand).ToList();
        }
    }
}
