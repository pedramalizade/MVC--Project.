using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.CardAggrigate.Entities;
using App.Domain.Core.Core_App.CardAggrigate.Services;
using App.Domain.Service.Core_App.CardAggrigate;
using App.EndPoints.MVC.Core_App.Models;
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
        static Dictionary<int, DateTime> Codes = new Dictionary<int, DateTime>();
        public void AddBalance(Card card, float amount)
        {
            _cardService.AddBalance(card, amount);
        }

        public Result ChangePassword(string cardNumber, string password, string newPassword)
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

        public Result IsCodeValid(int code)
        {
            if (Codes.ContainsKey(code) && Codes[code] > DateTime.Now)
            {
                return new Result(true);
            }
            if (Codes.ContainsKey(code) && Codes[code] < DateTime.Now)
            {
                Codes.Remove(code);
                return new Result(false, "The Code has expired.");
            }
            return new Result(false, "The Entered code is wrong.");
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
