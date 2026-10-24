namespace BookStore.API.Dtos
{
    public record BookDetailsDto(
        Guid Id,
        string Title,
        string Author,
        Guid GenreId,
        decimal Price,
        DateOnly PublishedDate
    );
    
    
}
