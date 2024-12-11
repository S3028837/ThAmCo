using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.EventList.EventStaffFunctions
{
    public class RemoveModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public RemoveModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Staffing Staffing { get; set; } = default!;

        //debugging assisted with Microsoft Copilot
        public async Task<IActionResult> OnGetAsync(int eventId, int staffId)
        {
            var staffing = await _context.Staffings
                .FirstOrDefaultAsync(s => s.EventId == eventId && s.StaffId == staffId);

            if (staffing == null)
            {
                return NotFound();
            }
            else
            {
                Staffing = staffing;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? eventId, int? staffId)
        {
            if (eventId == null || staffId == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings
                .FirstOrDefaultAsync(s => s.EventId == eventId && s.StaffId == staffId);

            if (staffing != null)
            {
                _context.Staffings.Remove(staffing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/EventList");
        }
    }
}
