using Microsoft.AspNetCore.Mvc;

namespace NCFApi.API.Controllers
{
    public class FundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
