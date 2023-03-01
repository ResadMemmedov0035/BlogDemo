using BlogDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogDemo.Web.Controllers.Common
{
    public class ErrorController : MvcController
    {
        [Route("/Error/Alert")]
        public IActionResult HandleWithAlert(string redirectTo, string message)
        {
            TempData["AlertMessage"] = message;
            return Redirect(redirectTo);
        }

        [Route("/NotFound")]
        public IActionResult HandleNotFound()
        {
            return View("NotFound"); // /Shared/NotFound
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // /Shared/Error
        }
    }
}
