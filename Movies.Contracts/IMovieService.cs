using Movies.Core.Dtos;

namespace Movies.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto?> GetByIdAsync(Guid id); // might need to change GetAsync ??
        Task<MovieDto> CreateAsync(MovieCreateDto dto);
        Task UpdateAsync(Guid id, MovieUpdateDto dto);
        Task DeleteAsync(Guid id);
    }

}
