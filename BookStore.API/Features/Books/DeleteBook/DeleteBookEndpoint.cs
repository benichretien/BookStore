using BookStore.API.Data;

namespace BookStore.API.Features.Books.DeleteBook
{
    public static class DeleteBookEndpoint
    {
        public static void MapDeleteBook(this IEndpointRouteBuilder app, BookStoreData data)
        {
            // DELETE /books/{id}
            app.MapDelete("/{id:guid}", (Guid id, DeleteBookHandler handler) =>
            {
                handler.Handle(id);

                return TypedResults.NoContent();
            });
        }
    }
}
