using HotelBookingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingProject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelBookingContext context)
        {
            // Delete the database, if it already exists. I do this because an
            // existing database may not be compatible with the entity model,
            // if the entity model was changed since the database was created.
            context.Database.EnsureDeleted();

            // Create the database, if it does not already exists. This operation
            // is necessary, if you use an SQL Server database.
            context.Database.EnsureCreated();

            // Look for any bookings.
            if (context.Booking.Any())
            {
                return;   // DB has been seeded
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer { Name="Jan Kowalski", Email="jkowalski@gmail.com" },
                new Customer { Name="Lidia Wilk", Email="lwilk@gmail.com" },
                new Customer { Name="Paulina Malinowska", Email="pmalinowska@gmail.com" },
                new Customer { Name="Dominik Czarnecki", Email="dominik.czarnecki@gmail.com" },
                new Customer { Name="Arkadiusz Krajewski", Email="a.krajewski@gmail.com" },
            };

            List<Room> rooms = new List<Room>
            {
                new Room { Description="Standart Room" },
                new Room { Description="Family Room" },
                new Room { Description="Deluxe Room" }
            };

            DateTime date1 = new DateTime(2023, 02, 12);
            DateTime date2 = new DateTime(2023, 02, 22);
            DateTime date3 = new DateTime(2023, 03, 02);
            DateTime date4 = new DateTime(2023, 03, 11);
            DateTime date5 = new DateTime(2023, 03, 04);
            List<Booking> bookings = new List<Booking>
            {
                new Booking { StartDate=date1, EndDate=date1.AddDays(4), IsActive=true, CustomerId=5, RoomId=1 },
                new Booking { StartDate=date2, EndDate=date2.AddDays(3), IsActive=true, CustomerId=3, RoomId=3 },
                new Booking { StartDate=date3, EndDate=date3.AddDays(7), IsActive=true, CustomerId=4, RoomId=2 },
                new Booking { StartDate=date4, EndDate=date2.AddDays(2), IsActive=true, CustomerId=2, RoomId=1 },
                new Booking { StartDate=date5, EndDate=date3.AddDays(5), IsActive=true, CustomerId=1, RoomId=2 }
            };

            context.Customer.AddRange(customers);
            context.Room.AddRange(rooms);
            context.SaveChanges();
            context.Booking.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
