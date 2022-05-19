using Core.Models.Enums;
using Entities;

namespace DAL.Abstractions.Interfaces;

public interface IGenreRepository : IRepository<Genre>
{
    Task<Genre?> GetByCodeAsync(GenreCode code);
}
