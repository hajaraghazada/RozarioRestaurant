using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var posts = _postService.GetAllPost();
            return View(posts);
        }

        public IActionResult Details(int id)
        {
            var post = _postService.GetPost(id);
            return View(post);
        }
    }
}