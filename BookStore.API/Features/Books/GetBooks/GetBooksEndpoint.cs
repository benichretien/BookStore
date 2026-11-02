namespace BookStore.API.Features.Books.GetBooks;

public static class GetBooksEndpoint
{
    public static void MapGetBooks(this IEndpointRouteBuilder app)
    {
        // GET /api/books
        app.MapGet("", async (GetBooksHandler handler, CancellationToken cancellationToken) =>
        {
            List<BookSummaryDto> books = await handler.HandleAsync(cancellationToken);

            return TypedResults.Ok(books);
        });
    }
}