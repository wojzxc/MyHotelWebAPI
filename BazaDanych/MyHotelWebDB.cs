using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace MyHotelWebAPI.BazaDanych
{
    public class MyHotelWebDB : DbContext
    {

        public MyHotelWebDB(DbContextOptions<MyHotelWebDB> options)
            : base(options) 
        {
        }
        private string _connectionString = "Server=localhost;Database=MyHotelWebDB;Trusted_Connection=True";
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Staff> Staffs { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            base.OnModelCreating(modelBuilder);

            // Relacja: Position -> Staff (jeden-do-wielu)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Position)
                .WithMany(p => p.Staff)
                .HasForeignKey(s => s.Position_ID);

            // Relacja: Position -> Event (jeden-do-wielu)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Events)
                .HasForeignKey(e => e.Position_ID);

            // Relacja: Hotel -> Room (jeden-do-wielu)
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Rooms)
                .HasForeignKey(r => r.Hotel_ID);

            // Relacja: Room -> Event (jeden-do-wielu)
            modelBuilder.Entity<Event>()
                .HasOne(e => e.Room)
                .WithMany(r => r.Events)
                .HasForeignKey(e => e.Room_ID);

            // Relacja: Reservation -> Room (wiele-do-jednego)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(ro => ro.Reservations)
                .HasForeignKey(r => r.Room_ID);

            // Relacja: Reservation -> Payment (wiele-do-jednego)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Payment)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.Payment_ID);

            // Relacja: Reservation -> Client (wiele-do-jednego)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.Client_ID);

            modelBuilder.Entity<Position>().HasData(
                new Position { Position_ID = 1, Position_Type = "Receptionist"},
                new Position { Position_ID = 2, Position_Type = "Developer" },
                new Position { Position_ID = 3, Position_Type = "Maintance" }
            );

            // Seedowanie tabeli Staff
            modelBuilder.Entity<Staff>().HasData(
                new Staff { Staff_ID = 1, Position_ID = 2, On_Shift = "Day", Password = "secret1" },
                new Staff { Staff_ID = 2, Position_ID = 2, On_Shift = "Night", Password = "secret2" },
                new Staff { Staff_ID = 3, Position_ID = 1, On_Shift = "Day", Password = "secret3"}
            );

            // Seedowanie tabeli Hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { Hotel_ID = 1, Name = "Marriott" },
                new Hotel { Hotel_ID = 2, Name = "DS1 Olimp" }
            );

            // Seedowanie tabeli Room
            modelBuilder.Entity<Room>().HasData(
                new Room { Room_ID = 1,Name = "Pokój 100", Hotel_ID = 1, Type = "Single", Price = 350, Availability = true },
                new Room { Room_ID = 2,Name = "Pokój 110", Hotel_ID = 1, Type = "Double", Price = 550, Availability = false },
                new Room { Room_ID = 3,Name = "Pokój 120", Hotel_ID = 1, Type = "Apartment", Price = 800, Availability = true },
                new Room { Room_ID = 4,Name = "Pokój 310", Hotel_ID = 2, Type = "Single", Price = 100, Availability = false },
                new Room { Room_ID = 5,Name = "Pokój 212", Hotel_ID = 2, Type = "Double", Price = 150, Availability = true },
                new Room { Room_ID = 6,Name = "Pokój 1008", Hotel_ID = 2, Type = "Apartment", Price = 200, Availability = true },
                new Room { Room_ID = 7,Name = "Pokój 200", Hotel_ID = 1, Type = "Single", Price = 350, Availability = true },
                new Room { Room_ID = 8,Name = "Pokój 210", Hotel_ID = 1, Type = "Double", Price = 550, Availability = true},
                new Room { Room_ID = 9,Name = "Pokój 220", Hotel_ID = 1, Type = "Apartment", Price = 800, Availability = true },
                new Room { Room_ID = 10,Name = "Pokój 350", Hotel_ID = 2, Type = "Single", Price = 100, Availability = true },
                new Room { Room_ID = 11,Name = "Pokój 212", Hotel_ID = 2, Type = "Double", Price = 150, Availability = true },  
                new Room { Room_ID = 12,Name = "Pokój 1008", Hotel_ID = 2, Type = "Apartment", Price = 200, Availability = true },
                new Room { Room_ID = 13,Name = "Pokój 200", Hotel_ID = 1, Type = "Single", Price = 350, Availability = true },
                new Room { Room_ID = 14,Name = "Pokój 410", Hotel_ID = 1, Type = "Double", Price = 550, Availability = true},
                new Room { Room_ID = 15,Name = "Pokój 420", Hotel_ID = 1, Type = "Apartment", Price = 800, Availability = true },
                new Room { Room_ID = 16,Name = "Pokój 450", Hotel_ID = 2, Type = "Single", Price = 100, Availability = true },
                new Room { Room_ID = 17,Name = "Pokój 512", Hotel_ID = 2, Type = "Double", Price = 150, Availability = true },
                new Room { Room_ID = 18,Name = "Pokój 1008", Hotel_ID = 2, Type = "Apartment", Price = 200, Availability = true },
                new Room { Room_ID = 19,Name = "Pokój 090", Hotel_ID = 1, Type = "Single", Price = 350, Availability = true },  
                new Room { Room_ID = 20,Name = "Pokój 0960", Hotel_ID = 1, Type = "Double", Price = 550, Availability = true }

            );

            // Seedowanie tabeli Events
            modelBuilder.Entity<Event>().HasData(
                new Event { Event_ID = 1, Room_ID = 1, Position_ID = 1, Type = "Naprawa", Date = "2025/1/14", Priority = 1, IsDone = true },
                new Event { Event_ID = 2, Room_ID = 2, Position_ID = 2, Type = "Sprzątanie", Date = "2025/1/18", Priority = 3, IsDone = false },
                new Event { Event_ID = 3, Room_ID = 1, Position_ID = 1, Type = "Przegląd", Date = "2025/1/20", Priority = 2, IsDone = false}
            );

            // Seedowanie tabeli Client
            modelBuilder.Entity<Client>().HasData(
                new Client { Client_ID = 1, Type = "Single", Name = "Jan Kowalski", Phone = 123456789, Email = "JanKowalski@gmail.com", Password = "clientpass1", Address = "Warsaw, ul.Podluzna 5", Postal_Code = "00-001" },
                new Client { Client_ID = 2, Type = "Group", Name = "Anna Nowak", Phone = 987654321, Email = "ANowak@gmail.com", Password = "clientpass2", Address = "Krakow, ul.Krakowska 10", Postal_Code = "30-200" }
            ); 

            // Seedowanie tabeli Payment
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Payment_ID = 1, Date = "2025/1/17", Price = 550, Status = "Paid", Payment_type = "Card" },
                new Payment { Payment_ID = 2, Date = "2025/1/18", Price = 100, Status = "Waiting", Payment_type = "Cash" }
            );

            // Seedowanie tabeli Reservation
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Reservation_ID = 1, Room_ID = 2, Payment_ID = 1, Client_ID = 1, MoveIn = "2025/1/10", MoveOut = "2025/1/17", Status = "Confirmed" },
                new Reservation { Reservation_ID = 2, Room_ID = 4, Payment_ID = 2, Client_ID = 2, MoveIn = "2025/2/1", MoveOut = "2025/2/9", Status = "Pending" }
            );


        }
    }

}
