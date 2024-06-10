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

        public void Create(AppTask newTask)
        {

                ctx.AppTasks.Add(newTask);
                ctx.SaveChanges();
                
        }

        public void Delete(int id)
        {
            var task = ctx.AppTasks.Find(id);
            ctx.AppTasks.Remove(task);
            ctx.SaveChanges();

        }

        public void MoveToMyDay(int id)
        {
            var task = ctx.AppTasks.Find(id);
            task.ListId = 2;
            ctx.SaveChanges();
        }

        public void Update(int id, AppTask taskUpdate)
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
    }
}
