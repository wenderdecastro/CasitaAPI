﻿using CasitaAPI.Data;
using CasitaAPI.Interfaces;
using CasitaAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CasitaAPI.Repository
{
    public class TransactionListRepository : ITransactionList
    {

        private readonly CasitaDbContext ctx;

        public TransactionListRepository()
        {
            ctx = new CasitaDbContext();
        }
        public void Create(TransactionList tList)
        {
            ctx.Add(tList);
            ctx.SaveChanges();
        }

        public string Delete(int id)
        {
            TransactionList tlFound = ctx.TransactionLists.FirstOrDefault(tl => tl.Id == id)!;

            if (tlFound != null)
            {

                ctx.Remove(tlFound);
                ctx.SaveChanges();

                return "Item deletado com sucesso!";
            }
            else
            {
                return "Nenhum item encontrado!";
            }
        }

        public List<TransactionList> GetList(Guid id)
        {
            try
            {

                    return ctx.TransactionLists.Where(tl => tl.FinantialId == id).ToList();

            }
            catch (Exception e)
            {

                throw;
            }
          

        }

        public void Update(int id, TransactionList tList)
        {
          TransactionList tlFound = ctx.TransactionLists.FirstOrDefault(tl => tl.Id == id)!;

            if (tlFound != null)
            {

                tlFound.AmountSpent = tList.AmountSpent;
                tlFound.TotalAmount = tList.TotalAmount;
                tlFound.FinantialId = tList.FinantialId;
                tlFound.PhotoUrl = tList.PhotoUrl;
                tlFound.Priority = tList.Priority;
                tlFound.ListType = tList.ListType;
                ctx.Update(tlFound);
                ctx.SaveChanges();
            }
            else { return; }
        }

        public void UploadPhoto(int id, string novaUrlFoto)
        {

            try
            {
                TransactionList transactionFound = ctx.TransactionLists.FirstOrDefault(x => x.Id == id)!;

                if (transactionFound != null)
                {
                    transactionFound.PhotoUrl = novaUrlFoto;
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TransactionList GetTransaction(int id)
        {
            return ctx.TransactionLists.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
