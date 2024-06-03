using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IUserRepository
    {
        public void Create(User user);
        public void Update(Guid id);
        public User GetUser(Guid id);
        public bool ChangePassword(string email, string newPassword);

    }
}
