using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.CardAggrigate.Services;
using App.Domain.Service.Core_App.CardAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.Core_App.CardAggrigate
{
    public class CardAppService : ICardAppService
    {
        private readonly ICardService _cardService;
        public CardAppService()
        {
            _cardService = new CardService();
        }

        public void AddBalance(Card card, float amount)
        {
            _cardService.AddBalance(card, amount);
        }

        public bool ChangePassword(string cardNumber, string password, string newPassword)
        {
            return _cardService.ChangePassword(cardNumber, password, newPassword);
        }

        public string CheckCard(string cardNumber, string password)
        {
            return _cardService.CheckCard(cardNumber, password);
        }

        public bool CheckCardBalance(Card card, float amount)
        {
            return _cardService.CheckCardBalance(card, amount);
        }

        public void DeductBalance(Card card, float amount)
        {
            _cardService.DeductBalance(card, amount);
        }

        public Card GetCardByNumber(string cardNumber)
        {
            return _cardService.GetCardByNumber(cardNumber);
        }

        public bool GetHolderNameCard(string cardNumber)
        {
            return _cardService.GetHolderNameCard(cardNumber);
        }

        public bool IsCardValid(string cardNumber)
        {
            return _cardService.IsCardValid(cardNumber);
        }

        public bool ReduceAmount(double money, string cardNumber, string distanceCardNumber)
        {
           return _cardService.ReduceAmount(money, cardNumber, distanceCardNumber);
        }

        public bool UpdateBalance(Card card, float amount)
        {
            return _cardService.UpdateBalance(card, amount);
        }
    }
}
