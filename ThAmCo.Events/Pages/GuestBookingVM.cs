using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages
{
    public class GuestBookingVM
    {
        public int GuestBookingId { get; set; }
        public int EventId {  get; set; }       
        public int GuestId {  get; set; }
        public bool Attendance {  get; set; }
        public string EventName {  get; set; }
        public string GuestName { get; set; }
        [EmailAddress]
        public string? GuestEmail {  get; set; }
        [Phone]
        public string? GuestPhone {  get; set; }
    }
}
