using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    /// <summary>
    /// Версия 2. Использует Mutex для синхронизации
    /// </summary>
    public sealed class MutexService : BasePrimeCounter
    {
        private readonly Mutex _mutex = new();

        public override string GetVersionName() => "Mutex";

        protected override void AddPrime(int number)
        {
            _mutex.WaitOne();
            try
            {
                _totalPrimeCount++;
                _foundPrimes.Add(number);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}
