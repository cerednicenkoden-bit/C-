namespace Practical1Test
{
    public class Task1_EvenNumber_Tests
    {

        [Test]
        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(0, true)]
        [TestCase(-2, true)]
        public void IsEven_EvenNumbers_ReturnsTrue(int number, bool expected)
        {
            bool result = Task1.Program.IsEven(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, false)]
        [TestCase(3, false)]
        [TestCase(-1, false)]
        [TestCase(-3, false)]
        public void IsEven_OddNumbers_ReturnsFalse(int number, bool expected)
        {
            bool result = Task1.Program.IsEven(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, "Двері відкриваються!")]
        [TestCase(4, "Двері відкриваються!")]
        [TestCase(0, "Двері відкриваються!")]
        public void GetMessage_EvenNumbers_ReturnsOpenMessage(int number, string expected)
        {
            string result = Task1.Program.GetMessage(number);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, "Двері зачинені...")]
        [TestCase(3, "Двері зачинені...")]
        [TestCase(-1, "Двері зачинені...")]
        public void GetMessage_OddNumbers_ReturnsClosedMessage(int number, string expected)
        {
            string result = Task1.Program.GetMessage(number);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
