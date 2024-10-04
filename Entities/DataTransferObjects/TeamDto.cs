using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class TeamDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string ImageUrl { get; set; }
    }
}
