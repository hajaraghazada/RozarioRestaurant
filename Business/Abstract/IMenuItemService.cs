using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Abstract
{
    public interface IMenuItemService
    {
        List<MenuItemDto> GetMenuItems();
        MenuItemDto GetMenuItemById(int id);
    }
}
