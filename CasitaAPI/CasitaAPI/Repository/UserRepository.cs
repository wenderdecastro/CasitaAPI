﻿using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using CasitaAPI.Utils;

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
                var financial = user.IdNavigation;

                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = Cryptography.GenerateHash(user.Password),



                    IdNavigation = new Financial
                    {
                      
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
                            ListTypeId = 1

                        },
                        new AppList
                        {
                            Name = "Meu Dia",
                            ListTypeId = 2
                        },
                        new AppList
                        {
                            Name = "Metas",
                            ListTypeId = 3
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

        public User GetByEmailAndPwd(string email, string senha)
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

        public List<User> GetAll()
        {
            return ctx.Users.ToList();
        }
    }


}

