using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IListRepository
    {
        public void Create(List list);
        public void Update(List list);
        public void Delete(int id);
    }
}
