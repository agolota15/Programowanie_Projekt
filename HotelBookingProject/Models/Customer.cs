using System.Collections.Generic;

namespace HotelBookingProject.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
