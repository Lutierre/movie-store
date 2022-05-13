using AutoMapper;
using Core.Models;
using DTO;

namespace BLL.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MovieDto, Movie>();
        CreateMap<Movie, MovieDto>();
        
        CreateMap<DirectorDto, Director>();
        CreateMap<Director, DirectorDto>();
        
        CreateMap<CommentDto, Comment>();
        CreateMap<Comment, CommentDto>();
    }
}
