using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class ListItemRepository : IListItemRepository
    {

        private readonly CasitaContext ctx;

        public ListItemRepository()
        {
            ctx = new CasitaContext();
        }
        public string Conclude(int id)
        {
            ListItem nonCloncluded = ctx.ListItems.First(l => l.Id == id);
            
            if (nonCloncluded.IsConcluded == false) {

                nonCloncluded.IsConcluded = true;
                ctx.ListItems.Update(nonCloncluded);
                ctx.SaveChanges();

                return "Parabens por comprir a lista de tarefas";
            }
            else
            {
                return "O seu item ja foi concluido";
            }

            
        }

        public void Create(ListItem item)
        {
            try
            {
                ctx.ListItems.Add(item);
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
