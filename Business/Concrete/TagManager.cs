using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddTag(Tag tag)
        {
            var tagRepository = _unitOfWork.GetRepository<Tag>();
            tagRepository.Add(tag);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTag(int id)
        {
            var tagRepository = _unitOfWork.GetRepository<Tag>();
            var tag = tagRepository.GetById(id);
            if (tag != null)
            {
                tagRepository.Delete(tag);
                _unitOfWork.SaveChanges();
            }
        }

        public List<TagDto> GetAllTags()
        {
            var tagRepository = _unitOfWork.GetRepository<Tag>();
            return tagRepository.GetAll().Select(p => new TagDto
            {
                ID = p.ID,
                Name = p.Name
            }).ToList();
        }

        public string? GetTagById(int id)
        {
            var tagRepository = _unitOfWork.GetRepository<Tag>();
            var tag = tagRepository.GetById(id);
            if (tag != null)
            {
                return new TagDto
                {
                    ID = tag.ID,
                    Name = tag.Name
                }.ToString();
            }

            return null;
        }

        public void UpdateTag(Tag tag)
        {
            var tagRepository = _unitOfWork.GetRepository<Tag>();
            tagRepository.Update(tag);
            _unitOfWork.SaveChanges();
        }
    }
}
