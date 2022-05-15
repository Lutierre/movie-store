using AutoMapper;
using Core.Models.Enums;
using DTO.Entities;

namespace BLL.Automapper.ModelConverters;

internal class GenreDtoModelConverter : ITypeConverter<GenreDto, GenreCode>
{
    public GenreCode Convert(GenreDto source, GenreCode destination, ResolutionContext context) 
        => (GenreCode)source.Code;
}
