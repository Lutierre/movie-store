using AutoMapper;
using Core.Models;
using Entities;

namespace BLL.Automapper.MappingProfiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Director, DirectorModel>().ReverseMap();
        CreateMap<CommentModel, Comment>().ReverseMap();
    }
}
