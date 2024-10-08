﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MenuItem : BaseEntity
    {
        public string Name { get; set; }         
        public string Description { get; set; }  
        public decimal Price { get; set; }       
        public string ImageURL { get; set; }     
    }
}
