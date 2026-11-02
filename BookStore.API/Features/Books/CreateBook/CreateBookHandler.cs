using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Features.Books.GetBook;
using BookStore.API.Models;

namespace BookStore.API.Features.Books.CreateBook;

public class CreateBookHandler(BookStoreContext dbContext)
{
    public async Task<Result<BookDetailsDto>> HandleAsync(CreateBookDto newBook, CancellationToken cancellationToken)
    {
        Genre? genre = await dbContext.Genres.FindAsync([newBook.GenreId], cancellationToken);

        if (genre is null)
        {
            return BookErrors.GenreNotFound;
        }

        Book book = new(newBook.Title, newBook.Author, genre, newBook.Price, newBook.PublishedDate);

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync(cancellationToken);

        return BookDetailsDto.FromBook(book);
    }
}
