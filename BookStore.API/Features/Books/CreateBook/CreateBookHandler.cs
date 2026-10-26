using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Features.Books.GetBook;
using BookStore.API.Models;

namespace BookStore.API.Features.Books.CreateBook
{
    public class CreateBookHandler(BookStoreData data)
    {
        public Result<BookDetailsDto> Handle(CreateBookDto newBook)
        {
            Genre? genre = data.GetGenre(newBook.GenreId);

            if (genre is null)
            {
                return BookErrors.GenreNotFound;
            }

            Book book = new(newBook.Title, newBook.Author, genre, newBook.Price, newBook.PublishedDate);
            data.AddBook(book);

            return BookDetailsDto.FromBook(book);
        }
    }
}
