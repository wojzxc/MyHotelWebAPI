using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;

namespace MyHotelWebAPI.Controllers
{
    [ApiController]
    [Route("api/hotels")]
    public class HotelsController : ControllerBase
    {
        private readonly MyHotelWebDB _dbContext;

        public HotelsController(MyHotelWebDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> GetAll()
        { 
            var hotels = _dbContext.Hotels.ToList();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> Get([FromRoute]int id)
        {
            var hotel = _dbContext.Hotels.FirstOrDefault(h => h.Hotel_ID == id);
            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

    
    }
}
 