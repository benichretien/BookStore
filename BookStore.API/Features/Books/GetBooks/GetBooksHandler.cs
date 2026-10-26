using BookStore.API.Data;

namespace BookStore.API.Features.Books.GetBooks
{
    public class GetBooksHandler(BookStoreData data)
    {
        public List<BookSummaryDto> Handle()
        {
            return data.GetBooks()
                .Select(book => new BookSummaryDto(
                    book.Id,
                    book.Title,
                    book.Author,
                    book.Genre.Name,
                    book.Price,
                    book.PublishedDate))
                .ToList();
        }
    }
}
