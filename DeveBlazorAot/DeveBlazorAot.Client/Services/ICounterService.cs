namespace DeveBlazorAot.Client.Services;

public interface ICounterService
{
    Task<int> GetCountAsync();
    Task<int> IncrementAsync();
}
