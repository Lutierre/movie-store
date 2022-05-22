using AutoMapper;
using DAL;
using Entities;

namespace BLL.Automapper.ModelConverters;

internal class GuidModelConverter<T> : ITypeConverter<Guid, T> where T: BaseEntity
{
    private readonly UnitOfWork _unitOfWork;

    public GuidModelConverter(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public T Convert(Guid source, T destination, ResolutionContext context) 
        => _unitOfWork.GetRepository<T>().GetAsync(source).Result;
}
