using BookStore.API.Common;
using BookStore.API.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Features.Books.UpdateBook
{
    public static class UpdateBookEndpoint
    {
        public static void MapUpdateBook(this IEndpointRouteBuilder app, BookStoreData data)
        {
            // PUT /books/{id}
            app.MapPut("/{id:guid}", Results<NoContent, NotFound, ValidationProblem> (Guid id, UpdateBookDto updatedBook, UpdateBookHandler handler) =>
            {
                 
                Result result = handler.Handle(id, updatedBook);

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
}
