using AutoMapper;
using Core.Models;
using DAL;

namespace BLL.Automapper.ModelConverters;

internal class StringDirectorModelConverter : ITypeConverter<string, DirectorModel>
{
    private readonly UnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StringDirectorModelConverter(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public DirectorModel Convert(string source, DirectorModel destination, ResolutionContext context) 
        => _mapper.Map<DirectorModel>(_unitOfWork.DirectorRepository.GetFilteredAsync(dto => dto.FullName == source).Result);
}
