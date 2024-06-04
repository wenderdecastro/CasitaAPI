using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListRepository
    {
        public void Create(AppList list);
        public List<AppList> GetDefaultLists(int userId);
        public List<AppList> GetCustomLists(int userId);
        public void Update(AppList list);
        public void Delete(int id);
    }
}
