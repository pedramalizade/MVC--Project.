using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.CardAggrigate.Repository;
using App.Infra.DataBase.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Dapper.Core_App.CardAggrigate
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _appDbContext;
        public CardRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public bool ChangePassword(string cardNumber, string password, string newPassword)
        {
            var card = GetCardByNumber(cardNumber);
            if (card == null)
            {
                Console.WriteLine("UserName not found.");
                return false;
            }
            if (card.Password != password)
            {
                Console.WriteLine("Password is Wrong");
                return false;
            }
            card.Password = newPassword;
            _appDbContext.SaveChanges();
            Console.WriteLine("change password is success.");
            return true;
        }

        public void UpdateCard(Card card)
        {
            _appDbContext.Cards.Update(card);
            _appDbContext.SaveChanges();
        }

        public Card GetCardByNumber(string cardNumber)
        {
            return _appDbContext.Cards.FirstOrDefault(c => c.CardNumber == cardNumber);
        }
    }
}
