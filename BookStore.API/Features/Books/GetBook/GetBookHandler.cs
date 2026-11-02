using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Features.Books.GetBook;

public class GetBookHandler(BookStoreContext dbContext)
{
    public async Task<Result<BookDetailsDto>> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        Book? book = await dbContext.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(book => book.Id == id, cancellationToken);

        if (book is null)
        {
            return BookErrors.NotFound;
        }

        return BookDetailsDto.FromBook(book);
    }
}
