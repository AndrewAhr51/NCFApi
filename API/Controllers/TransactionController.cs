using Microsoft.AspNetCore.Mvc;

namespace NCFApi.API.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
