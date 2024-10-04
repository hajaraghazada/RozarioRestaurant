using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFeedBackService
    {
        void AddFeedBack(FeedBack feedback);
        void DeleteFeedBack(string feedback);
        List<FeedBackDto> GetAllBack();
        string? GetFeedBackById(int id);
        void UpdateFeedBack(FeedBack feedback);
    }
}
