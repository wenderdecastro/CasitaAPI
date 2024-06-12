using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Utils;
using Microsoft.VisualBasic;

namespace CasitaAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly CasitaDbContext ctx;

        public UserRepository()
        {
            ctx = new CasitaDbContext();
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

                var id = Guid.NewGuid();
                var financial = user.IdNavigation;

                var newUser = new User
                {
                    Id = id,
                    Name = user.Name,
                    Email = user.Email,
                    Password = Cryptography.GenerateHash(user.Password),



                    IdNavigation = new Models.Financial
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
                                FinantialId = id,
                                Name = "Lista de Compras",
                                AmountSpent = 0,
                                TotalAmount = null,
                                PhotoUrl = null,
                                PriorityId = null,
                                ListTypeId = 4

                            },

                        },

                    },
                    AppLists = new List<AppList>
                    {
                       

                        //Criação das listas padrões de tarefas do usuário.
                        new AppList
                        {
                            Name = "Tarefas",
                            ListTypeId = 1,
                            UserId = id,


                        },
                        new AppList
                        {
                            Name = "Objetivos",
                            ListTypeId = 7,
                            UserId = id,


                        },
                        new AppList
                        {
                            Name = "Meu Dia",
                            ListTypeId = 2,
                            UserId = id,

                        },
                        new AppList
                        {
                            Name = "Metas",
                            ListTypeId = 3,
                            UserId = id,

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
            return ctx.Users.FirstOrDefault(x => x.Id == id)!;
        }

        public void Update(User user)
        {
            try
            {
                var toupdate = ctx.Users.Find(user.Id);
                if (toupdate == null) return;

                toupdate.IdNavigation.WantsPercentage = user.IdNavigation.WantsPercentage;
                toupdate.IdNavigation.NecessitiesPercentage = user.IdNavigation.NecessitiesPercentage;
                toupdate.IdNavigation.SavingsPercentage = user.IdNavigation.SavingsPercentage;
                toupdate.IdNavigation.ReceiptDate = user.IdNavigation.ReceiptDate;
                toupdate.UpdatedAt = DateTime.Now;

                ctx.Update(toupdate);
                ctx.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }

        }

        public User GetByEmailAndPwd(string email, string senha)
        {
            try
            {
                var user = ctx.Users.FirstOrDefault(x => x.Email == email);

                user.IdNavigation = ctx.Financials.FirstOrDefault(x => x.Id == user.Id);
                if (user == null) return null!;

                if (!Cryptography.MatchHash(senha, user.Password!)) return null!;

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetAll()
        {
            return ctx.Users.ToList();
        }

    }


}

