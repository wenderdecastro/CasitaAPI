using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasitaAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly CasitaDbContext ctx;

        public TaskRepository()
        {
            ctx = new CasitaDbContext();
        }

        public void AlterStatus(int id)
        {
            var task = ctx.AppTasks.FirstOrDefault(t => t.Id == id);
            task.IsConcluded = !task.IsConcluded;
            task.ConcludedDate = DateTime.Now;  
            ctx.AppTasks.Update(task);
            ctx.SaveChanges();
        }

        public List<AppTask> GetMyDay(Guid userId)
        {

            var myday = ctx.AppLists.FirstOrDefault(x => x.UserId == userId && x.ListTypeId == 2);
            if (myday == null) { return null; }
            var teste = ctx.AppTasks.Where(x => x.ListId == myday.Id).ToList();
            return teste;
        }

        public void Create( Guid userId, AppTask newTask, int listTypeId)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            if (newTask.DueDate == today)
            {
                listTypeId = 2;
            }

            var list = ctx.AppLists.FirstOrDefault(x => x.UserId == userId && x.ListTypeId == listTypeId);
            newTask.ListId = list.Id;



            ctx.AppTasks.Add(newTask);
                ctx.SaveChanges();
                
        }

        public void Delete(int id)
        {
            var task = ctx.AppTasks.Find(id);
            ctx.AppTasks.Remove(task);
            ctx.SaveChanges();

        }

        public void MoveToMyDay(int id, int dayListId)
        {
            var task = ctx.AppTasks.Find(id);
            task.ListId = dayListId;
            ctx.AppTasks.Update(task);
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
            if (taskUpdate.DueTime != null)
            {
                task.DueTime = taskUpdate.DueTime;
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
