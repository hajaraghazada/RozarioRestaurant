using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class MenuItemManager : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemManager(IUnitOfWork unitofWork )
        {
            this._unitOfWork=unitofWork;
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
    }
}