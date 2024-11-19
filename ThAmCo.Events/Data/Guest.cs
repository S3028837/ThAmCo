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
        public string Name { get; set; }
        [Phone]
        public string? GuestPhone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
