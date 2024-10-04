using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService
    {
        void AddPost(Post post);
        void DeletePost(int id);
        List<PostDto> GetAllPost();
        PostDto GetPost(int id);
        void UpdatePost(Post post);
    }
}
