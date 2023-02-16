using NUnit.Framework;

namespace SnakeGame.Tests2
{
    [TestFixture]
    internal class CalculatorTests
    {
        Calculator calculator = new Calculator();

        [Test]
        public void AdditionalMustReturnValidValue()
        {
            Assert.That(calculator.Additional(5, 10) == 15);
        }
        [Test]
        public void MultiplicationMustReturnInvalidValue() 
        {
            Assert.That(calculator.Multiplication(5, 10) == 50);
        }
        [Test]
        public void SubtractionShouldReturnValidValue()
        {
            Assert.That(calculator.Subtraction(10, 5) == 5);
        }
        [Test]
        public void DivisionShouldReturnValidValue()
        {
            Assert.That(calculator.Division(10,5) == 2);
        }

    }
}
