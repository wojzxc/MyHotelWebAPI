using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MyHotelWebAPI.BazaDanych
{
    public class Client
    {

        [Key] public int Client_ID { get; set; }

        public string Type { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string Postal_Code { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
