using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class TransactionRepository : ITransactionRepository
    {

        private readonly CasitaDbContext ctx;

        public TransactionRepository()
        {
            ctx = new CasitaDbContext();
        }
        public void Create(Transaction transaction)
        {
            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();
            
        }

        public void Delete(Guid id)
        {
            try
            {
                Transaction transactionFound = ctx.Transactions.FirstOrDefault(t => t.Id == id)!;

                if (transactionFound != null)
                {

                    ctx.Transactions.Remove(transactionFound);
                    ctx.SaveChanges();
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

                throw;
            }
         

        }
    }
}
