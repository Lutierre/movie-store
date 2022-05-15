using AutoMapper;
using BLL.Automapper.ModelConverters;
using Core.Models;
using Core.Models.Enums;
using DTO.Entities;

namespace BLL.Automapper.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieDto, Movie>().ReverseMap();
        CreateMap<DirectorDto, Director>().ReverseMap();

        CreateMap<Guid, CommentDto>().ConvertUsing<GuidModelConverter<CommentDto>>();
        CreateMap<Guid, MovieDto>().ConvertUsing<GuidModelConverter<MovieDto>>();
        CreateMap<GenreCode, GenreDto>().ConvertUsing<GenreCodeModelConverter>();
        CreateMap<GenreDto, GenreCode>().ConvertUsing<GenreDtoModelConverter>();
        CreateMap<DirectorDto, string>().ConvertUsing<DirectorDtoModelConverter>();
        CreateMap<string, DirectorDto>().ConvertUsing<DirectorModelConverter>();

        CreateMap<Comment, CommentDto>()
            .ForMember(dm => dm.Movie, opt => opt.MapFrom(src => src.MovieId))
            .ForMember(dm => dm.ParentComment, opt => opt.MapFrom(src => src.ParentCommentId));
        CreateMap<CommentDto, Comment>()
            .ForMember(dm => dm.MovieId, opt => opt.MapFrom(src => src.Movie.Id))
            .ForMember(dm => dm.ParentCommentId, opt => opt.MapFrom(src => src.ParentComment!.Id));
    }
}
