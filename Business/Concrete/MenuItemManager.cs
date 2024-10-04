using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MenuItemManager : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemManager(IUnitOfWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public List<MenuItemDto> GetMenuItems()
        {
            IBaseRepository<MenuItem> menuRepository = _unitOfWork.GetRepository<MenuItem>();
            return menuRepository.GetAll().Select(p => new MenuItemDto
            {
                ID = p.ID,
                Name = p.Name,
                Description = p.Description,
                ImageURL = p.ImageURL,
                Price = p.Price,
            }).ToList();
        }

        public MenuItemDto GetMenuItemById(int id)
        {
            var menuItem = _unitOfWork.GetRepository<MenuItem>().GetById(id);
            if (menuItem != null)
            {
                return new MenuItemDto
                {
                    ID = menuItem.ID,
                    Name = menuItem.Name,
                    Description = menuItem.Description,
                    Price = menuItem.Price,
                    ImageURL = menuItem.ImageURL
                };
            }

            return null;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            var menuRepository = _unitOfWork.GetRepository<MenuItem>();
            menuRepository.Add(menuItem);
            _unitOfWork.SaveChanges(); 
        }

        public void DeleteMenuItem(int id)
        {
            var menuRepository = _unitOfWork.GetRepository<MenuItem>();
            var menuItem = menuRepository.GetById(id);
            if (menuItem != null)
            {
                menuRepository.Delete(menuItem);
                _unitOfWork.SaveChanges(); 
            }
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            var menuRepository = _unitOfWork.GetRepository<MenuItem>();
            menuRepository.Update(menuItem);
            _unitOfWork.SaveChanges(); 
        }
    }
}
