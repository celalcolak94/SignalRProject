using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class AMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
