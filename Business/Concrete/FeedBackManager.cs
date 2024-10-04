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
    public class FeedBackManager : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedBackManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<FeedBackDto> GetAllBack()
        {
            IBaseRepository<FeedBack> feedRepository = _unitOfWork.GetRepository<FeedBack>();
            return feedRepository.GetAll().Select(p => new FeedBackDto
            {
                ID = p.ID,
                CustomerName = p.CustomerName,
                Speciality = p.Speciality,
                ImageUrl = p.ImageUrl,
                Rating = p.Rating,
                Review = p.Review,
            }).ToList();
        }
    }
}
