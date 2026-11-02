using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        await using AsyncServiceScope scope = app.Services.CreateAsyncScope();

        BookStoreContext dbContext = scope.ServiceProvider.GetRequiredService<BookStoreContext>();

        await dbContext.Database.MigrateAsync();
    }
}
