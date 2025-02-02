using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MyHotelWebAPI.BazaDanych
{
    public class Room
    {
        [Key] public int Room_ID { get; set; }
        public string Name { get; set; }
        public int Hotel_ID { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public bool Availability { get; set; }

        public virtual Hotel Hotel { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
