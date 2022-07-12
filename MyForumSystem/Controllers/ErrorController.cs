using Microsoft.AspNetCore.Mvc;

namespace MyForumSystem.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult ErrorHandler(int statusCode)
        {
            var viewName = string.Empty;

            switch (statusCode)
            {
                case (404): viewName = "NotFound"; break;
                default:
                    break;
            }
            return View(viewName);
        }
    }
}
