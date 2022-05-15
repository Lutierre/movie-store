using Core.Models.Enums;
using DTO.Entities;

namespace DAL.Abstractions.Interfaces;

public interface IGenreRepository : IRepository<GenreDto>
{
    Task<GenreDto?> GetByCodeAsync(GenreCode code);
}
