using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MyHotelWebAPI.BazaDanych
{
    public class Event
    {
        [Key] public int Event_ID { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public int Priority { get; set; }

        public bool IsDone { get; set; }

        public virtual Room Room { get; set; }
        public int Room_ID { get; set; }
        public virtual Position Position { get; set; }
        public int Position_ID { get; set; }

        
    }
}
