using BlogDemo.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Web.Controllers
{
    public class HomeController : MvcController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }       
    }
}