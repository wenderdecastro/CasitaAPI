using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListItemRepository
    {
        public void Create(ListItem item);
        public void Update(int id, ListItem item);
        public void Delete(int id);
        public void Conclude(int taskId);
        //    public List<AppList> GetAllLists(Guid userId);
        //    public List<AppList> GetCustomLists(Guid userId);
        //    public List<AppList> GetDefaultLists(Guid userId);

        //    public List<AppList> GetDateLists(Guid userId, int option);
        //}
    }
}
