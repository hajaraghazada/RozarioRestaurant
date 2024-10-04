using Business.Abstract;
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
    public class ReservationManager : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BookTable(ReservationDto reservationDto)
        {

            Reservation reservation = new Reservation() 
            { 
                ContactInfo=reservationDto.ContactInfo,
                SpecialRequest=reservationDto.SpecialRequest,
                ReservationDate=reservationDto.ReservationDate,
                CustomerName=reservationDto.CustomerName,
                NumberOfPeople=reservationDto.NumberOfPeople,
                CreatedAt=DateTime.Now,
                UpdatedAt=DateTime.Now,
                
            };

            var reservationRepositiry = _unitOfWork.GetRepository<Reservation>();
            reservationRepositiry.Add(reservation);
            _unitOfWork.SaveChanges();




        }
    }
}
