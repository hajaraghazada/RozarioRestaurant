using Business.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EcommerceMVC.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

       
        public IActionResult Index()
        {
            var menuItems = _menuItemService.GetMenuItems();
            if (menuItems == null || !menuItems.Any())
            {
                return View("Error");
            }

            return View(menuItems);
        }

    
        public IActionResult Details(int id)
        {
            var menuItemDto = _menuItemService.GetMenuItemById(id);
            if (menuItemDto == null)
            {
                return NotFound();
            }

            return View(menuItemDto);
        }

   
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // Menü öğesi ekleme işlemi (form gönderildiğinde çalışır)
        [HttpPost]
        public IActionResult Add(MenuItemDto menuItemDto)
        {
            if (ModelState.IsValid)
            {
                var menuItem = new MenuItem
                {
                    Name = menuItemDto.Name,
                    Description = menuItemDto.Description,
                    Price = menuItemDto.Price,
                    ImageURL = menuItemDto.ImageURL
                };
                _menuItemService.AddMenuItem(menuItem);
                return RedirectToAction("Index");
            }

            return View(menuItemDto);
        }

       
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _menuItemService.DeleteMenuItem(id);
            return RedirectToAction("Index");
        }

      
        [HttpGet]
        public IActionResult Update(int id)
        {
            var menuItemDto = _menuItemService.GetMenuItemById(id);
            if (menuItemDto == null)
            {
                return NotFound();
            }

            return View(menuItemDto);
        }

       
        [HttpPost]
        public IActionResult Update(MenuItemDto menuItemDto)
        {
            if (ModelState.IsValid)
            {
                var menuItem = new MenuItem
                {
                    ID = menuItemDto.ID,
                    Name = menuItemDto.Name,
                    Description = menuItemDto.Description,
                    Price = menuItemDto.Price,
                    ImageURL = menuItemDto.ImageURL
                };
                _menuItemService.UpdateMenuItem(menuItem);
                return RedirectToAction("Index");
            }

            return View(menuItemDto);
        }
    }
}