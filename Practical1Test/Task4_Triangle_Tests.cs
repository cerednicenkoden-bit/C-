using Task4;

namespace Practical1Test
{
    internal class Task4_Triangle_Tests
    {
        [Test]
        [TestCase(3, 4, 5, true)]
        [TestCase(1, 1, 1, true)]
        [TestCase(2, 2, 3, true)]
        public void IsValidTriangle_ValidTriangles_ReturnsTrue(double a, double b, double c, bool expected)
        {
            bool result = Program.IsValidTriangle(a, b, c);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 1, 3, false)]
        [TestCase(0, 4, 5, false)]
        [TestCase(-1, 4, 5, false)]
        [TestCase(1, 10, 2, false)]
        public void IsValidTriangle_InvalidTriangles_ReturnsFalse(double a, double b, double c, bool expected)
        {
            bool result = Program.IsValidTriangle(a, b, c);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetPerimeter_ValidTriangle_ReturnsCorrectPerimeter()
        {
            double result = Program.GetPerimeter(3, 4, 5);
            Assert.That(result, Is.EqualTo(12.0).Within(0.001));
        }

        [Test]
        public void GetPerimeter_InvalidTriangle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Program.GetPerimeter(1, 1, 3));
        }

        [Test]
        public void GetArea_ValidTriangle_ReturnsCorrectArea()
        {
            double result = Program.GetArea(3, 4, 5);
            Assert.That(result, Is.EqualTo(6.0).Within(0.001));
        }

        [Test]
        public void GetArea_InvalidTriangle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Program.GetArea(1, 1, 3));
        }

        [Test]
        [TestCase(1, 1, 1, "рівносторонній")]
        [TestCase(3, 4, 5, "прямокутний")]
        [TestCase(2, 2, 3, "рівнобедрений")]
        [TestCase(3, 4, 6, "довільний")]
        public void GetTriangleType_ValidTriangles_ReturnsCorrectType(double a, double b, double c, string expected)
        {
            string result = Program.GetTriangleType(a, b, c);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetTriangleType_InvalidTriangle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Program.GetTriangleType(1, 1, 3));
        }
    }
}
