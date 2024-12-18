using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.EventList
{
    public class IndexModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public IndexModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(e => e.GuestBookings)
                .Include(e => e.Staffings)
                    .ThenInclude(s => s.Staff)
                .ToListAsync();
        }

        //debuged with copilot
        //checks if an event has FirstAidTrained staff assigned to it and displays the appropriate warning
        public string GetTrainedStaffStatus(Event ev)
        {
            if (ev.Staffings != null && ev.Staffings.Any(s => s.Staff != null && s.Staff.FirstAidTrained))
            {
                return ("");
            }
            return ("Warning! No First Aid trained staff assigned");
        }
    }
}
