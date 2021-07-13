using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        Calculator calc;

        [TestInitialize]
        public void TestInitialize()
        {
            //  Arrange
            calc = new Calculator();
        }

        [TestMethod]
        public void IncorrectInput()
        {
            //  Act
            var input = "r";
            var result = calc.Evaluate(input).Result();
            string expected = "There must be one opperator and one or two numbers, " +
                    "\n\teither as a new opperation { 5 + 2 }," +
                    "\n\tor appending an existing value { + 2 }";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InvalidOperator()
        {
            //  Act
            var op = "plus";
            var result = calc.Evaluate($"3 {op} 4").Result();
            string expected = $"{op} is an invalid operator. Please, only use the following: [ + , - , * , / , % ].";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NonNumericInput()
        {
            //  Act
            var result = calc.Evaluate("re + 12").Result();
            string expected = $"re must be a numeric value.";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddTwoNumbers()
        {
            //  Act
            var result = calc.Evaluate("6 + 8").Result();
            string expected = "6 + 8 = 14";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            //  Act
            var result = calc.Evaluate("6 - 8").Result();
            string expected = "6 - 8 = -2";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            //  Act
            var result = calc.Evaluate("4 * 6").Result();
            string expected = "4 * 6 = 24";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DivideTwoNumbers()
        {
            //  Act
            var result = calc.Evaluate("14 / 7").Result();
            string expected = "14 / 7 = 2";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModuloTwoNumbers()
        {
            //  Act
            var result = calc.Evaluate("13 % 5").Result();
            string expected = "13 % 5 = 3";

            //  Assert
            Assert.AreEqual(expected, result);
        }
    }
}
