using AutoMapper;
using BLL.Automapper.ModelConverters;
using Core.Models;
using Core.Models.Enums;
using Entities;

namespace BLL.Automapper.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieModel>().ReverseMap();
        CreateMap<Director, DirectorModel>().ReverseMap();

        CreateMap<Guid, Comment>().ConvertUsing<GuidModelConverter<Comment>>();
        CreateMap<Guid, Movie>().ConvertUsing<GuidModelConverter<Movie>>();
        CreateMap<GenreCode, Genre>().ConvertUsing<GenreCodeModelConverter>();
        CreateMap<Genre, GenreCode>().ConvertUsing<GenreDtoModelConverter>();
        CreateMap<Director, string>().ConvertUsing<DirectorDtoModelConverter>();
        CreateMap<string, Director>().ConvertUsing<DirectorModelConverter>();

        CreateMap<CommentModel, Comment>()
            .ForMember(dm => dm.Movie, opt => opt.MapFrom(src => src.MovieId))
            .ForMember(dm => dm.ParentComment, opt => opt.MapFrom(src => src.ParentCommentId));
        CreateMap<Comment, CommentModel>()
            .ForMember(dm => dm.MovieId, opt => opt.MapFrom(src => src.Movie.Id))
            .ForMember(dm => dm.ParentCommentId, opt => opt.MapFrom(src => src.ParentComment!.Id));
    }
}
