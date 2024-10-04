using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Reservation : BaseEntity
    {
        public string CustomerName { get; set; }     
        public DateTime ReservationDate { get; set; } 
        public int NumberOfPeople { get; set; }       
        public string ContactInfo { get; set; }       
        public string SpecialRequest { get; set; }    
    }
}
