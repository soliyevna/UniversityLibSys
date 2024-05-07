using Microsoft.EntityFrameworkCore;
using UniversityLibrarySystem.DataAccess.DbContexts;
using UniversityLibrarySystem.DataAccess.Interfaces;
using UniversityLibrarySystem.DataAccess.Interfaces.Common;
using UniversityLibrarySystem.DataAccess.Repositories.Common;
using UniversityLibrarySystem.Domain.Entites;

namespace UniversityLibrarySystem.DataAccess.Repositories;

public class PublisherRepository: BaseRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(DataContext dataContext): base(dataContext)
    {
    }

    public async Task<(bool, int)> DoesExist(string publisherName)
    {
        var publisher = await Collection.Where(p => p.Name.ToLower() == publisherName.ToLower()).FirstOrDefaultAsync();
        if(publisher == null)
            return (false, 0);
        else return (true, publisher.Id);
    }

    public async Task<List<Publisher>> GetAllAsync()
    {
        var res = await Collection.AsNoTracking().ToListAsync();
        return res;
    }
}
