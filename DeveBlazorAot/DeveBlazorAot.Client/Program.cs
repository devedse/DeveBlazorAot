using DeveBlazorAot.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace DeveBlazorAot.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Client uses HttpClient to call API
            builder.Services.AddHttpClient<ICounterService, CounterServiceApiClient>(client =>
                client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            await builder.Build().RunAsync();
        }
    }
}
