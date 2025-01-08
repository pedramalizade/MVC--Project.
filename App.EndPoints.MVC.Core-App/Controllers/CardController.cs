using App.Domain.AppService.Core_App.CardAggrigate;
using App.Domain.AppService.Core_App.TransactionAggrigate;
using App.Domain.AppService.Core_App.UserAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.TransactionAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Core_App.Controllers
{
    public class CardController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ITransactionAppService _transactionAppService;
        private readonly ICardAppService _cardAppService;
        public CardController(IUserAppService userAppService, ITransactionAppService transactionAppService, ICardAppService cardAppService)
        {
            _userAppService = userAppService;
            _transactionAppService = transactionAppService;
            _cardAppService = cardAppService;
        }
        public IActionResult Index()
        {
            var users = _userAppService.GetUserCards(OnlineUser.User.Id);
            return View(users);
        }
        [HttpPost]
        public IActionResult Transaction(string cardNumber)
        {
            return View(_transactionAppService.GetTransactions(cardNumber));
        }
        public IActionResult ChangePassword()
        {
            return View(OnlineUser.User);
        }
        [HttpPost]
        public IActionResult ChangePassword(string cardNumber, string password, string newPassword)
        {
            var res = _cardAppService.ChangePassword(cardNumber, password, newPassword);
            return View("Home");
        }
       
    }
}
