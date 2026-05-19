using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    /// <summary>
    /// Версия 3. Использует Semaphore для синхронизации
    /// </summary>
    public sealed class SemaphoreService : BasePrimeCounter
    {
        private readonly Semaphore _semaphore = new(1, 1);

        public override string GetVersionName() => "Semaphore";

        protected override void AddPrime(int number)
        {
            _semaphore.WaitOne();
            try
            {
                _totalPrimeCount++;
                _foundPrimes.Add(number);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
