using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public  class CommentDto
    {
        public int ID {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

    }
}
