using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.TransactionAggrigate.Data.Repository
{
    public interface ITransactionRepository
    {
        public void AddTransaction(Transaction transaction);
        public List<Transaction> GetAllTransaction(string cardNumber);
        public float TransactionAmountInDay(string cardnumber);
    }
}
