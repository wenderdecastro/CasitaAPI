using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListItemRepository
    {
        public void Create(ListItem item);
        public void Update(ListItem item);
        public void Delete(int id);
        public void Conclude();
    }
}
