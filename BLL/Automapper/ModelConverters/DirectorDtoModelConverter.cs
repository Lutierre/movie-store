using AutoMapper;
using DTO.Entities;

namespace BLL.Automapper.ModelConverters;

public class DirectorDtoModelConverter : ITypeConverter<DirectorDto, string>
{
    public string Convert(DirectorDto source, string destination, ResolutionContext context) => source.FullName;
}
