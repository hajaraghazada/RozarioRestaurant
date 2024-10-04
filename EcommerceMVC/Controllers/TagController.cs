using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

       
        public IActionResult Index()
        {
            var tags = _tagService.GetAllTags();
            if (tags == null || !tags.Any())
            {
                return View("Error"); 
            }

            return View(tags); 
        }

      
        public IActionResult Details(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound(); 
            }

            return View(tag); 
        }

      
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.AddTag(tag);
                return RedirectToAction(nameof(Index)); 
            }

            return View(tag); 
        }

      
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag); 
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tag tag)
        {
            if (id != tag.ID)
            {
                return BadRequest(); 
            }

            if (ModelState.IsValid)
            {
                _tagService.UpdateTag(tag);
                return RedirectToAction(nameof(Index)); 
            }

            return View(tag); 
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag); 
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tag = _tagService.GetTagById(id);
            if (tag == null)
            {
                return NotFound();
            }

            _tagService.DeleteTag(id); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
