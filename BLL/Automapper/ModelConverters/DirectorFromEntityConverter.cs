using AutoMapper;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class DirectorFromEntityConverter : ITypeConverter<Director, string>
{
    public string Convert(Director source, string destination, ResolutionContext context) => source.FullName;
}
