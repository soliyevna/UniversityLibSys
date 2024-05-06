using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Interfaces;

public interface IPublisherRepository: IBaseRepository<Publisher>
{
    public Task<(bool, int)> DoesExist(string publisherName);
    public Task<List<Publisher>> GetAllAsync();
}
