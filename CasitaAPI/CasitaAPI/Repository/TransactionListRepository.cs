using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CasitaAPI.Repository
{
    public class TransactionListRepository : ITransactionListRepository
    {

        private readonly CasitaDbContext ctx;

        public TransactionListRepository()
        {
            ctx = new CasitaDbContext();
        }
        public void Create(TransactionList tList)
        {
            ctx.Add(tList);
            ctx.SaveChanges();
        }

        public string Delete(int id)
        {
            TransactionList tlFound = ctx.TransactionLists.FirstOrDefault(tl => tl.Id == id)!;

            if (tlFound != null)
            {

                ctx.Remove(tlFound);
                ctx.SaveChanges();

                return "Item deletado com sucesso!";
            }
            else
            {
                return "Nenhum item encontrado!";
            }
        }

        public List<TransactionList> GetList(Guid id)
        {
            try
            {

                    return ctx.TransactionLists.Where(tl => tl.FinantialId == id).ToList();

            }
            catch (Exception e)
            {

                throw;
            }
          

        }

        public void Update(int id, TransactionList tList)
        {
          TransactionList tlFound = ctx.TransactionLists.FirstOrDefault(tl => tl.Id == id)!;

            if (tlFound != null)
            {

                tlFound.AmountSpent = tList.AmountSpent;
                tlFound.TotalAmount = tList.TotalAmount;
                tlFound.FinantialId = tList.FinantialId;
                tlFound.PhotoUrl = tList.PhotoUrl;
                tlFound.Priority = tList.Priority;
                tlFound.ListType = tList.ListType;
                ctx.Update(tlFound);
                ctx.SaveChanges();
            }
            else { return; }
        }

        public void UploadPhoto(int id, string photoUrl)
        {
            throw new NotImplementedException();
        }
        public List<TransactionList> GetLimits(Guid userID)
        {
            var finance = ctx.Financials.FirstOrDefault(x => x.Id == userID);

            var Necessities = ctx.Transactions.Where(x => x.TransactionTypeId == 1).ToList();
            var Wishes = ctx.Transactions.Where(x => x.TransactionTypeId == 2).ToList();
            var Savings = ctx.Transactions.Where(x => x.TransactionTypeId == 3).ToList();



            var Contas = new TransactionList
            {
                Name = "Contas",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Necessities.Sum(x => x.Value).Value,
                Transactions = Necessities
            };
            var Desejos = new TransactionList
            {
                Name = "Desejos",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Wishes.Sum(x => x.Value).Value,
                Transactions = Wishes
            };
            var Economias = new TransactionList
            {
                Name = "Economias",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Savings.Sum(x => x.Value).Value,
                Transactions = Savings
            };

            var list = new List<TransactionList>
            {
                Contas, Desejos, Economias
            };

            return list;

        }

    }
}
