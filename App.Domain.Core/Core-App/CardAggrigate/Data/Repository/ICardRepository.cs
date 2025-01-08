using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.EndPoints.MVC.Core_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Core_App.CardAggrigate.Repository
{
    public interface ICardRepository
    {
        public Card GetCardByNumber(string cardNumber);
        public void UpdateCard(Card card);
        public bool ChangePassword(string cardNumber, string password, string newPassword);
        public Result DoesCardExists(string cardnumber, string password);
        public void Update(Card card);
    }
}
