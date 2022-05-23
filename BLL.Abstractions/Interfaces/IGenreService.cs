using Core.Models.Enums;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface IGenreService
{
    Genre? GetByCode(GenreCode genreCode);
}
