using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyHotelWebAPI.BazaDanych;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MyHotelWebAPI.Models
{
    public class ReservationDto
    {
        public int Room_ID { get; set; }
        public int Client_ID { get; set; }
        public string MoveIn { get; set; }
        public string MoveOut { get; set; }
    }
}
