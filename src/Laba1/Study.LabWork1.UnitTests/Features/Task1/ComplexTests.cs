using Study.LabWork1.Features.Task1;

namespace Study.LabWork1.UnitTests.Features.Task1
{
    [TestFixture]
    public class ComplexTests
    {
        [Test]
        public void Addition_ShouldReturnCorrectSum()
        {
            // Arrange
            var a = new Complex(3, 4);
            var b = new Complex(1, -2);

            // Act
            var result = a + b;

            // Assert
            Assert.That(result.Real, Is.EqualTo(4));
            Assert.That(result.Imagine, Is.EqualTo(2));
        }

        [Test]
        public void Subtraction_ShouldReturnCorrectDifference()
        {
            var a = new Complex(5, 7);
            var b = new Complex(2, 3);

            var result = a - b;

            Assert.That(result.Real, Is.EqualTo(3));
            Assert.That(result.Imagine, Is.EqualTo(4));
        }

        [Test]
        public void Multiplication_ShouldReturnCorrectProduct()
        {
            var a = new Complex(3, 2);
            var b = new Complex(1, 4);

            var result = a * b;

            Assert.That(result.Real, Is.EqualTo(-5));
            Assert.That(result.Imagine, Is.EqualTo(14));
        }

        [Test]
        public void Division_ShouldReturnCorrectQuotient()
        {
            var a = new Complex(3, 2);
            var b = new Complex(4, -3);

            var result = a / b;

            Assert.That(result.Real, Is.EqualTo(0.24).Within(1e-10));
            Assert.That(result.Imagine, Is.EqualTo(0.68).Within(1e-10));
        }

        [Test]
        public void UnaryPlus_ShouldReturnModulus()
        {
            var c = new Complex(3, 4);

            var modulus = +c;

            Assert.That(modulus, Is.EqualTo(5).Within(1e-10));
        }

        [Test]
        public void UnaryMinus_ShouldReturnConjugate()
        {
            var c = new Complex(3, 4);

            var conjugate = -c;

            Assert.That(conjugate.Real, Is.EqualTo(3));
            Assert.That(conjugate.Imagine, Is.EqualTo(-4));
        }

        [TestCase(3, 4, 3, 4, true)]
        [TestCase(3, 4, 3, 5, false)]
        [TestCase(1, -2, 1, -2, true)]
        public void Equality_ShouldCompareCorrectly(double r1, double i1, double r2, double i2, bool expected)
        {
            var a = new Complex(r1, i1);
            var b = new Complex(r2, i2);

            Assert.That(a == b, Is.EqualTo(expected));
        }

        [TestCase(1.01, 2, "1.01 + 2.00i")]
        [TestCase(3, 0, "3.00")]
        [TestCase(0, 4, "4.00i")]
        [TestCase(0, 0, "0")]
        [TestCase(2.5, -3.5, "2.50 - 3.50i")]
        public void ToString_ShouldFormatCorrectly(double real, double imagine, string expected)
        {
            var c = new Complex(real, imagine);

            var result = c.ToString();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
