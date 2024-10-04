using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        
        public string? GetCategory(int id)
        {
            var category = _unitOfWork.GetRepository<Category>().GetById(id);
            return category?.Name; 
        }

      
        public void AddCategory(Category category)
        {
            _unitOfWork.GetRepository<Category>().Add(category);
            _unitOfWork.SaveChanges();  
        }

       
        public void UpdateCategory(Category category)
        {
            var existingCategory = _unitOfWork.GetRepository<Category>().GetById(category.ID);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;  
                _unitOfWork.GetRepository<Category>().Update(existingCategory);
                _unitOfWork.SaveChanges();  
            }
        }

   
        public void DeleteCategory(int id)
        {
            var category = _unitOfWork.GetRepository<Category>().GetById(id);
            if (category != null)
            {
                _unitOfWork.GetRepository<Category>().Delete(category);
                _unitOfWork.SaveChanges();  
            }
        }
    }
}