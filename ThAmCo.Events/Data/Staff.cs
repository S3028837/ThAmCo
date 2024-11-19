using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Staff
    {
        [Required]
        public int staffId { get; set; }
        public string staffName { get; set; }
        [EmailAddress]
        public string staffEmail { get; set; }
        public bool firstAidTrained { get; set; }
    }
}
