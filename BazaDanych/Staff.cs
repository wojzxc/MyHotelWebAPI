using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace MyHotelWebAPI.BazaDanych
{
    public class Staff
    {
        [Key] public int Staff_ID { get; set; }

        public string Password { get; set; }
        public string On_Shift { get; set; }

        public virtual Position Position { get; set; }
        public int Position_ID { get; set; }

    }
}
