using DeveBlazorAot.Client.Services;
using DeveBlazorAot.Data;
using Microsoft.EntityFrameworkCore;

namespace DeveBlazorAot.Services;

public class CounterServiceImpl : ICounterService
{
    private readonly ApplicationDbContext _db;

    public CounterServiceImpl(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<int> GetCountAsync()
    {
        return await _db.CounterClicks.CountAsync();
    }

    public async Task<int> IncrementAsync()
    {
        var click = new CounterClick
        {
            ClickedAt = DateTime.UtcNow
        };
        _db.CounterClicks.Add(click);
        await _db.SaveChangesAsync();

        return await _db.CounterClicks.CountAsync();
    }
}
