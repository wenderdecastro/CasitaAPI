using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Newtonsoft.Json.Linq;

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

        public Transaction AddGoalFunds( int goalId, decimal amount)
        {
            var goal = ctx.TransactionLists.FirstOrDefault(x => x.Id == goalId);
            var transaction = new Transaction
            {
                Name = goal.Name,
                Value = amount,
                CreatedAt = DateTime.Now,
                TransactionTypeId = 2,
                ListId = goal.Id
            };

            goal.Transactions.Add(transaction);

            var spent = goal.Transactions.Sum(x => x.Value);

            goal.AmountSpent = spent.Value;

            ctx.Update(goal);
            ctx.SaveChanges();
            return transaction;
        }

        public void Delete(int id)
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

        public Transaction ApplyCartItems(Guid userId)
        {
            var cart = ctx.TransactionLists.FirstOrDefault(x => x.FinantialId == userId && x.ListTypeId == 4);
            var defaultList = ctx.TransactionLists.FirstOrDefault(x => x.FinantialId == userId && x.ListTypeId == 1);

            var items = cart.ListItems.Where(x => x.IsConcluded == true);
            var value = items.Sum(x => x.Value);

            foreach (var item in items)
            {
                ctx.ListItems.Remove(item);
            }
            var transaction = new Transaction
            {
                Name = "Lista de Compras",
                Value = value,
                CreatedAt = DateTime.Now,
                TransactionTypeId = 1,
                ListId = defaultList.Id
            };

            ctx.Transactions.Add(transaction);
            ctx.SaveChanges();

            return transaction;


        }
    }
}
