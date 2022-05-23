using Core.Models.Enums;
using Entities;

namespace DAL.Abstractions.Interfaces;

public interface IGenreRepository : IRepository<Genre>
{
    Genre? GetByCodeAsync(GenreCode code);
}
