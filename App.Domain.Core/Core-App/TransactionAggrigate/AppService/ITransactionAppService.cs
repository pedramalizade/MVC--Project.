using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using App.EndPoints.MVC.Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.Core.Core_App.TransactionAggrigate.AppService
{
    public interface ITransactionAppService
    {
        public Result Transfer(string sourceCardNumber, string destinationCardNumber, float amount);
        public List<Transaction> GetTransactions(string cardNumber);
        public List<Transaction> CardTransactionList(string cardNumber);
    }
}
