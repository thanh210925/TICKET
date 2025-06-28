using System;
using System.ComponentModel.DataAnnotations;

namespace BookingFlight.Models
{
    public class Admin
    {
        [Key] // Báo EF rằng đây là khóa chính
        public int AdminID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool? IsActive { get; set; }
    }
}
