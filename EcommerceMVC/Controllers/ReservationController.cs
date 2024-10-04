using Business.Abstract;
using Entities.Concrete;
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

    
        public IActionResult Index()
        {
            var reservations = _reservationService.GetAllReservations();
            if (reservations == null || !reservations.Any())
            {
                return View("Error");
            }
            return View(reservations);
        }

      
        public IActionResult Details(int id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReservationDto reservationDto)
        {
            if (ModelState.IsValid)
            {
                _reservationService.BookTable(reservationDto);
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDto);
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ReservationDto reservationDto)
        {
            if (id != reservationDto.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var reservation = new Reservation
                {
                    ID = reservationDto.ID,
                    CustomerName = reservationDto.CustomerName,
                    ContactInfo = reservationDto.ContactInfo,
                    SpecialRequest = reservationDto.SpecialRequest,
                    ReservationDate = reservationDto.ReservationDate,
                    NumberOfPeople = reservationDto.NumberOfPeople,
                    UpdatedAt = DateTime.Now
                };
                _reservationService.UpdateReservation(reservation);
                return RedirectToAction(nameof(Index));
            }

            return View(reservationDto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var reservation = _reservationService.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
