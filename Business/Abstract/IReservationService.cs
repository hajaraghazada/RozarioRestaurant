using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReservationService
    {
        void AddReservation(Reservation reservation);
        void BookTable(ReservationDto reservationDto);
        void DeleteReservation(int id);
        string? GetAllReservations();
        string? GetReservationById(int id);
        void UpdateReservation(Reservation reservation);
    }
}
