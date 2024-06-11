using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListItemRepository
    {
        public void Create(ListItem item);
        public void Update(int id, ListItem item);
        public void Delete(int id);
        public string Conclude(int taskId);
    }
}
