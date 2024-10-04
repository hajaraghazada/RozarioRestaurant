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
    public class GalleryItemManager : IGalleryItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GalleryItemManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<GalleryItemDto> GetGalleryItems ()
        {
            IBaseRepository<GalleryItem> galleryRepository = _unitOfWork.GetRepository<GalleryItem>();
            return galleryRepository.GetAll().Select(p => new GalleryItemDto
            {
                ID = p.ID,
                ImageURL = p.ImageURL,
                Title = p.Title,

            }).ToList();
        }
    }
}
