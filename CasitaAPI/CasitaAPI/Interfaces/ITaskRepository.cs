using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface ITaskRepository
    {
        public void Create(AppTask task);
        public void Update(int id, AppTask task);
        public void Delete(int id);
        public void AlterStatus(int id);
        public void MoveToMyDay(int id, int dayListId);

        public List<AppTask> GetAll(Guid userId);
    }
}
