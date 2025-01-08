using App.Domain.Core.Core_App.TransactionAggrigate.Entities;
using App.Domain.Core.Core_App.TransactionAggrigate.Services;
using App.Domain.Service.Core_App.CardAggrigate;
using App.EndPoints.MVC.Core_App.Models;
using App.Infra.Data.Repos.Ef.Core_App.TransactionAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Core_App.TransactionAggrigate
{
    public class TransactionService : ITransactionService
    {
        private readonly CardService _cardService;
        private readonly TransactionRepository _transactionRepository;
        public TransactionService()
        {
            _cardService = new CardService();
            _transactionRepository = new TransactionRepository();
        }

        public Result Transfer(string sourceCardNumber, string destinationCardNumber, float amount)
        {
            var transactionamount = _transactionRepository.TransactionAmountInDay(sourceCardNumber);
            if (transactionamount >= 250)
            {
                return new Result(false, " Transfer limit has been exceeded.");
            }
            if (transactionamount + amount > 250)
            {
                return new Result(false, $"The Transfer limit will be  exceeded.Entered amonut must be less than {transactionamount - 250}");

            }

            if (amount < 0)
            {
                return new Result(false, "The transfer amount must be greater than zero.");

            }

            _cardService.ReduceAmount(amount, sourceCardNumber, destinationCardNumber);


            var sourceCard = _cardService.GetCardByNumber(sourceCardNumber);
            var destinationCard = _cardService.GetCardByNumber(destinationCardNumber);

            if (sourceCard == null || destinationCardNumber == null)
            {
                return new Result(false, "Surce or destination card not found.");
            }

            if (!_cardService.CheckCardBalance(sourceCard, amount))
            {
                return new Result(false, "Insifficient balance on the source card.");
            }

            _cardService.DeductBalance(sourceCard, amount);
            _cardService.AddBalance(destinationCard, amount);

            var transaction = new Transaction
            {
                SourceCardNumber = sourceCardNumber,
                DestinationCardNumber = destinationCardNumber,
                Amount = amount,
                TranceactionTime = DateTime.Now,
                IsSuccessful = true
            };

            _transactionRepository.AddTransaction(transaction);
            return new Result(true, "Transfer Added.");

        }

        public List<Transaction> GetTransactions(string cardNumber)
        {
            return _transactionRepository.GetAllTransaction(cardNumber);
        }

        public List<Transaction> CardTransactionList(string cardNumber)
        {
            return _transactionRepository.GetAllTransaction(cardNumber);
        }
    }
}
