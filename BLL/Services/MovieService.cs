using AutoMapper;
using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

internal class MovieService : CommonService<MovieModel, Movie>, IMovieService
{
    public MovieService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<Movie?> GetEntityAsync(Guid movieId) => await _unitOfWork.MovieRepository.GetAsync(movieId);
}
