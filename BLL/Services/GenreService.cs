using BLL.Abstractions.Interfaces;
using Core.Models.Enums;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class GenreService : IGenreService
{
    private readonly IUnitOfWork _unitOfWork;

    public GenreService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Genre GetByCode(GenreCode genreCode)
        => _unitOfWork.GenreRepository.GetByCodeAsync(genreCode);
}
