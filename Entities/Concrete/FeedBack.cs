using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FeedBack : BaseEntity
    {
        public string CustomerName { get; set; }  
        public string Review { get; set; }      
        public int Rating { get; set; }
        public string Speciality { get; set; }
        public string ImageUrl { get; set; }

    }
}
