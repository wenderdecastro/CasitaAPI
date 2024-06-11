using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class ListItemRepository : IListItemRepository
    {

        private readonly CasitaDbContext ctx;

        public ListItemRepository()
        {
            ctx = new CasitaDbContext();
        }
        public void Conclude(int id)
        {
            var item = ctx.ListItems.Find(id);
            
            item.IsConcluded = !item.IsConcluded;
            ctx.ListItems.Update(item);
            ctx.SaveChanges();
        }

        public void Create(ListItem item)
        {
            try
            {

                var ListItem = new ListItem
                {
                    Name = item.Name,
                    CreatedAt = DateTime.Now,
                    IsConcluded = false,
                    ListId = item.ListId,
                    Priority = item.Priority,
                    Value = item.Value,
                };

                ctx.ListItems.Add(ListItem);
                ctx.SaveChanges();

              
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }

        
            
        }

        public void Delete(int id)
        {
           ListItem foundItem = ctx.ListItems.FirstOrDefault(l => l.Id == id)!;

            ctx.ListItems.Remove(foundItem);
            ctx.SaveChanges();
        }

        public void Update(int id, ListItem item)
        {
            ListItem updatedItem = ctx.ListItems.FirstOrDefault(l => l.Id == id)!;

            updatedItem.Name = item.Name;
            updatedItem.CreatedAt = item.CreatedAt;
            updatedItem.ListId = item.ListId;
            updatedItem.PriorityId = item.PriorityId;
            updatedItem.IsConcluded = item.IsConcluded;
            updatedItem.Value = item.Value;

            ctx.ListItems.Update(updatedItem);
            ctx.SaveChanges();

        }
    }
}
