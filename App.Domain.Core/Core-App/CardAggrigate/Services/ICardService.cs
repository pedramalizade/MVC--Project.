using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.CardAggrigate.Services
{
    public interface ICardService
    {
        public Entities.Card GetCardByNumber(string cardNumber);
        public string CheckCard(string cardNumber, string password);
        public bool UpdateBalance(Entities.Card card, float amount);
        public bool CheckCardBalance(Entities.Card card, float amount);
        public bool IsCardValid(string cardNumber);
        public void DeductBalance(Entities.Card card, float amount);
        public void AddBalance(Entities.Card card, float amount);
        public bool ChangePassword(string cardNumber, string password, string newPassword);
        public bool ReduceAmount(double money, string cardNumber, string distanceCardNumber);
        public bool GetHolderNameCard(string cardNumber);
    }
}
