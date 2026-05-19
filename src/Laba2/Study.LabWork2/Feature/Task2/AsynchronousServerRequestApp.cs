using Study.LabWork2.Abstractions.Feature.Task2;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;
using System.Diagnostics;

namespace Study.LabWork2.Feature.Task2;

public sealed class AsynchronousServerRequestApp : IServerRequestApp
{
    private readonly IRequestService _requestService;

    public AsynchronousServerRequestApp(IRequestService requestService) => _requestService = requestService;

    public ExecutionResultDto<TResponse> ExecuteRequests<TResponse>(ServerConfigDto[] servers)
    {
        return ExecuteRequestsAsync<TResponse>(servers).GetAwaiter().GetResult();
    }

    private async Task<ExecutionResultDto<TResponse>> ExecuteRequestsAsync<TResponse>(ServerConfigDto[] servers)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var tasks = servers.Select(s => _requestService.FetchDataAsync(s.Url)).ToArray();
            var results = await Task.WhenAll(tasks);
            var responses = results.Select(r => (TResponse)(object)r).ToList();

            foreach (var data in responses) Console.WriteLine(data);

            sw.Stop();
            return new ExecutionResultDto<TResponse>
            {
                Responses = responses,
                TotalExecutionTime = sw.Elapsed,
                SuccessfulRequest = true
            };
        }
        catch (Exception ex)
        {
            sw.Stop();
            Console.WriteLine($"Ошибка: {ex.Message}");
            return new ExecutionResultDto<TResponse>
            {
                TotalExecutionTime = sw.Elapsed,
                FailedRequest = true
            };
        }
    }

    public string GetVersion() => "Асинхронная версия";
}