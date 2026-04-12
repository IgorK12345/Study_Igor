using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    /// <summary>
    /// Базовый класс с общей логикой для всех счетчиков
    /// </summary>
    public abstract class BasePrimeCounter : IPrimeCounter
    {
        protected int _totalPrimeCount;
        protected readonly List<int> _foundPrimes = new();
        protected readonly object _lockObject = new();

        public abstract string GetVersionName();

        public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
        {
            _totalPrimeCount = 0;
            _foundPrimes.Clear();

            var stopwatch = Stopwatch.StartNew();

            int totalNumbers = end - start + 1;
            int numbersPerThread = totalNumbers / threadCount;
            int remainder = totalNumbers % threadCount;

            var threads = new Thread[threadCount];
            int currentStart = start;

            for (int i = 0; i < threadCount; i++)
            {
                int threadStart = currentStart;
                int extra = (i < remainder) ? 1 : 0;
                int threadEnd = threadStart + numbersPerThread + extra - 1;
                int threadId = i + 1;

                threads[i] = new Thread(() => ProcessRange(threadId, threadStart, threadEnd));
                threads[i].Start();

                currentStart = threadEnd + 1;
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            stopwatch.Stop();

            return new PrimeCountResultDto
            {
                PrimeCount = _totalPrimeCount,
                ExecutionTime = stopwatch.Elapsed,
                ThreadCount = threadCount,
                SynchronizationType = GetVersionName(),
                FoundPrimes = new List<int>(_foundPrimes)
            };
        }

        private void ProcessRange(int threadId, int start, int end)
        {
            for (int number = start; number <= end; number++)
            {
                Console.WriteLine($"Поток #{threadId} проверяет число: {number}");

                if (IsPrime(number))
                {
                    Console.WriteLine($"Поток #{threadId} нашел простое число: {number}");
                    AddPrime(number);
                }
            }
        }

        protected bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        protected abstract void AddPrime(int number);
    }
}
