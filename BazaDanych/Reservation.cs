using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyHotelWebAPI.BazaDanych
{
    public class Reservation
    {
        [Key] public int Reservation_ID { get; set; }
        public int Room_ID { get; set; }
        public int Client_ID { get; set; }
        public int Payment_ID { get; set; }
        public string MoveIn { get; set; }
        public string MoveOut { get; set; }
        public string Status { get; set; }

        public virtual Room Room { get; set; }
        public virtual Client Client { get; set; }
        public virtual Payment Payment { get; set; }

    }
}
