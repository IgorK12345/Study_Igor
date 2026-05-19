using System.Net.Http;
using Study.LabWork2.Abstractions.Feature.Task2;

namespace Study.LabWork2.Feature.Task2;
/// <summary>
/// Интерфейс для реализации методов опроса другого сервиса
/// </summary>
public sealed class RequestService : IRequestService
{
    private readonly HttpClient _httpClient;

    public RequestService(HttpClient httpClient) => _httpClient = httpClient;

    public string FetchData(string url)
    {
        var response = _httpClient.GetAsync(url).Result;
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Статус {response.StatusCode}");
        return response.Content.ReadAsStringAsync().Result;
    }

    public async Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        if (!response.IsSuccessStatusCode)
            throw new Exception($"Статус {response.StatusCode} на {url}");
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}