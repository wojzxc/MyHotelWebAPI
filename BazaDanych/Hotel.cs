using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyHotelWebAPI.BazaDanych
{
    public class Hotel
    {
        [Key] public int Hotel_ID { get; set; }
        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; }


    }

}
