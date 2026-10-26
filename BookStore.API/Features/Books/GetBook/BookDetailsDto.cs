using BookStore.API.Models;

namespace BookStore.API.Features.Books.GetBook
{
    public record BookDetailsDto(
        Guid Id,
        string Title,
        string Author,
        Guid GenreId,
        decimal Price,
        DateOnly PublishedDate
    )
    {
        public static BookDetailsDto FromBook(Book book) => new(
        book.Id,
        book.Title,
        book.Author,
        book.GenreId,
        book.Price,
        book.PublishedDate);
    };
    
    
}
