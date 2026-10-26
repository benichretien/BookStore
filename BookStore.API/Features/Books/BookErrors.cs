using BookStore.API.Common;

namespace BookStore.API.Features.Books
{
    public static class BookErrors
    {
        public static readonly Error NotFound =
        Error.NotFound("Book.NotFound", "The book was not found.");

        public static readonly Error GenreNotFound =
            Error.Validation("GenreId", "The selected genre does not exist.");
    }
}
