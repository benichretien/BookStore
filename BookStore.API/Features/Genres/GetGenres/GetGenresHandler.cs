using BookStore.API.Data;

namespace BookStore.API.Features.Genres.GetGenres
{
    public class GetGenresHandler(BookStoreData data)
    {
        public List<GenreDto> Handle()
        {
            return data.GetGenres()
                .Select(genre => new GenreDto(genre.Id, genre.Name))
                .ToList();
        }
    }
}
