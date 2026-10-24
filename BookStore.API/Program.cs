using BookStore.API.Dtos;
using BookStore.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddValidation();

var app = builder.Build();
const string GetBookEndpointName = "GetBook";

// Temporary in-memory storage.
List<Genre> genres =
[
    new Genre("Programming"),
    new Genre("Fantasy"),
    new Genre("Self-Help"),
    new Genre("Science Fiction")
];

List<Book> books =
[
    new Book("Clean Code", "Robert C. Martin", genres[0], 32.99m, new DateOnly(2008, 8, 1)),
    new Book("The Hobbit", "J.R.R. Tolkien", genres[1], 14.99m, new DateOnly(1937, 9, 21)),
    new Book("Atomic Habits", "James Clear", genres[2], 18.50m, new DateOnly(2018, 10, 16))
];
// GET /books
app.MapGet("/books", () =>
{
    List<BookSummaryDto> bookDtos = books
        .Select(book => new BookSummaryDto(
            book.Id,
            book.Title,
            book.Author,
            book.Genre.Name,
            book.Price,
            book.PublishedDate))
        .ToList();

    return TypedResults.Ok(bookDtos);
});

// GET /books/{id}
app.MapGet("/books/{id:guid}", Results<Ok<BookDetailsDto>, NotFound> (Guid id) =>
{
    Book? book = books.Find(book => book.Id == id);

    if (book is null)
    {
        return TypedResults.NotFound();
    }

    BookDetailsDto bookDto = new(
        book.Id,
        book.Title,
        book.Author,
        book.GenreId,
        book.Price,
        book.PublishedDate);

    return TypedResults.Ok(bookDto);
})
.WithName(GetBookEndpointName);

// POST /books
app.MapPost("/books", Results<CreatedAtRoute<BookDetailsDto>, ValidationProblem> (CreateBookDto newBook) =>
{
    Genre? genre = genres.Find(genre => genre.Id == newBook.GenreId);

    if (genre is null)
    {
        return TypedResults.ValidationProblem(new Dictionary<string, string[]>
        {
            [nameof(newBook.GenreId)] = ["The selected genre does not exist."]
        });
    }

    Book book = new(newBook.Title, newBook.Author, genre, newBook.Price, newBook.PublishedDate);
    books.Add(book);

    BookDetailsDto bookDto = new(
        book.Id,
        book.Title,
        book.Author,
        book.GenreId,
        book.Price,
        book.PublishedDate);

    return TypedResults.CreatedAtRoute(bookDto, GetBookEndpointName, new { id = bookDto.Id });
});

// PUT /books/{id}
app.MapPut("/books/{id:guid}", Results<NoContent, NotFound, ValidationProblem> (Guid id, UpdateBookDto updatedBook) =>
{
    Book? existingBook = books.Find(book => book.Id == id);

    if (existingBook is null)
    {
        return TypedResults.NotFound();
    }

    Genre? genre = genres.Find(genre => genre.Id == updatedBook.GenreId);

    if (genre is null)
    {
        return TypedResults.ValidationProblem(new Dictionary<string, string[]>
        {
            [nameof(updatedBook.GenreId)] = ["The selected genre does not exist."]
        });
    }

    existingBook.Update(
        updatedBook.Title,
        updatedBook.Author,
        genre,
        updatedBook.Price,
        updatedBook.PublishedDate);

    return TypedResults.NoContent();
});

// DELETE /books/{id}
app.MapDelete("/books/{id:guid}", (Guid id) =>
{
    books.RemoveAll(book => book.Id == id);

    return TypedResults.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "BookStore API v1");
    });
}

app.UseHttpsRedirection();


app.Run();


