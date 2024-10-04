using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class FeedBackManager : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedBackManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFeedBack(FeedBack feedback)
        {
            var feedbackRepository = _unitOfWork.GetRepository<FeedBack>();
            feedbackRepository.Add(feedback);
            _unitOfWork.SaveChanges();
        }

        public void DeleteFeedBack(string feedback)
        {
            var feedbackRepository = _unitOfWork.GetRepository<FeedBack>();
            var existingFeedback = feedbackRepository.GetAll(f => f.Review == feedback).FirstOrDefault();
            if (existingFeedback != null)
            {
                feedbackRepository.Delete(existingFeedback);
                _unitOfWork.SaveChanges();
            }
        }

        public List<FeedBackDto> GetAllBack()
        {
            var feedbackRepository = _unitOfWork.GetRepository<FeedBack>();
            return feedbackRepository.GetAll().Select(f => new FeedBackDto
            {
                ID = f.ID,
                CustomerName = f.CustomerName,
                Speciality = f.Speciality,
                ImageUrl = f.ImageUrl,
                Rating = f.Rating,
                Review = f.Review
            }).ToList();
        }

        public string? GetFeedBackById(int id)
        {
            var feedbackRepository = _unitOfWork.GetRepository<FeedBack>();
            var feedback = feedbackRepository.GetById(id);
            return feedback?.Review;
        }

        public void UpdateFeedBack(FeedBack feedback)
        {
            var feedbackRepository = _unitOfWork.GetRepository<FeedBack>();
            feedbackRepository.Update(feedback);
            _unitOfWork.SaveChanges();
        }
    }
}