using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly CasitaContext ctx;

        public TaskRepository()
        {
            ctx = new CasitaContext();
        }

        public void AlterStatus(int id)
        {
            var task = ctx.AppTasks.FirstOrDefault(t => t.Id == id);
            task.IsConcluded = !task.IsConcluded;
            ctx.AppTasks.Update(task);
            ctx.SaveChanges();
        }

        public void Create(int listId, AppTask task)
        {
            try
            {
                var newTask = new AppTask
                {
                    Name = task.Name,
                    Description = task.Description,
                    CreatedAt = DateTime.Now,
                    DueDate = task.DueDate,
                    FrequencyId = task.FrequencyId,
                    ListId = listId,
                    IsConcluded = false,
                    PriorityId = task.PriorityId,

                };

                ctx.AppTasks.Add(newTask);
                ctx.SaveChanges();

                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void MoveToMyDay(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AppTask task)
        {
            throw new NotImplementedException();
        }
    }
}
