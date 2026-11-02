using BookStore.API.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Features.Books.UpdateBook;

public static class UpdateBookEndpoint
{
    public static void MapUpdateBook(this IEndpointRouteBuilder app)
    {
        // PUT /api/books/{id}
        app.MapPut("/{id:guid}", async Task<Results<NoContent, NotFound, ValidationProblem>> (
            Guid id,
            UpdateBookDto updatedBook,
            UpdateBookHandler handler,
            CancellationToken cancellationToken) =>
        {
            Result result = await handler.HandleAsync(id, updatedBook, cancellationToken);

            if (result.IsSuccess)
            {
                return TypedResults.NoContent();
            }

            if (result.Error.Type == ErrorType.NotFound)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.ValidationProblem(new Dictionary<string, string[]>
            {
                [result.Error.Code] = [result.Error.Description]
            });
        });
    }
}