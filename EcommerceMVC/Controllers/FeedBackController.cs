using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;

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

     
        public IActionResult Details(int id)
        {
            var feedback = _feedBackService.GetFeedBackById(id); 
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

      
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeedBack feedback)
        {
            if (ModelState.IsValid)
            {
                _feedBackService.AddFeedBack(feedback); 
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        
        public IActionResult Edit(int id)
        {
            var feedback = _feedBackService.GetFeedBackById(id); 
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FeedBack feedback)
        {
            if (id != feedback.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _feedBackService.UpdateFeedBack(feedback); 
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

    
        public IActionResult Delete(int id)
        {
            var feedback = _feedBackService.GetFeedBackById(id); 
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var feedback = _feedBackService.GetFeedBackById(id); 
            if (feedback != null)
            {
                _feedBackService.DeleteFeedBack(feedback); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}