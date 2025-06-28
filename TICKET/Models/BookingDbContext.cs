using BookingFlight.Models;
using System.Data.Entity;

namespace TICKET.Models
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext() : base("name=BookingDbContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        // Nếu có thêm bảng khác thì khai báo ở đây:
        // public DbSet<Flight> Flights { get; set; }
    }
}
