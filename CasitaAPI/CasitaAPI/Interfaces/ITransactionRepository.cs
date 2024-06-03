using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface ITransactionRepository
    {
        public void Create(Transaction transaction);
        public void Delete(int id);
    }
}
