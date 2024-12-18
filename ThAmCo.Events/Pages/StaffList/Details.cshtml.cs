using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.StaffList
{
    public class DetailsModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public DetailsModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; } = default!;
        //holds a list of staffing entries
        public IList<Staffing> Staffing { get; set; } = default!;

        //GETs staff details
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            else
            {
                Staff = staff;
            }



            //GET staffing enties with a matching staffId
            var staffingContext = _context.Staffings.AsQueryable();
            if (id != null)
            {
                staffingContext = staffingContext.Where(b => b.StaffId == id && b.Event.EventDate >= DateTime.Now);
            }
            staffingContext = staffingContext
                .Include(g => g.Staff)
                .Include(g => g.Event);

            Staffing = await staffingContext.ToListAsync();
            return Page();
        }
    }
}
