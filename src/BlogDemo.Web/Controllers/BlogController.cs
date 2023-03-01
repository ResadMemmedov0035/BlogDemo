using BlogDemo.Application.Features.Blogs.Commands;
using BlogDemo.Application.Features.Blogs.DTOs;
using BlogDemo.Application.Features.Blogs.Queries;
using BlogDemo.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace BlogDemo.Web.Controllers
{
    public class BlogController : MvcController
    {
        public async Task<IActionResult> Index()
        {
            GetBlogListDTO dto = await Mediator.Send(new GetBlogListQuery());
            return View(dto);
        }

        public async Task<IActionResult> Details(int id)
        {
            GetBlogDTO dto = await Mediator.Send(new GetBlogByIdQuery(id));
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title)
        {
            CreatedBlogDTO dto = await Mediator.Send(new CreateBlogCommand(title, "The blog's content is under the construction.", 
                "/images/1.jpg", "/images/1.jpg", 4));
            return View();
        }
    }
}
