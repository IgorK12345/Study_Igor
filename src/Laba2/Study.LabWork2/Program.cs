using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2
{
    public static class Program
    {
        private const int START = 1;
        private const int END = 10000;
        private const int THREAD_COUNT = 4;

        public static void Main()
        {
            
        

            RunVersion(new MonitorService());
            RunVersion(new MutexService());
            RunVersion(new SemaphoreService());

            Console.ReadKey();
        }

        private static void RunVersion(BasePrimeCounter counter)
        {
            Console.WriteLine(new string('=', 50));

            var result = counter.CountPrimes(START, END, THREAD_COUNT);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine(result.ToString());
            Console.WriteLine();
        }
    }
}
