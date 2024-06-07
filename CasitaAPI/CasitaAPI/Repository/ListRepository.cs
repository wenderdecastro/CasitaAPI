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
            return ctx.AppLists.Where(x => x.UserId == userId && x.ListTypeId != 6).ToList();

        }

        public List<AppList> GetDateLists(Guid userId, int option)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var NextTasks = ctx.AppTasks.Where(x => x.List.UserId == userId && x.DueDate.Value > today).ToList();

            var nextList = new AppList
            {
                Name = "Diarias",
                AppTasks = NextTasks,
            };

            var weeklyTasks = ctx.AppTasks.Where(x => x.List.UserId == userId && x.FrequencyId == 3).ToList();

            var weeklyList = new AppList
            {
                Name = "Semanais",
                AppTasks = weeklyTasks,
            };


            var montlyTasks = ctx.AppTasks.Where(x => x.List.UserId == userId && x.FrequencyId == 4).ToList();

            var montlyList = new AppList
            {
                Name = "Mensais",
                AppTasks = montlyTasks,
            };

            List<AppList> list = new List<AppList> { nextList, weeklyList, montlyList };

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
