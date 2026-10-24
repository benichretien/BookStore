namespace BookStore.API.Models
{
    public class Genre
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = null!;

        // Used by EF Core when loading genres from the database.
        private Genre() { }

        public Genre(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
