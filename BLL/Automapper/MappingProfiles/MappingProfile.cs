using AutoMapper;
using BLL.Automapper.ModelConverters;
using Core.Models;
using Core.Models.Enums;
using Entities;

namespace BLL.Automapper.MappingProfiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Director, DirectorModel>().ReverseMap();
        CreateMap<CommentModel, Comment>().ReverseMap();
        
        CreateMap<GenreCode, Genre>().ConvertUsing<GenreCodeModelConverter>();
        CreateMap<Genre, GenreCode>().ConvertUsing<GenreEntityConverter>();
        CreateMap<Director, string>().ConvertUsing<DirectorFromEntityConverter>();
        CreateMap<string, Director>().ConvertUsing<DirectorToEntityConverter>();
    }
}
