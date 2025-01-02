using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.CardAggrigate.Entities
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public int FailedAttempts { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Transaction> SentTransaction { get; set; }
        public List<Transaction> ReceivedTransactions { get; set; }
        public Card()
        {
            
        }
    }
}
