using BookStore.API.Data;

namespace BookStore.API.Features.Books.GetBooks
{
    public static class GetBooksEndpoint
    {
        public static void MapGetBooks(this IEndpointRouteBuilder app)
        {
            // GET /books
            app.MapGet("", (GetBooksHandler handler) =>
            {
                List<BookSummaryDto> books = handler.Handle();

                return TypedResults.Ok(books);
            });
        }
    }
}
