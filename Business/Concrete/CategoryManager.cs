using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CategoryDto> GetCategories()
        {
            IBaseRepository<Category> categoryRepository = _unitOfWork.GetRepository<Category>();
            return categoryRepository.GetAll().Select(p => new CategoryDto
            {
                ID = p.ID,
                Name = p.Name,
            }).ToList();

        }
    }
}
