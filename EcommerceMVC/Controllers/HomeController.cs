using EcommerceMVC.Models;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Business.Abstract;
using Microsoft.Extensions.Logging;

namespace EcommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;

        public HomeController(ILogger<HomeController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

      
        public IActionResult Index()
        {
            
            var posts = _postService.GetAllPost();
            return View(posts);
        }

      
        public IActionResult Privacy()
        {
            return View();
        }

      
        public IActionResult About()
        {
            return View();
        }

       
        public IActionResult Gallery()
        {
            return View();
        }

   
        public IActionResult Menu()
        {
            return View();
        }

       
        public IActionResult Reservation()
        {
            return View();
        }

       
        public IActionResult Pages()
        {
            return View();
        }

       
        public IActionResult Blog()
        {
            var posts = _postService.GetAllPost();
            return View(posts); 
        }

       
        public IActionResult Contact()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
