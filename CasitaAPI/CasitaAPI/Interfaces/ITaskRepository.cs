using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface ITaskRepository
    {
        public void Create( AppTask task);
        public void Update(Guid id, AppTask task);
        public void Delete(Guid id);
        public void AlterStatus(Guid id);
        public void MoveToMyDay(Guid id, Guid dayListId);

        public List<AppTask> GetAll(Guid userId);
    }
}
