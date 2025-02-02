using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using MyHotelWebAPI.Models;
using Microsoft.AspNetCore.Identity;


namespace MyHotelWebAPI.Services
{
    public interface IReservationService
    {
        void AddReservation(ReservationDto Dto);
        void DeleteReservation(int id);
    }
    public class ReservationService : IReservationService
    {
        public readonly MyHotelWebDB _dbContext;
        public ReservationService(MyHotelWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReservation(ReservationDto Dto)
        {

            var room = _dbContext.Rooms.FirstOrDefault(r => r.Room_ID == Dto.Room_ID);
            int price = room.Price;
            var payment = new Payment
            {
                Date = DateTime.Now.ToString(),
                Price = price,
                Status = "Pending",
                Payment_type = "Not paid"
            };
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
            var newReservation = new Reservation
            {
                Room_ID = Dto.Room_ID,
                Client_ID = Dto.Client_ID,
                Payment_ID = payment.Payment_ID,
                MoveIn = Dto.MoveIn,
                MoveOut = Dto.MoveOut,
                Status = "Pending"
            };
            _dbContext.Reservations.Add(newReservation);
            room.Availability = false;
            _dbContext.SaveChanges();
        }

        public void DeleteReservation(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(x => x.Reservation_ID == id);
            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
        }

    }
  
}
