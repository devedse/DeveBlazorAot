using DeveBlazorAot.Client.Pages;
using DeveBlazorAot.Components;
using DeveBlazorAot.Data;
using Microsoft.EntityFrameworkCore;

namespace DeveBlazorAot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            // Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=counter.db"));

            // Server uses direct database access
            builder.Services.AddScoped<DeveBlazorAot.Client.Services.ICounterService, DeveBlazorAot.Services.CounterServiceImpl>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // API endpoints for counter
            app.MapGet("/api/counter", async (DeveBlazorAot.Client.Services.ICounterService counterService) =>
            {
                var count = await counterService.GetCountAsync();
                return Results.Ok(new { count });
            });

            app.MapPost("/api/counter/increment", async (DeveBlazorAot.Client.Services.ICounterService counterService) =>
            {
                var count = await counterService.IncrementAsync();
                return Results.Ok(new { count });
            });

            app.Run();
        }
    }
}
