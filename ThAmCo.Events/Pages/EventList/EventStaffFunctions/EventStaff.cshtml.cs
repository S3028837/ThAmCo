using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.EventList.EventStaffFunctions
{
    public class EventStaffModel : PageModel
    {
        private readonly EventsDbContext _context;

        public EventStaffModel(EventsDbContext context)
        {
            _context = context;
        }



        //GET staff for a specific event
        public IList<Staffing> Staffing { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            var staffingContext = _context.Staffings.AsQueryable();
            if (id != null)
            {
                staffingContext = staffingContext.Where(s => s.EventId == id);
            }

            staffingContext = staffingContext
                .Include(s => s.Event)
                .Include(s => s.Staff);

            Staffing = await staffingContext.ToListAsync();
        }
    }
}
