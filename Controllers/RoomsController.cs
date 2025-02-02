using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;

namespace MyHotelWebAPI.Controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly MyHotelWebDB _dbContext;

        public RoomsController(MyHotelWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetAll()
        {
            var rooms = _dbContext.Rooms
            .Select(r => new
            {
                r.Room_ID,
                r.Name,
            })
            .ToList();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> Get([FromRoute] int id)
        {
            var room = _dbContext.Rooms
            .Where(r => r.Room_ID == id)
            .Select(r => new
            {
                r.Room_ID,
                r.Name,
                r.Type,
                r.Price,
                r.Availability,
                Events = _dbContext.Events
                .Where(e => e.Room_ID == r.Room_ID) // Filtruj zdarzenia po Room_ID
                .Select(e => new
                {
                    e.Event_ID,
                    e.Date
                }).ToList(),
                Reservations = _dbContext.Reservations
                .Where(res => res.Room_ID == r.Room_ID) // Filtruj rezerwacje po Room_ID
                .Select(res => new
                {
                    res.MoveIn,
                    res.MoveOut,
                    GuestName = _dbContext.Clients
                        .Where(c => c.Client_ID == res.Client_ID) // Powiązany klient
                        .Select(c => c.Name)
                        .FirstOrDefault(),
                    PaymentStatus = _dbContext.Payments
                        .Where(p => p.Payment_ID == res.Payment_ID) // Powiązana płatność
                        .Select(p => p.Status)
                        .FirstOrDefault()
                }).ToList()
            })
            .FirstOrDefault();
            if (room is null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet("hotel/{hotelId}")]

        public ActionResult<IEnumerable<Room>> GetRoomsByHotel([FromRoute] int hotelId)
        {
            var rooms = _dbContext.Rooms.Where(r => r.Hotel_ID == hotelId)
            .Select(r => new
            {
                r.Room_ID,
                r.Name,
            })
            .ToList();
            if (rooms is null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpGet("available")]
        public ActionResult<IEnumerable<Room>> GetAvailableRooms()
        {
            var rooms = _dbContext.Rooms
            .Where(r => r.Availability == true)
            .Select(r => new
            {
                r.Room_ID,
                r.Name,
            })
            .ToList();
            return Ok(rooms);
        }
    }
}
