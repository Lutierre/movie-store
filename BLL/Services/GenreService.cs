using BLL.Abstractions.Interfaces;
using Core.Models.Enums;
using DAL;
using Entities;

namespace BLL.Services;

public class GenreService : IGenreService
{
    private readonly UnitOfWork _unitOfWork;

    public GenreService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Genre?> GetByCodeAsync(GenreCode genreCode)
        => await _unitOfWork.GenreRepository.GetByCodeAsync(genreCode);
}
