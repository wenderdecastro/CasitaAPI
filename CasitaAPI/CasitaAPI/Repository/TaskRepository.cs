using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;

namespace CasitaAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly CasitaDbContext ctx;

        public TaskRepository()
        {
            ctx = new CasitaDbContext();
        }

        public void AlterStatus(Guid id)
        {
            var task = ctx.AppTasks.FirstOrDefault(t => t.Id == id);
            task.IsConcluded = !task.IsConcluded;
            ctx.AppTasks.Update(task);
            ctx.SaveChanges();
        }

        public void Create(AppTask newTask)
        {

                ctx.AppTasks.Add(newTask);
                ctx.SaveChanges();
                
        }

        public void Delete(Guid id)
        {
            var task = ctx.AppTasks.Find(id);
            ctx.AppTasks.Remove(task);
            ctx.SaveChanges();

        }

        public void MoveToMyDay(Guid id, Guid dayListId)
        {
            var task = ctx.AppTasks.Find(id);
            task.ListId = dayListId;
            ctx.SaveChanges();
        }

        public void Update(Guid id, AppTask taskUpdate)
        {
            var task = ctx.AppTasks.Find(id);

            if (taskUpdate.ListId != null)
            {
                task.ListId = taskUpdate.ListId;
            }
            if (taskUpdate.Description != null)
            {
                task.Description = taskUpdate.Description;
            }
            if (taskUpdate.Name != null)
            {
                task.Name = taskUpdate.Name;
            }
            if (taskUpdate.PriorityId != null)
            {
                task.PriorityId = taskUpdate.PriorityId;
            }
            if (taskUpdate.FrequencyId != null)
            {
                task.FrequencyId = taskUpdate.FrequencyId;
            }
            if (taskUpdate.DueDate != null)
            {
                task.DueDate = taskUpdate.DueDate;
            }
            
            ctx.AppTasks.Update(task!);
            ctx.SaveChanges();
        }

        public List<AppTask> GetAll(Guid userId)
        {
            return (ctx.AppTasks.Where(x => x.List.UserId == userId).ToList());
        }
    }
}
