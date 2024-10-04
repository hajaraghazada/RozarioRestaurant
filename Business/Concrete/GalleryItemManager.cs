using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class GalleryItemManager : IGalleryItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GalleryItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddGalleryItem(GalleryItem galleryItem)
        {
            var repository = _unitOfWork.GetRepository<GalleryItem>();
            repository.Add(galleryItem);
            _unitOfWork.SaveChanges();
        }

        public void DeleteGalleryItem(int id)
        {
            var repository = _unitOfWork.GetRepository<GalleryItem>();
            var galleryItem = repository.GetById(id);
            if (galleryItem != null)
            {
                repository.Delete(galleryItem);
                _unitOfWork.SaveChanges();
            }
        }

        public List<GalleryItemDto> GetGalleryItems()
        {
            var repository = _unitOfWork.GetRepository<GalleryItem>();
            return repository.GetAll().Select(galleryItem => new GalleryItemDto
            {
                ID = galleryItem.ID,
                Title = galleryItem.Title,
                ImageURL = galleryItem.ImageURL
            }).ToList();
        }

        public string? GetGalleryItemById(int id)
        {
            var repository = _unitOfWork.GetRepository<GalleryItem>();
            var galleryItem = repository.GetById(id);
            if (galleryItem == null)
            {
                return null;
            }

            return galleryItem.ImageURL; 
        }
    }
}