using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.ViewModels;
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
                var list = ctx.TransactionLists.Where(tl => tl.FinantialId == id && tl.ListTypeId == 3).ToList();
                foreach (var item in list)
                {
                    item.AmountSpent = (decimal)ctx.Transactions.Where(x => x.ListId == item.Id).Sum(x => x.Value);
                    ctx.Update(item);
                }
                ctx.SaveChanges();
                return list;

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

        public void UploadPhoto(int id, string novaUrlFoto)
        {

            try
            {
                TransactionList transactionFound = ctx.TransactionLists.FirstOrDefault(x => x.Id == id)!;

                if (transactionFound != null)
                {
                    transactionFound.PhotoUrl = novaUrlFoto;
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public object[] GetMonthlyTransactions(Guid userId)
        //{
        //    return List;
        //}

        public TransactionList GetTransaction(int id)
        {
            return ctx.TransactionLists.FirstOrDefault(x => x.Id == id)!;
        }

        
        public List<TListVM> GetLimits(Guid userID)
        {
            var finance = ctx.Financials.FirstOrDefault(x => x.Id == userID);

            var Necessities = ctx.Transactions.Where(x => x.TransactionTypeId == 1).ToList();

            var NecessitiesList = ctx.Transactions.Where(x => x.TransactionTypeId == 1).ToList().GroupBy(x=> x.CreatedAt.Value).Select(c=> new HistoryVM
            {
                Month = c.Key.Month,
                Year = c.Key.Year,
                Items = c.ToList()

            }).ToList();



            var Wishes = ctx.Transactions.Where(x => x.TransactionTypeId == 2).ToList();
            var WishesList = Wishes.GroupBy(x => x.CreatedAt.Value).Select(c => new HistoryVM
            {
                Month = c.Key.Month,
                Year = c.Key.Year,
                Items = c.ToList()

            }).ToList();

            var Savings = ctx.Transactions.Where(x => x.TransactionTypeId == 3).ToList();
            var SavingsList = Savings.ToList().GroupBy(x => x.CreatedAt.Value).Select(c => new HistoryVM
            {
                Month = c.Key.Month,
                Year = c.Key.Year,
                Items = c.ToList()

            }).ToList();



            var Contas = new TListVM
            {
                TransactionTypeId = 1,
                Name = "Contas",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Necessities.Sum(x => x.Value).Value,
                Transactions = NecessitiesList
            };
            var Desejos = new TListVM
            {
                TransactionTypeId = 2,
                Name = "Desejos",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Wishes.Sum(x => x.Value).Value,
                Transactions = WishesList
            };
            var Economias = new TListVM
            {
                TransactionTypeId = 3,
                Name = "Economias",
                FinantialId = userID,
                TotalAmount = finance.MonthlyIncome * finance.NecessitiesPercentage,
                AmountSpent = Savings.Sum(x => x.Value).Value,
                Transactions = SavingsList
            };

            var list = new List<TListVM>
            {
                Contas, Desejos, Economias
            };

            return list;

        }

        
    }
}
