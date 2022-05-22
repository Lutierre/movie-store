using AutoMapper;
using Core.Models;
using DAL;
using Entities;

namespace BLL.Services;

public class MovieService : CommonService<MovieModel, Movie>
{
    public MovieService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
}
