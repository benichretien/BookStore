namespace BookStore.API.Models
{
    public class Book
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; } = null!;

        public string Author { get; private set; } = null!;
        public Guid GenreId { get; private set; }//Foreign key This is the value stored in the Books table.

        public Genre Genre { get; private set; } = null!;//the navigation property. It lets us write book.Genre.Name in C#. EF Core uses it to understand the relationship.

        public decimal Price { get; private set; }

        public DateOnly PublishedDate { get; private set; }

        private Book() { }

        public Book(string title, string author, Genre genre, decimal price, DateOnly publishedDate)
        {
            Id = Guid.NewGuid();
            Update(title, author, genre, price, publishedDate);
        }

        public void Update(string title, string author, Genre genre, decimal price, DateOnly publishedDate)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(author);
            ArgumentNullException.ThrowIfNull(genre);
            ArgumentOutOfRangeException.ThrowIfNegative(price);

            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
            PublishedDate = publishedDate;
        }
    }
}
