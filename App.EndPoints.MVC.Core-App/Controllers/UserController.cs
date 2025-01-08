using App.Domain.AppService.Core_App.CardAggrigate;
using App.Domain.AppService.Core_App.TransactionAggrigate;
using App.Domain.AppService.Core_App.UserAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.TransactionAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using App.EndPoints.MVC.Core_App.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.EndPoints.MVC.Core_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ITransactionAppService _transactionAppService;
        private readonly ICardAppService _cardAppService;
        public UserController(IUserAppService userAppService, ITransactionAppService transactionAppService, ICardAppService cardAppService)
        {
            _userAppService = userAppService;
            _transactionAppService = transactionAppService;
            _cardAppService = cardAppService;   
        }
        public IActionResult Index()
        {
            var users = _userAppService.GetAllUser();
            return View(users);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            var y = _userAppService.Register(user);
            if (!y)
            {
                ViewData["Error"] = "you cannot registered!";
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var x = _userAppService.Login(username, password);
            OnlineUserModel.user = x;
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Transfer()
        {
            return View(OnlineUserModel.user);
        }
        [HttpPost]
        public IActionResult Transfer(string sourceCardNumber, string destinationCardNumber, float amount, int code)
        {
            var isvalid = _cardAppService.IsCodeValid(code);

            if (!isvalid.IsDone)
            {
                TempData["CodeErrorMessage"] = isvalid.Message;
                return RedirectToAction("Transfer");
            }
            var isdone = _transactionAppService.Transfer(sourceCardNumber, destinationCardNumber, amount);
            return RedirectToAction("Transaction", "Card", new { cardnumber = sourceCardNumber });
        }
        public IActionResult RandomCode()
        {
            _userAppService.GenerateRandomeCode();
            TempData["RandomCodeMessage"] = $"!Note: The random code is only valid for 50 secondes. ";
            return RedirectToAction("Transaction");
        }
    }
}
