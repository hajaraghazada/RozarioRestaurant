using Business.Abstract;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult BookTable()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookTable(ReservationDto reservationDto)
        {
            if (ModelState.IsValid)
            {
                _reservationService.BookTable(reservationDto);
                return RedirectToAction("Success");
            }

            return View(reservationDto);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
