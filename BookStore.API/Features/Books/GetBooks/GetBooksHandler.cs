using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Features.Books.GetBooks;

public class GetBooksHandler(BookStoreContext dbContext)
{
    public async Task<List<BookSummaryDto>> HandleAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Books
            .OrderBy(book => book.Title)
            .Select(book => new BookSummaryDto(
                book.Id,
                book.Title,
                book.Author,
                book.Genre.Name,
                book.Price,
                book.PublishedDate))
            .ToListAsync(cancellationToken);
    }
}