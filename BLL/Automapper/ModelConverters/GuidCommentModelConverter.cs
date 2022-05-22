using AutoMapper;
using BLL.Abstractions.Interfaces;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GuidCommentModelConverter : ITypeConverter<Guid, Comment>
{
    private readonly ICommentService _service;

    public GuidCommentModelConverter(ICommentService service)
    {
        _service = service;
    }

    // todo: to ask about .result
    public Comment Convert(Guid source, Comment destination, ResolutionContext context)
        => _service.GetEntityAsync(source).Result;
}
