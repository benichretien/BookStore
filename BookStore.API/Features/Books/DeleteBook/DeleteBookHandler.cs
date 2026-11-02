using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Features.Books.DeleteBook;

public class DeleteBookHandler(BookStoreContext dbContext)
{
    public async Task HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        await dbContext.Books
            .Where(book => book.Id == id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}
