using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }

    }
}
