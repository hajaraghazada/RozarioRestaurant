using Business.Abstract;
using Core.DataRepositories.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        
        public void AddReservation(Reservation reservation)
        {
            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            reservationRepository.Add(reservation);
            _unitOfWork.SaveChanges();
        }

        public void BookTable(ReservationDto reservationDto)
        {
            Reservation reservation = new Reservation()
            {
                ContactInfo = reservationDto.ContactInfo,
                SpecialRequest = reservationDto.SpecialRequest,
                ReservationDate = reservationDto.ReservationDate,
                CustomerName = reservationDto.CustomerName,
                NumberOfPeople = reservationDto.NumberOfPeople,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            reservationRepository.Add(reservation);
            _unitOfWork.SaveChanges();
        }

     
        public void DeleteReservation(int id)
        {
            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            var reservation = reservationRepository.GetById(id);

            if (reservation != null)
            {
                reservationRepository.Delete(reservation);
                _unitOfWork.SaveChanges();
            }
        }

     
        public string? GetAllReservations()
        {
            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            var reservations = reservationRepository.GetAll();
            if (reservations != null && reservations.Any())
            {
                return string.Join(", ", reservations.Select(r => $"ID: {r.ID}, Customer: {r.CustomerName}, Date: {r.ReservationDate.ToString("yyyy-MM-dd")}"));
            }
            return null;
        }

        public string? GetReservationById(int id)
        {
            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            var reservation = reservationRepository.GetById(id);
            if (reservation != null)
            {
                return $"ID: {reservation.ID}, Customer: {reservation.CustomerName}, Date: {reservation.ReservationDate.ToString("yyyy-MM-dd")}";
            }
            return null;
        }

      
        public void UpdateReservation(Reservation reservation)
        {
            var reservationRepository = _unitOfWork.GetRepository<Reservation>();
            reservation.UpdatedAt = DateTime.Now;
            reservationRepository.Update(reservation);
            _unitOfWork.SaveChanges();
        }
    }
}
