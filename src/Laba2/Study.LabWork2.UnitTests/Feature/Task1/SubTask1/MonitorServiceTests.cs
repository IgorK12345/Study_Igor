using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1
{
    [TestFixture]
    public sealed class MonitorServiceTests
    {
        [Test]
        public void Test1()
        {
            IPrimeCounter counter = new MonitorService();

            var result = counter.CountPrimes(1, 10, 2);

            Assert.That(result.PrimeCount, Is.EqualTo(4));
            Assert.That(result.SynchronizationType, Is.EqualTo("Monitor (lock)"));
        }

        [Test]
        public void Test2()
        {
            IPrimeCounter counter = new MonitorService();

            var result = counter.CountPrimes(1, 100, 4);

            Assert.That(result.PrimeCount, Is.EqualTo(25));
            Assert.That(result.ThreadCount, Is.EqualTo(4));
        }
    }
}
