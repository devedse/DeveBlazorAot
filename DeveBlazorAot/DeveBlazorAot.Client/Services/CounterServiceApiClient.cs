using System.Net.Http.Json;

namespace DeveBlazorAot.Client.Services;

public class CounterServiceApiClient : ICounterService
{
    private readonly HttpClient _httpClient;

    public CounterServiceApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetCountAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<CounterResponse>("/api/counter");
        return response?.Count ?? 0;
    }

    public async Task<int> IncrementAsync()
    {
        var response = await _httpClient.PostAsJsonAsync("/api/counter/increment", new { });
        var result = await response.Content.ReadFromJsonAsync<CounterResponse>();
        return result?.Count ?? 0;
    }

    private class CounterResponse
    {
        public int Count { get; set; }
    }
}
