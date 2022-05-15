using AutoMapper;
using Core.Models;
using DAL;

namespace BLL.Automapper.ModelConverters;

public class StringDirectorModelConverter : ITypeConverter<string, Director>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StringDirectorModelConverter(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public Director Convert(string source, Director destination, ResolutionContext context) 
        => _mapper.Map<Director>(_unitOfWork.DirectorRepository.GetFilteredAsync(dto => dto.FullName == source).Result);
}
