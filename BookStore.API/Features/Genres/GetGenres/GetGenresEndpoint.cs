using BookStore.API.Data;

namespace BookStore.API.Features.Genres.GetGenres
{
    public static class GetGenresEndpoint
    {
        public static void MapGetGenres(this IEndpointRouteBuilder app)
        {
            // GET /genres
            app.MapGet("", (GetGenresHandler handler) =>
            {
                List<GenreDto> genres = handler.Handle();

                return TypedResults.Ok(genres);
            });
        }
    }
}
