using App.Domain.AppService.Core_App.CardAggrigate;
using App.Domain.AppService.Core_App.TransactionAggrigate;
using App.Domain.AppService.Core_App.UserAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.TransactionAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.EndPoints.MVC.Core_App.Models;
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
            var users = _userAppService.GetAll();
            return View(users);
        }
        public IActionResult Transaction(string cardnumber)
        {
            return View(_transactionAppService.GetTransactions(cardnumber));
        }
        public IActionResult ChangePassword()
        {
            return View(OnlineUserModel.user);
        }
        [HttpPost]
        public IActionResult ChangePassword(string cardnumber, string password, string newPassword)
        {
            var res = _cardAppService.ChangePassword(cardnumber, password, newPassword);
            return View("Home");
        }
    }
}
