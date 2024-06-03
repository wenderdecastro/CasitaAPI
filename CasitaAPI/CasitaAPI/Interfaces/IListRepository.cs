using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListRepository
    {
        public void Create(AppList list);
        public void Update(AppList list);
        public void Delete(int id);
    }
}
