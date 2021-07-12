using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {

        [TestMethod]
        public void IncorrectInput()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("r").Result();
            string expected = "There must be one opperator and one or two numbers, " +
                "\n\teither as a new opperation { 5 + 2 }," +
                "\n\tor appending an existing value { + 2 }";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void InvalidOperator()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("3 d 4").Result();
            string expected = "Please, enter a valid opperator; ie, one listed here [ + , - , * , / , % ].";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void NonNumericInput()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("re + 12").Result();
            string expected = "Numbers are invalid. Lets try that again...";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddTwoNumbers()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("6 + 8").Result();
            string expected = "6 + 8 = 14";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SubtractTwoNumbers()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("6 - 8").Result();
            string expected = "6 - 8 = -2";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("4 * 6").Result();
            string expected = "4 * 6 = 24";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DivideTwoNumbers()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("14 / 7").Result();
            string expected = "14 / 7 = 2";

            //  Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ModuloTwoNumbers()
        {
            //  Arrange
            var calc = new Calculator();

            //  Act
            var result = calc.Evaluate("13 % 5").Result();
            string expected = "13 % 5 = 3";

            //  Assert
            Assert.AreEqual(expected, result);
        }
    }
}
