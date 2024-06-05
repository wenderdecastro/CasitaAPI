using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Repository
{
    public class ListRepository : IListRepository
    {
        private readonly CasitaContext ctx;

        public ListRepository()
        {
            ctx = new CasitaContext();
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

        public List<AppList> GetCustomLists(int userId)
        {
            throw new NotImplementedException();
        }

        public List<AppList> GetDefaultLists(int userId)
        {
            throw new NotImplementedException();
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
