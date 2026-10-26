using BookStore.API.Common;
using BookStore.API.Data;
using BookStore.API.Models;

namespace BookStore.API.Features.Books.UpdateBook
{
    public class UpdateBookHandler(BookStoreData data)
    {
        public Result Handle(Guid id, UpdateBookDto updatedBook)
        {
            Book? existingBook = data.GetBook(id);

            if (existingBook is null)
            {
                return BookErrors.NotFound;
            }

            Genre? genre = data.GetGenre(updatedBook.GenreId);

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

            return Result.Success();
        }
    }
}
