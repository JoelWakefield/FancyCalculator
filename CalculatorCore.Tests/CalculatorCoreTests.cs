using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorCore;

namespace CalculatorCore.Tests
{
    [TestClass]
    public class CalculatorCoreTests
    {
        [TestMethod]
        public void AddTwoNumbers()
        {
            var calc = new Calculator();

            var result = calc.Eval("6 + 8").Result();
            string expected = "6 + 8 = 14";

            Assert.AreEqual(expected, result);
        }
    }
}
