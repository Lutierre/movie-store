using Core.Models.Enums;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface IGenreService
{
    Task<Genre?> GetByCodeAsync(GenreCode genreCode);
}
