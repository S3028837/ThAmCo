namespace ThAmCo.Events.Data
{
    public class Staffing
    {
        public int StaffId { get; set; }
        public int EventId { get; set; }

        //staffing relationships
        public Staff? Staff { get; set; }
        public Event? Event { get; set; }
    }
}
