using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete; 

namespace EcommerceMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;

        public BlogController(IPostService postService)
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


        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post) 
        {
            if (ModelState.IsValid) 
            {
                _postService.AddPost(post); 
                return RedirectToAction(nameof(Index));
            }
            return View(post); 
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postService.GetPost(id); 
            if (post == null)
            {
                return NotFound(); 
            }
            return View(post); 
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Post post)
        {
            if (id != post.ID)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _postService.UpdatePost(post); 
                return RedirectToAction(nameof(Index)); 
            }
            return View(post); 
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _postService.GetPost(id); 
            if (post == null)
            {
                return NotFound(); 
            }
            return View(post); 
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var post = _postService.GetPost(id); 
            if (post == null)
            {
                return NotFound(); 
            }

            _postService.DeletePost(id); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}