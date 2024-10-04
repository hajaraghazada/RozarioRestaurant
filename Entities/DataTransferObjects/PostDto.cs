using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class PostDto
    {
        public int ID {  get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }
        public UserDto Author { get; set; }
        public string Description { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
