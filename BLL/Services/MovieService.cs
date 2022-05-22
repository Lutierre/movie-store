using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Services;

internal class MovieService : CommonService<MovieModel, Movie>, IMovieService
{
    public MovieService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<Movie?> GetEntityAsync(Guid movieId) => await _unitOfWork.MovieRepository.GetAsync(movieId);
}
