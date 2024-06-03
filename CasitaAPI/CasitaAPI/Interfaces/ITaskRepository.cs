using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface ITaskRepository
    {
        public void Create(AppTask task);
        public void Update(AppTask task);
        public void Delete(int id);
        public void Conclude();
        public void MoveToMyDay();
    }
}
