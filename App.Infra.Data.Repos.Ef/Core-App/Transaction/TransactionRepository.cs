using App.Domain.Core.Core_App.TransactionAggrigate.Data.Repository;
using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using App.Infra.DataBase.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Core_App.TransactionAggrigate
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public TransactionRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public void AddTransaction(Transaction transaction)
        {
            _appDbContext.Transactions.Add(transaction);
            _appDbContext.SaveChanges();
        }

        public List<Transaction> GetAllTransaction(string cardNumber)
        {
            return _appDbContext.Transactions.Where(t => t.SourceCardNumber == cardNumber || t.DestinationCardNumber == cardNumber).ToList();
        }

        public float TransactionAmountInDay(string cardnumber)
        {
            var transactions = _appDbContext.Transactions.Where(t => t.SourceCardNumber == cardnumber && t.TranceactionTime.DayOfYear == DateTime.Now.DayOfYear).ToList();
            float amount = 0;
            transactions.ForEach(t => amount += t.Amount);
            return amount;
        }
    }
}
