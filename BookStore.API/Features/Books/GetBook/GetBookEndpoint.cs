using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Features.Books.GetBooks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Features.Books.GetBook
{
    public static class GetBookEndpoint
    {
        public const string Name = "GetBook";

        public static void MapGetBook(this IEndpointRouteBuilder app, BookStoreData data)
        {
            // GET /books/{id}
            app.MapGet("/{id:guid}", Results<Ok<BookDetailsDto>, NotFound> (Guid id) =>
            {
                GetBookHandler handler = new(data);

                Result<BookDetailsDto> result = handler.Handle(id);

                return result.IsSuccess
                    ? TypedResults.Ok(result.Value)
                    : TypedResults.NotFound();
            })
            .WithName(Name);
        }
    }
}
