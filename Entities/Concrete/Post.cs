using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }                       
        public DateTime PublishDate { get; set; }   
        public string ImageURL { get; set; }     
        public int AuthorID { get; set; }
        public string Description { get; set; }
     
    }
}
