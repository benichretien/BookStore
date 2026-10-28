using BookStore.API.Features.Books.CreateBook;
using BookStore.API.Features.Books.DeleteBook;
using BookStore.API.Features.Books.GetBook;
using BookStore.API.Features.Books.GetBooks;
using BookStore.API.Features.Books.UpdateBook;

namespace BookStore.API.Features.Books
{
    public static class BooksServices
    {
        public static IServiceCollection AddBooks(this IServiceCollection services)
        {
            services.AddScoped<GetBooksHandler>();
            services.AddScoped<GetBookHandler>();
            services.AddScoped<CreateBookHandler>();
            services.AddScoped<UpdateBookHandler>();
            services.AddScoped<DeleteBookHandler>();

            return services;
        }
    }
}
