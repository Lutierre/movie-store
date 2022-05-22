using Core.Models;
using Entities;

namespace BLL.Abstractions.Interfaces;

public interface IDirectorService : ICommonService<DirectorModel>
{
    public Director GetByFullName(string fullName);
}
