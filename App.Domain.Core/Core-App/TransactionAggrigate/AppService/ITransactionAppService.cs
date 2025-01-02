﻿using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Domain.Core.Core_App.TransactionAggrigate.AppService
{
    public interface ITransactionAppService
    {
        public bool Transfer(string sourceCardNumber, string destinationCardNumber, float amount);
        public List<Transaction> GetTransactions(string cardNumber);
    }
}
