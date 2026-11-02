using BookStore.API.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Features.Books.GetBook;

public static class GetBookEndpoint
{
    public const string Name = "GetBook";

    public static void MapGetBook(this IEndpointRouteBuilder app)
    {
        // GET /api/books/{id}
        app.MapGet("/{id:guid}", async Task<Results<Ok<BookDetailsDto>, NotFound>> (
            Guid id,
            GetBookHandler handler,
            CancellationToken cancellationToken) =>
        {
            Result<BookDetailsDto> result = await handler.HandleAsync(id, cancellationToken);

            return result.IsSuccess
                ? TypedResults.Ok(result.Value)
                : TypedResults.NotFound();
        })
        .WithName(Name);
    }
}