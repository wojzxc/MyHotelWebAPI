using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MyHotelWebAPI.BazaDanych
{
    public class Payment
    {
        [Key] public int Payment_ID { get; set; }

        public string Date { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string Payment_type { get; set; }

        public ICollection<Reservation> Reservations { get; set; }


    }
}
