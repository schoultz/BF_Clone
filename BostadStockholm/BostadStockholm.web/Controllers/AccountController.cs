using Microsoft.AspNetCore.Mvc;

namespace BostadStockholm.web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}