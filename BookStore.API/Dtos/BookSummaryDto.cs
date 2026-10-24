namespace BookStore.API.Dtos
{
    public record BookSummaryDto(
        Guid Id,
        string Title,
        string Author,
        string Genre,
        decimal Price,
        DateOnly PublishedDate
    );
    
    
}
