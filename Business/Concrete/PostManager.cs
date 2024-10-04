using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<PostDto> GetAllPost()
        {
            IBaseRepository<Post> postRepository = _unitOfWork.GetRepository<Post>();
            return postRepository.GetAll().Select(p => new PostDto
            {
                ID = p.ID,
                Description = p.Description,
                Title = p.Title,
                ImageURL = p.ImageURL,
                PublishDate = p.PublishDate,
                Author = new UserDto {ID=p.AuthorID}




            }).ToList();
        }

        public PostDto GetPost(int id)
        {
            var post = GetAllPost().FirstOrDefault(p => p.ID == id);
            IBaseRepository<User> userRepository = _unitOfWork.GetRepository<User>();
            IBaseRepository<Comment> commentRepository = _unitOfWork.GetRepository<Comment>();
            var comments = commentRepository.GetAll(p=> p.PostID==id);
            var user = userRepository.GetById(post.Author.ID);
            post.Author = new UserDto
            {
                Bio=user.Bio,
                Name=user.Name,
                ID=post.ID,
                ImageUrl=post.ImageURL
            };
            post.Comments = comments.Select(p => new CommentDto
            { Name=p.Name,
            ID = p.ID,
            Text=p.Text,
            CreatedAt=p.CreatedAt

            }).ToList();

            return post;

            
            
            
        }
    }
}
