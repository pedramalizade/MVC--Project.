using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Infra.DataBase.InMemory
{
    public static class InMemoryDb
    {
        public static List<User> Users { get; set; }
        public static List<Card> Cards { get; set; }
        public static List<Transaction> Transactions { get; set; }
    }
}
