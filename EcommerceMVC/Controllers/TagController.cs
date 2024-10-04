using Business.Abstract;
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
            return View(tags);
        }
    }
}
