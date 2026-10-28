using BookStore.API.Data;
using BookStore.API.Features.Books.CreateBook;
using BookStore.API.Features.Books.DeleteBook;
using BookStore.API.Features.Books.GetBook;
using BookStore.API.Features.Books.GetBooks;
using BookStore.API.Features.Books.UpdateBook;


namespace BookStore.API.Features.Books;

public static class BooksEndpoints
{
    public static void MapBooks(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/books")
            .WithTags("Books");

        group.MapGetBooks();
        group.MapGetBook();
        group.MapCreateBook();
        group.MapUpdateBook();
        group.MapDeleteBook();
    }
}
