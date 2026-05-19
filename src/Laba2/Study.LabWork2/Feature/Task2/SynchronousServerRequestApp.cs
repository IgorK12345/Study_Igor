using Study.LabWork2.Abstractions.Feature.Task2;
using Study.LabWork2.Abstractions.Feature.Task2.DtoModels;
using System.Diagnostics;

namespace Study.LabWork2.Feature.Task2;

public sealed class SynchronousServerRequestApp : IServerRequestApp
{
    private readonly IRequestService _requestService;

    public SynchronousServerRequestApp(IRequestService requestService) => _requestService = requestService;

    public ExecutionResultDto<TResponse> ExecuteRequests<TResponse>(ServerConfigDto[] servers)
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var responses = new List<TResponse>();
            foreach (var server in servers)
            {
                var data = _requestService.FetchData(server.Url);
                Console.WriteLine(data);
                responses.Add((TResponse)(object)data);
            }

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

    public string GetVersion() => "Синхронная версия";
}