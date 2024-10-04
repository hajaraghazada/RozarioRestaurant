using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

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
            return View(menuItems);
        }

        public IActionResult Details(int id)
        {
            var menuItem = _menuItemService.GetMenuItemById(id);
            return View(menuItem);
        }
    }
}
