using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1
{
    /// <summary>
    /// Версия 1. Использует Monitor (lock) для синхронизации
    /// </summary>
    public sealed class MonitorService : BasePrimeCounter
    {
        public override string GetVersionName() => "Monitor (lock)";

        protected override void AddPrime(int number)
        {
            lock (_lockObject)
            {
                _totalPrimeCount++;
                _foundPrimes.Add(number);
            }
        }
    }
}
