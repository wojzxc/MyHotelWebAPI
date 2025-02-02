using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using MyHotelWebAPI.Services;
using MyHotelWebAPI.Models;



namespace MyHotelWebAPI.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("add")]
        public IActionResult AddEvent([FromBody] EventDto Dto)
        {
            _eventService.AddEvent(Dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]

        public IActionResult DeleteEvent([FromRoute] int id)
        {
            _eventService.DeleteEvent(id);
            return Ok();
        }

    }
}
