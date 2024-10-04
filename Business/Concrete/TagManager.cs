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
    public class TagManager : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TagDto> GetAllTags()
        {
            IBaseRepository<Tag> tagRepository = _unitOfWork.GetRepository<Tag>();
            return tagRepository.GetAll().Select(p => new TagDto
            {
                ID = p.ID,
                Name = p.Name,
                

            }).ToList();

        }
    }
}
