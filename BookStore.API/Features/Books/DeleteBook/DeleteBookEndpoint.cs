namespace BookStore.API.Features.Books.DeleteBook;

public static class DeleteBookEndpoint
{
    public static void MapDeleteBook(this IEndpointRouteBuilder app)
    {
        // DELETE /api/books/{id}
        app.MapDelete("/{id:guid}", async (Guid id, DeleteBookHandler handler, CancellationToken cancellationToken) =>
        {
            await handler.HandleAsync(id, cancellationToken);

            return TypedResults.NoContent();
        });
    }
}