using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        //variables for FoodBooking class
        [Required]
        public int FoodBookingId { get; set; }
        public int ClientReferenceId { get; set; }
        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; }

        //Many to one reationship to Menu
        public List<Menu>? Menus { get; set; }
        //one to one relationship to Event
        //public Event? Event { get; set; }
    }
}
