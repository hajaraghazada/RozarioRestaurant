using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public  class ReservationDto
    {
        public int ID {  get; set; }
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfPeople { get; set; }
        public string ContactInfo { get; set; }
        public string SpecialRequest { get; set; }
    }
}
