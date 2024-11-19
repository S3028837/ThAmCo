using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Staff
    {
        [Required]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        [EmailAddress]
        public string? StaffEmail { get; set; }
        public bool FirstAidTrained { get; set; }

        //staff relationships
        public List<Staffing>? Staffings { get; set; }
    }
}
