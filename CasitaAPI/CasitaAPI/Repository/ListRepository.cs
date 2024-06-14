using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Repository
{
    public class ListRepository : IListRepository
    {
        private readonly CasitaDbContext ctx;

        public ListRepository()
        {
            ctx = new CasitaDbContext();
        }

        public void Create(AppList list)
        {
            try
            {
                var newList = new AppList
                {
                    Name = list.Name,
                    Description = list.Description,
                    AppTasks = list.AppTasks,
                    CreatedAt = DateTime.Now,
                    UserId = list.UserId,
                    
                };

                ctx.Add(newList);
                ctx.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);


            }

        }

        public void Delete(int id)
        {
            try
            {
                var list = ctx.AppLists.Find(id);
                ctx.AppLists.Remove(list);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }

        }

        

        public List<AppList> GetAllLists(Guid userId)
        {
            return ctx.AppLists.Where(x => x.UserId == userId).ToList();
        }

        public List<AppList> GetCustomLists(Guid userId)
        {
            return ctx.AppLists.Where(x => x.UserId == userId && x.ListTypeId == 6).ToList();
        }

        public List<AppList> GetDefaultLists(Guid userId)
        {
            return ctx.AppLists.Where(x => x.UserId == userId && x.ListTypeId == 7 && x.ListTypeId == 4).ToList();

        }

        public TransactionList getCart(Guid userId)
        {
            return ctx.TransactionLists.FirstOrDefault(x => x.ListTypeId == 4 && x.FinantialId == userId);

        }

        public List<AppList> GetListOfLists(Guid userId)
        {

            var list = new List<AppList>();

            var goals = ctx.AppLists.FirstOrDefault(x => x.ListTypeId == 7 && x.UserId == userId);
            var customLists = ctx.AppLists.Where(x => x.ListTypeId == 6).ToArray();

            list.Add(goals);
            list.AddRange(customLists);
            return list;

        }

        public object[] GetHomeLists(Guid userId)
        {
            var date = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
            var today = DateOnly.FromDateTime(DateTime.Now);
            var nextweek = DateOnly.FromDateTime(DateTime.Now);
            var NextTasks = ctx.AppTasks.Where(x => x.List.UserId == userId).ToList();

            var nextList = new AppList
            {
                Name = "Próximas",
                AppTasks = NextTasks,
            };

            var weeklyTasks = ctx.AppTasks.Where(x => x.List.UserId == userId && x.FrequencyId == 3 && x.DueDate.Value >= today).ToList();

            var weeklyList = new AppList
            {
                Name = "Semanais",
                AppTasks = weeklyTasks,
            };


            var montlyTasks = ctx.AppTasks.Where(x => x.List.UserId == userId && x.FrequencyId == 4 && x.DueDate.Value >= today).ToList();

            var montlyList = new AppList
            {
                Name = "Mensais",
                AppTasks = montlyTasks,
            };


            var cartCount = 0;
            var cart = ctx.TransactionLists.FirstOrDefault(x => x.ListTypeId == 4 && x.FinantialId == userId);

            if (cart != null)
            {
                cartCount = cart.ListItems.Count();
            };

            var shoppingList = new 
            {
                Name = "Lista de Compras",
                ItemsCount = cartCount
            };

            var goalsCount = 0;
            var goals = ctx.AppLists.FirstOrDefault(x => x.ListTypeId == 7 && x.UserId == userId);

            if (goals != null)
            {
                goalsCount = goals.AppTasks.Count();
            };

            var objectivesList = new
            {
                Name = "Objetivos",
                ItemsCount = goalsCount
            };

            object[] list = [shoppingList, objectivesList ,nextList, weeklyList, montlyList];

            return list;
        }


        public void Update(AppList list)
        {
            try
            {
                var existingList = ctx.AppLists.FirstOrDefault(x => x.Id == list.Id);


                if (existingList == null)
                {
                    Console.WriteLine("Not Found");
                    return;
                }

                existingList.Id = list.Id;
                existingList.Name = list.Name;
                existingList.Description = list.Description;
                existingList.AppTasks = list.AppTasks;
                existingList.CreatedAt = DateTime.Now;
                existingList.UserId = list.UserId;


                ctx.Update(existingList);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
        }
    }
}
