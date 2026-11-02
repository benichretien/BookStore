using BookStore.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Features.Genres.GetGenres;

public class GetGenresHandler(BookStoreContext dbContext)
{
    public async Task<List<GenreDto>> HandleAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Genres
            .OrderBy(genre => genre.Name)
            .Select(genre => new GenreDto(genre.Id, genre.Name))
            .ToListAsync(cancellationToken);
    }
}
