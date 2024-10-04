using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Archive : BaseEntity
    {
        public string YearMonth { get; set; }                       
    }
}
