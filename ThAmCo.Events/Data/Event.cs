using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        [Required]
        public int eventId {  get; set; }
        [MaxLength(100)]
        public string eventName { get; set; }
        public string eventType { get; set; }
        public DateOnly? eventDate {  get; set; }
    }
}
