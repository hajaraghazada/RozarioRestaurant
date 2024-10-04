using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGalleryItemService
    {
        void AddGalleryItem(GalleryItem galleryItem);
        void DeleteGalleryItem(int id);
        string? GetGalleryItemById(int id);
        List <GalleryItemDto> GetGalleryItems ();
    }
}



