using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GalleryItem : BaseEntity
    {
        public string Title { get; set; }       
        public string ImageURL { get; set; }    
    }
}
