using App.Domain.Core.Core_App.CardAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.TransactionAggrigate.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public float Amount { get; set; }
        public DateTime TranceactionTime { get; set; }
        public bool IsSuccessful { get; set; }
        public Card SourceCard { get; set; }
        public Card DestinationCard { get; set; }
        public Transaction(string destinationCardNumber, string sourceCardNumber, float amount)
        {
            TranceactionTime = DateTime.Now;
            Amount = amount;
            SourceCardNumber = sourceCardNumber;
            DestinationCardNumber = destinationCardNumber;
        }
        public override string ToString()
        {
            return $"Source Card: {SourceCardNumber} || Destination Card: {DestinationCardNumber} || Transaction Date: {TranceactionTime} || Amount: {Amount}";
        }
        public Transaction() { }
    }
}
