using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListItemRepository
    {
        public void Create(ListItem item);
        public void Update(Guid id, ListItem item);
        public void Delete(Guid id);
        public string Conclude(Guid taskId);
    }
}
