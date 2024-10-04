using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FeedBackDto
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public string Speciality { get; set; }
        public string ImageUrl { get; set; }
    }
}
