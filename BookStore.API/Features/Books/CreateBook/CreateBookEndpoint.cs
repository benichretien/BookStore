using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Features.Books.GetBook;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.API.Features.Books.CreateBook
{
    public static class CreateBookEndpoint
    {
        
        public static void MapCreateBook(this IEndpointRouteBuilder app)
        {
            // POST /books
            app.MapPost("", Results<CreatedAtRoute<BookDetailsDto>, ValidationProblem> (CreateBookDto newBook, CreateBookHandler handler) =>
            {

                Result<BookDetailsDto> result = handler.Handle(newBook);

                if (!result.IsSuccess)
                {
                    return TypedResults.ValidationProblem(new Dictionary<string, string[]>
                    {
                        [result.Error.Code] = [result.Error.Description]
                    });
                }

                return TypedResults.CreatedAtRoute(result.Value, GetBookEndpoint.Name, new {id = result.Value.Id});

            });
        }
    }
}
