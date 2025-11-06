using NUnit.Framework.Legacy;
using Task3;

namespace Practical1Test
{
    internal class Task3_AgeClassification_Tests
    {
        [Test]
        [TestCase(-1, "Нереальний вік")]
        [TestCase(121, "Нереальний вік")]
        [TestCase(150, "Нереальний вік")]
        public void ClassifyAge_UnrealAge_ReturnsUnrealAge(int age, string expected)
        {
            string result = Program.ClassifyAge(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, "Ви дитина")]
        [TestCase(5, "Ви дитина")]
        [TestCase(11, "Ви дитина")]
        public void ClassifyAge_Child_ReturnsChild(int age, string expected)
        {
            string result = Program.ClassifyAge(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(12, "Підліток")]
        [TestCase(15, "Підліток")]
        [TestCase(17, "Підліток")]
        public void ClassifyAge_Teenager_ReturnsTeenager(int age, string expected)
        {
            string result = Program.ClassifyAge(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(18, "Дорослий")]
        [TestCase(30, "Дорослий")]
        [TestCase(59, "Дорослий")]
        public void ClassifyAge_Adult_ReturnsAdult(int age, string expected)
        {
            string result = Program.ClassifyAge(age);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(60, "Пенсіонер")]
        [TestCase(80, "Пенсіонер")]
        [TestCase(120, "Пенсіонер")]
        public void ClassifyAge_Senior_ReturnsSenior(int age, string expected)
        {
            string result = Program.ClassifyAge(age);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
