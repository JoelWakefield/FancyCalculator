﻿using System;
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

        public string Result() {
            var head = IsHead ? Num1.ToString() : "";
            return $"{head} {Opperator} {Num2} = {Answer}";
        }
    }
}