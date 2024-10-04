using Business.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            if (galleryItems == null || !galleryItems.Any())
            {
                return View("Error");
            }

            return View(galleryItems);
        }

        public IActionResult Details(int id)
        {
            var galleryItemDto = _galleryItemService.GetGalleryItemById(id);
            if (galleryItemDto == null)
            {
                return NotFound();
            }

            return View(galleryItemDto);
        }

        [HttpPost]
        public IActionResult Add(GalleryItemDto galleryItemDto)
        {
            if (ModelState.IsValid)
            {
                var galleryItem = new GalleryItem
                {
                    Title = galleryItemDto.Title,
                    ImageURL = galleryItemDto.ImageURL
                };
                _galleryItemService.AddGalleryItem(galleryItem);
                return RedirectToAction("Index");
            }

            return View(galleryItemDto);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _galleryItemService.DeleteGalleryItem(id);
            return RedirectToAction("Index");
        }
    }
}