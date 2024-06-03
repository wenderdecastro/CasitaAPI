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
                var financial = user.IdNavigation;

                var newUser = new User
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/1200px-Default_pfp.svg.png",

                    

                    IdNavigation = new Financial
                    {
                        Id = id,
                        Balance = 0,
                        WantsPercentage = financial.WantsPercentage,
                        NecessitiesPercentage = financial.NecessitiesPercentage,
                        SavingsPercentage = financial.SavingsPercentage,
                        ReceiptDate = financial.ReceiptDate,
                        TransactionLists = new List<TransactionList>
                        {
                            //Criação da lista padrão de compras do usuário
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

                        },

                    },
                    AppLists = new List<AppList>
                    {
                        //Criação das listas padrões de tarefas do usuário.
                        new AppList
                        {
                            Name = "Tarefas",
                            ListTypeId = 1

                        },
                        new AppList
                        {
                            Name = "Meu Dia",
                            ListTypeId = 2
                        }
                        
                    },
                    UpdatedAt = DateTime.Now,
                    



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
            return ctx.Users.FirstOrDefault(x => x.Id == id);
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

    }


}

