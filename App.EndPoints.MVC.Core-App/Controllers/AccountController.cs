using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.Core_App.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult ChooseAction()
        {
            return View();
        }
    }
}
