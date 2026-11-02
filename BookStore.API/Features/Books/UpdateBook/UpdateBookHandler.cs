using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Features.Books.UpdateBook;

public class UpdateBookHandler(BookStoreContext dbContext)
{
    public async Task<Result> HandleAsync(Guid id, UpdateBookDto updatedBook, CancellationToken cancellationToken)
    {
        Book? existingBook = await dbContext.Books.FindAsync([id], cancellationToken);

        if (existingBook is null)
        {
            return BookErrors.NotFound;
        }

        Genre? genre = await dbContext.Genres.FindAsync([updatedBook.GenreId], cancellationToken);

        if (genre is null)
        {
            return BookErrors.GenreNotFound;
        }

        existingBook.Update(
            updatedBook.Title,
            updatedBook.Author,
            genre,
            updatedBook.Price,
            updatedBook.PublishedDate);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}