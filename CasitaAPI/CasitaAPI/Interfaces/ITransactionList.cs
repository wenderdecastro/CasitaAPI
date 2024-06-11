﻿using CasitaAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CasitaAPI.Interfaces
{
    public interface ITransactionList
    {
        public void Create(TransactionList tList);
        public void Update(int id, TransactionList tList);
        public List<TransactionList> GetList(Guid userId);
        public string Delete(int id);
        public void UploadPhoto(int id, string novaUrlFoto);

        public TransactionList GetTransaction (int id);
    }
}
