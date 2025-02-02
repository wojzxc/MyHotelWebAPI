using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyHotelWebAPI.BazaDanych
{
    public class Position
    {
        [Key] public int Position_ID { get; set; }

        public string Position_Type { get; set; }

        public ICollection<Staff> Staff { get; set; }
        public ICollection<Event> Events { get; set; }


    }
}
