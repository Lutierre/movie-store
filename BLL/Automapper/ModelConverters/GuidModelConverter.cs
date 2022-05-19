using AutoMapper;
using DAL.Abstractions.Interfaces;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GuidModelConverter<T> : ITypeConverter<Guid, T> where T: BaseEntity
{
    private readonly IRepository<T> _repository;

    public GuidModelConverter(IRepository<T> repository)
    {
        _repository = repository;
    }

    public T Convert(Guid source, T destination, ResolutionContext context) => _repository.GetAsync(source).Result;
}
