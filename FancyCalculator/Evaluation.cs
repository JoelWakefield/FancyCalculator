using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    class Evaluation
    {
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string Opperator { get; set; }
        public double Answer { get; set; }
        public bool IsHead { get; set; } = false;   //  Is this the first evaluation in a sequence
        public string ErrorMessage { get; set; }

        public string Result(int tab1 = 1, int tab2 = 1)
        {
            if (String.IsNullOrWhiteSpace(ErrorMessage))
                return $"{Format(Num1, tab1)}{Opperator} {Format(Num2,tab2,2)}= {Answer}";
            else
                return $"\u001b[31m{ErrorMessage}\u001b[0m";
        }

        private string Format(double num, int tabCount)
        {
            var tabSpaces = 8;
            var msg = IsHead ? num.ToString() : $"_{num.ToString()}_";

            for (int i = msg.ToString().Length; i < (tabCount * tabSpaces); i += tabSpaces)
                msg += "\t";

            return msg;
        }

        private string Format(double num, int tabCount, int extraSpace = 0)
        {
            var tabSpaces = 8;
            var msg = num.ToString();

            for (int i = msg.ToString().Length + extraSpace; i < (tabCount * tabSpaces); i += tabSpaces)
                msg += "\t";

            return msg;
        }
    }
}
