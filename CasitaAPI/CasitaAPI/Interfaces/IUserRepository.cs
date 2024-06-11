using CasitaAPI.Models;

namespace CasitaAPI.Interfaces
{
    public interface IUserRepository
    {
        public void Create(User user);
        public void Update(User userToAlter);
        public User GetUser(Guid id);
        public User GetByEmailAndPwd(string email, string senha);
        public bool ChangePassword(string email, string newPassword);
        public List<User> GetAll();

    }
}
