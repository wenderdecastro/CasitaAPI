using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CasitaAPI.Interfaces
{
    public interface ITransactionList
    {
        public void Create(TransactionList tList);
        public void Update(Guid id, TransactionList tList);
        public List<TransactionList> GetList(Guid id);
        public string Delete(Guid id);
        public void UploadPhoto(Guid id, string photoUrl);


    }
}
