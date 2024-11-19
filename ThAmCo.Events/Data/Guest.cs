using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Guest
    {
        //variables for Guest class
        [Required]
        public int GuestId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? GuestName { get; set; }
        [Phone]
        public string? GuestPhone { get; set; }
        [EmailAddress]
        public string? GuestEmail { get; set; }

        //Guest Relationships
        public List<GuestBooking>? GuestBookings { get; set; }
    }
}
