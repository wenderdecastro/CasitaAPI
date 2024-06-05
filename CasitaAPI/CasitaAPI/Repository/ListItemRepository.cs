using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class ListItemRepository : IListItemRepository
    {

        public CasitaContext ctx = new CasitaContext();
        public void Conclude()
        {
            throw new NotImplementedException();
        }

        public void Create(ListItem item)
        {
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ListItem item)
        {
            throw new NotImplementedException();
        }
    }
}
