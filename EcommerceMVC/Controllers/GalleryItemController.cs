using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class GalleryItemController : Controller
    {
        private readonly IGalleryItemService _galleryItemService;

        public GalleryItemController(IGalleryItemService galleryItemService)
        {
            _galleryItemService = galleryItemService;
        }

        public IActionResult Index()
        {
            var galleryItems = _galleryItemService.GetGalleryItems();
            return View(galleryItems);
        }
    }
}
