using BookStore.API.Models;


namespace BookStore.API.Data;

// Temporary in-memory storage. Replaced by a DbContext in Section 7.
public class BookStoreData
{
    private readonly List<Genre> genres;
    private readonly List<Book> books;

    public BookStoreData()
    {
        genres =
        [
            new Genre("Programming"),
            new Genre("Fantasy"),
            new Genre("Self-Help"),
            new Genre("Science Fiction")
        ];

        books =
        [
            new Book("Clean Code", "Robert C. Martin", genres[0], 32.99m, new DateOnly(2008, 8, 1)),
            new Book("The Hobbit", "J.R.R. Tolkien", genres[1], 14.99m, new DateOnly(1937, 9, 21)),
            new Book("Atomic Habits", "James Clear", genres[2], 18.50m, new DateOnly(2018, 10, 16))
        ];
    }

    public IReadOnlyList<Book> GetBooks() => books.AsReadOnly();

    public Book? GetBook(Guid id) => books.Find(book => book.Id == id);

    public void AddBook(Book book) => books.Add(book);

    public void RemoveBook(Guid id) => books.RemoveAll(book => book.Id == id);

    public IReadOnlyList<Genre> GetGenres() => genres.AsReadOnly();

    public Genre? GetGenre(Guid id) => genres.Find(genre => genre.Id == id);
}