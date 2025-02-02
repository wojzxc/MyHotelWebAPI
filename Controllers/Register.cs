using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using MyHotelWebAPI.Models;
using MyHotelWebAPI.Services;
using System.Security.Claims;


namespace MyHotelWebAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class Register : ControllerBase
    {
        private readonly IAccountService _accountService;
    
        public Register(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public IActionResult RegisterClient([FromBody] ClientDto Dto)
        {
            _accountService.RegisterClient(Dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto Dto)
        {
            string token = _accountService.GenerateJWT(Dto);
            if (token is null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpGet("user/{id}")]

        public IActionResult GetPersonById([FromHeader(Name = "Authorization")] string token, int id)
        {
            var result = _accountService.GetPersonById(token, id);

            if (!result.IsTokenValid)
            {
                return Unauthorized(new { Message = "Invalid or expired token." });
            }

            if (result.User == null)
            {
                return NotFound(new { Message = "Person not found." });
            }

            return Ok(result.User);
        }
    }
    public class PersonResult
    {
        public bool IsTokenValid { get; set; }
        public Client User { get; set; }
    }

}
