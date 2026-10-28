using BookStore.API.Data;
using BookStore.API.Features.Genres.GetGenres;


namespace BookStore.API.Features.Genres;

public static class GenresEndpoints
{
    public static void MapGenres(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/genres")
            .WithTags("Genres");

        group.MapGetGenres();
    }
}
