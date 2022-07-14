using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyForumSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        [Authorize(Roles = "Admin")]
       
        public IActionResult Approve()
        {
            return View();
        }
    }
}
