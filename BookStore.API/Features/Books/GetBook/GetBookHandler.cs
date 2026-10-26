using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Features.Books.GetBook
{
    public class GetBookHandler(BookStoreData data)
    {
        public Result<BookDetailsDto> Handle(Guid id)
        {
            Book? book = data.GetBook(id);

            if (book is null)
            {
                return BookErrors.NotFound;
            }

            return BookDetailsDto.FromBook(book);
        }
    }
}
