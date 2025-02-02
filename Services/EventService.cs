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
    public interface IEventService
    {
        void AddEvent(EventDto Dto);
        void DeleteEvent(int id);
    }
    public class EventService : IEventService
    {
        private readonly MyHotelWebDB _dbContext;
        public EventService(MyHotelWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEvent(EventDto Dto)
        {
            var newEvent = new Event
            {
                Type = Dto.Type,
                Date = Dto.Date,
                Priority = Dto.Priority,
                IsDone = false,
                Room_ID = Dto.Room_ID,
                Position_ID = 3
            };
            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
        }
        public void DeleteEvent(int id)
        {
              var eventToDelete = _dbContext.Events.FirstOrDefault(x => x.Event_ID == id);
            if (eventToDelete == null)
            {
                return;
            }
            _dbContext.Events.Remove(eventToDelete);
            _dbContext.SaveChanges();
        }


    }
}
