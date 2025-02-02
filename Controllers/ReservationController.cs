using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using MyHotelWebAPI.Models;
using MyHotelWebAPI.Services;



namespace MyHotelWebAPI.Controllers
{
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    { 
        private readonly MyHotelWebDB _dbContext;

        public ReservationController(MyHotelWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetAll()
        {
            var reservations = _dbContext.Reservations.ToList();
            return Ok(reservations);
        }

        [HttpGet("current/{clientid}")]
        public ActionResult<IEnumerable<Reservation>> GetCurrentReservations([FromRoute] int clientid)
        {
            var reservations = _dbContext.Reservations
                .Where(r => r.Client_ID == clientid)
                .ToList()
                .Where(r => DateTime.Parse(r.MoveOut) > DateTime.Now)
                .ToList();
            return Ok(reservations);
        }
   
        [HttpGet("past/{id}")]
        public ActionResult<IEnumerable<Reservation>> GetPastReservations([FromRoute] int id)
        {
            var reservations = _dbContext.Reservations
                .Where(r => r.Client_ID == id)
                .ToList()
                .Where(r => DateTime.Parse(r.MoveOut) <= DateTime.Now)
                .ToList();
            return Ok(reservations);
        }


    }
    [ApiController]
    [Route("api/reservations")]
    public class ReservationAdd : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationAdd(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("add")]
        public ActionResult Create([FromBody] ReservationDto reservation)
        {
            _reservationService.AddReservation(reservation);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _reservationService.DeleteReservation(id);
            return Ok();
        }
    }
}
