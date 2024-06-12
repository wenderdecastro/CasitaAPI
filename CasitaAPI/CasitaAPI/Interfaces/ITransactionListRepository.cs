using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CasitaAPI.Interfaces
{
    public interface ITransactionListRepository
    {
        public void Create(TransactionList tList);
        public void Update(int id, TransactionList tList);
        public List<TransactionList> GetList(Guid id);
        public string Delete(int id);
        public void UploadPhoto(int id, string photoUrl);


        public TransactionList GetTransaction(int id);
        public List<TransactionList> GetLimits(Guid userId);



    }
}
