using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class GuestBooking
    {
        //variables for GuestBooking
        [Required]
        public int GuestBookingId { get; set; }
        public int GuestId { get; set; }
        public int EventId {  get; set; }
        public bool Attendance {  get; set; }

        //GuestBooking relationships
        public Event? Event { get; set; }
        public Guest? Guest { get; set; }
    }
}
