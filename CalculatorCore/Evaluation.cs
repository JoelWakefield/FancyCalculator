using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorCore
{
    public class Evaluation
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Opperator { get; set; }
        public double Answer { get; set; }
        public bool IsHead { get; set; } = false;   //  Is this the first evaluation in a sequence
        public string ErrorMessage { get; set; }

        public string Result(bool colored = false) {
            string msg;

            if (String.IsNullOrWhiteSpace(ErrorMessage))
                msg = $"{Num1} {Opperator} {Num2} = {Answer}";
            else
                msg = ErrorMessage;

            if (colored)
                msg = $"\u001b[31m{msg}\u001b[0m";

            return msg;
        }

        private string Tabs(int count)
        {
            var msg = "";

            for (int i = 0; i < count; i++)
                msg += "\t";

            return msg;
        }
    }
}
