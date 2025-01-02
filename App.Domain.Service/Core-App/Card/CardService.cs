using App.Domain.Core.Core_App.CardAggrigate.Services;
using App.Infra.DataAccess.Dapper.Core_App.CardAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Core_App.CardAggrigate.Repository;

namespace App.Domain.Service.Core_App.CardAggrigate
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        public CardService()
        {
            _cardRepository = new CardRepository();
        }
        public void AddBalance(Card card, float amount)
        {
            card.Balance += amount;
            _cardRepository.UpdateCard(card);
        }

        public bool ChangePassword(string cardNumber, string password, string newPassword)
        {
            var user = _cardRepository.ChangePassword(cardNumber, password, newPassword);
            return true;
        }

        public string CheckCard(string cardNumber, string password)
        {
            var card = _cardRepository.GetCardByNumber(cardNumber);
            if (card == null)
            {
                return "Card Not Found.";
            }

            if (card.Password != password)
            {
                card.FailedAttempts++;
                if (card.FailedAttempts >= 3)
                {
                    card.IsActive = false;
                    _cardRepository.UpdateCard(card);
                    return "Card Is Blocked";
                }
                _cardRepository.UpdateCard(card);
                return "Incorrect password";
            }
            _cardRepository.UpdateCard(card);
            return "Check Successful.";
        }

        public bool CheckCardBalance(Card card, float amount)
        {
            return card.Balance >= amount;
        }

        public void DeductBalance(Card card, float amount)
        {
            card.Balance -= amount;
            _cardRepository.UpdateCard(card);
        }

        public Card GetCardByNumber(string cardNumber)
        {
            return _cardRepository.GetCardByNumber(cardNumber);
        }

        public bool GetHolderNameCard(string cardNumber)
        {
            var name = _cardRepository.GetCardByNumber(cardNumber).HolderName;
            if (name == null)
            {
                Console.WriteLine("cannot find holder name");
                return false;
            }
            Console.WriteLine($"HolderName : {name}");
            return true;
        }

        public bool IsCardValid(string cardNumber)
        {
            if (cardNumber.Length == 16)
            {
                var card = _cardRepository.GetCardByNumber(cardNumber);
                return card != null && card.IsActive;
            }
            else
            {
                Console.WriteLine("Your card Number is not correct.");
                return false;
            }
        }

        public bool ReduceAmount(double money, string cardNumber, string distanceCardNumber)
        {
            var distanceCard = _cardRepository.GetCardByNumber(distanceCardNumber);
            if (distanceCard == null)
            {
                return false;
            }
            else
            {
                if (money <= 0)
                {
                    return false;
                }
                else
                {
                    double moneyTax;
                    if (money > 1000)
                    {
                        moneyTax = money * 0.015;
                    }
                    else
                    {
                        moneyTax = money * 0.005;
                    }
                }
                return true;
            }
        }

        public bool UpdateBalance(Card card, float amount)
        {
            if (card == null)
            {
                return false;
            }
            card.Balance = card.Balance + amount;
            _cardRepository.UpdateCard(card);
            return true;
        }
    }
}
