using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        //variables for event class
        [Required]
        public int EventId {  get; set; }
        public string? ReservationReference { get; set; }
        public int? FoodBookingId { get; set; }
        [MaxLength(100)]
        public string EventName { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate {  get; set; }

        //event relationships
        public List<Staffing>? Staffings { get; set; }
        public List<GuestBooking>? GuestBookings { get; set; }
    }
}
