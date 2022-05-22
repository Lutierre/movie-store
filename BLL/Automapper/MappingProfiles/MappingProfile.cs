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
        CreateMap<Genre, GenreCode>().ConvertUsing<GenreEntityConverter>();
        CreateMap<Director, string>().ConvertUsing<DirectorFromEntityConverter>();
        CreateMap<string, Director>().ConvertUsing<DirectorToEntityConverter>();

        CreateMap<CommentModel, Comment>()
            .ForMember(comment => comment.Movie, 
                expression => expression.MapFrom(commentModel => commentModel.MovieId))
            .ForMember(comment => comment.ParentComment, 
                expression => expression.MapFrom(commentModel => commentModel.ParentCommentId));
        
        CreateMap<Comment, CommentModel>()
            .ForMember(commentModel => commentModel.MovieId, 
                expression => expression.MapFrom(comment => comment.Movie!.Id))
            .ForMember(commentModel => commentModel.ParentCommentId, 
                expression => expression.MapFrom(comment => comment.ParentComment!.Id));
    }
}
