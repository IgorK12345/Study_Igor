using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;
using System.Diagnostics;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private ProcessingResultDto _result;
    private const string FileName = "numbers_sets.txt";

    public ProcessingResultDto GetResult() => _result;

    public void Process()
    {
        if (!File.Exists(FileName))
            CreateSetsFile(FileName);

        var sets = File.ReadAllLines(FileName);
        var results = new List<string>();
        int total = 0;
        object locker = new object();
        var sem = new Semaphore(3, 3);
        var threads = new Thread[sets.Length];
        Stopwatch swatch = Stopwatch.StartNew();

        for (int i = 0; i < sets.Length; i++)
        {
            int idx = i;
            threads[idx] = new Thread(() =>
            {
                sem.WaitOne();
                int sum = sets[idx].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Sum();
                int tid = Thread.CurrentThread.ManagedThreadId;
                lock (locker)
                {
                    results.Add($"Набор {idx + 1}. Сумма {sum}. Номер потока {tid}");
                    total += sum;
                }
                sem.Release();
            });
            threads[idx].Start();
        }
        foreach (var th in threads) th.Join();
        swatch.Stop();

        _result = new ProcessingResultDto()
        {
            Results = results.OrderBy(x => x).ToList(),
            TotalSum = total,
            ExecutionTime = swatch.Elapsed,
        };
    }

    private static void CreateSetsFile(string fileName)
    {
        var rnd = new Random();
        File.WriteAllLines(fileName, Enumerable.Range(0, 15).Select(_ =>
            string.Join(" ", Enumerable.Range(0, 100).Select(__ => rnd.Next(1, 101)))));
    }
}