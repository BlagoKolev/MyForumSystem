using Microsoft.AspNetCore.Mvc;

namespace MyForumSystem.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult ErrorHandler(int statusCode)
        {
            switch (statusCode)
            {
                case (400-499): ViewData["errorMessage"] = "Sorry the resource you are looking for could not be found"; break;
                default:
                    break;
            }
            return View("NotFound");
        }
    }
}
