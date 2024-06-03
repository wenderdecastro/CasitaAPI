using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CasitaAPI.Interfaces
{
    public interface ITransactionList
    {
        public void Create(TransactionList tList);
        public void Update(TransactionList tList);
        public void GetList(int id);
        public void Delete(int id);
        public void UploadPhoto(int id, string photoUrl);


    }
}
