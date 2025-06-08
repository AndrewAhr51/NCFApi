using Microsoft.AspNetCore.Mvc;

namespace NCFApi.API.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
