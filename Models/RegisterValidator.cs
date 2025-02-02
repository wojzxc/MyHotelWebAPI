using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;   
using FluentValidation;
using MyHotelWebAPI.BazaDanych;



namespace MyHotelWebAPI.Models
{
    public class RegisterValidator : AbstractValidator<ClientDto>
    {
        public RegisterValidator(MyHotelWebDB dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Clients.Any(x => x.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator(MyHotelWebDB dbContext)
        {
            RuleFor(x => x.Client_ID)
                .NotEmpty().WithMessage("Client_ID is required.");

            RuleFor(x => x.Room_ID)
                .NotEmpty().WithMessage("Room_ID is required.")
                .Must(roomId => IsRoomAvailable(roomId, dbContext))
                .WithMessage("The selected room is not available.");

            RuleFor(x => x.MoveIn)
                .NotEmpty().WithMessage("MoveIn date is required.");
        }

        private bool IsRoomAvailable(int roomId, MyHotelWebDB dbContext)
        {
            var room = dbContext.Rooms.FirstOrDefault(r => r.Room_ID == roomId);
            return room.Availability;
        }
    }
}
