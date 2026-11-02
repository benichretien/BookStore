namespace BookStore.API.Features.Genres.GetGenres;

public static class GetGenresEndpoint
{
    public static void MapGetGenres(this IEndpointRouteBuilder app)
    {
        // GET /api/genres
        app.MapGet("", async (GetGenresHandler handler, CancellationToken cancellationToken) =>
        {
            List<GenreDto> genres = await handler.HandleAsync(cancellationToken);

            return TypedResults.Ok(genres);
        });
    }
}
