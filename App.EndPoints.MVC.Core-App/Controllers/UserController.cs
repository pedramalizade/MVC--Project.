using App.Domain.AppService.Core_App.CardAggrigate;
using App.Domain.AppService.Core_App.TransactionAggrigate;
using App.Domain.AppService.Core_App.UserAggrigate;
using App.Domain.Core.Core_App.CardAggrigate.AppService;
using App.Domain.Core.Core_App.TransactionAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.AppService;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using App.EndPoints.MVC.Core_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Core_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ITransactionAppService _transactionAppService;
        public UserController(IUserAppService userAppService, ITransactionAppService transactionAppService)
        {
            _userAppService = userAppService;
            _transactionAppService = transactionAppService;
        }
        public IActionResult Index()
        {
            var users = _userAppService.GetAll();
            return View(users);
        }
        [HttpGet]
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
        public IActionResult Transfer(string sourcecard, string destcard, float amount)
        {
            _transactionAppService.Transfer(sourcecard, destcard, amount);
            return RedirectToAction("Transaction", "Card");
        }
    }
}
