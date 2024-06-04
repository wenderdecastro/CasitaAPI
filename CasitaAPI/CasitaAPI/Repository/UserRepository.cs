using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Utils;

namespace CasitaAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly CasitaContext ctx;

        public UserRepository()
        {
            ctx = new CasitaContext();
        }

        public bool ChangePassword(string email, string newPassword)
        {
            try
            {
                var user = ctx.Users.FirstOrDefault(x => x.Email == email);

                if (user == null) return false;

                user.Password = Cryptography.GenerateHash(newPassword);

                ctx.Update(user);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }

            return true;
        }

        public void Create(User user)
        {

            try
            {
                Guid id = Guid.NewGuid();

                var newUser = new User
                {
                    Id = id,
                    Email = user.Email,
                    Password = user.Password,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/1200px-Default_pfp.svg.png",

                    UserFinancial = new Financial
                    {
                        Id = id,
                        Balance = 0,
                        WantsPercentage = user.UserFinancial.WantsPercentage,
                        NecessitiesPercentage = user.UserFinancial.NecessitiesPercentage,
                        SavingsPercentage = user.UserFinancial.SavingsPercentage,
                        ReceiptDate = user.UserFinancial.ReceiptDate,
                        TransactionLists = new List<TransactionList>
                    {
                        new TransactionList
                        {
                            Name = "Lista de Compras",
                            AmountSpent = 0,
                            TotalAmount = null,
                            ListTypeId = 4,
                            FinantialId = id,
                            PhotoUrl = null,
                            PriorityId = null,

                        },
                    }
                    }
                };
                ctx.Add(newUser);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
             
        }

        public User GetUser(Guid id)
        {
            return ctx.Users.FirstOrDefault(x => x.Id == id)!;
        }

        public void Update(Guid id)
        {
            try
            {
                var user = ctx.Users.Find(id);
                if (user == null) return;
                user.UpdatedAt = DateTime.Now;

                ctx.Update(user);
                ctx.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            
        }

        public User SearchByEmailAndId(string email, string senha)
        {
            try
            {
                var user = ctx.Users.Select(u => new User
                {
                    Id = u.Id,
                    Email = u.Email,
                    Password = u.Password,
                    Name = u.Name,
                    
                 
                }).FirstOrDefault
                (x => x.Email == email);

                if (user == null) return null!;

                if (!Cryptography.MatchHash(senha, user.Password!)) return null!;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}

