using BookStore.API.Features.Genres.GetGenres;

namespace BookStore.API.Features.Genres;

public static class GenresServices
{
    public static IServiceCollection AddGenres(this IServiceCollection services)
    {
        services.AddScoped<GetGenresHandler>();

        return services;
    }
}
