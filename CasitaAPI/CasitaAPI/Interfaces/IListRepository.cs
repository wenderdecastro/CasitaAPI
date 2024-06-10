using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListRepository
    {
        public void Create(AppList list);
        public List<AppList> GetDefaultLists(Guid userId);
        public List<AppList> GetCustomLists(Guid userId);
        public void Update(AppList list);
        public void Delete(Guid id);

        public List<AppList> GetAllLists (Guid userId);
    }
}
