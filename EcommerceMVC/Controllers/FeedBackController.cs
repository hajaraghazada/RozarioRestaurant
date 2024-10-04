using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedBackService _feedBackService;

        public FeedbackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        public IActionResult Index()
        {
            var feedbacks = _feedBackService.GetAllBack();
            return View(feedbacks);
        }
    }
}
