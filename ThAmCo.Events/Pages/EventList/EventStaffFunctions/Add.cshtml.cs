using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.EventList.EventStaffFunctions
{
    public class AddModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsDbContext _context;

        public AddModel(ThAmCo.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var selectedEvent = _context.Events.FirstOrDefault(e => e.EventId == id);

            Staffing = new Staffing
            {
                EventId = selectedEvent.EventId
            };
            ViewData["EventName"] = selectedEvent.EventName;
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName");
            return Page();
        }

        [BindProperty]
        public Staffing Staffing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Staffings.Add(Staffing);
            await _context.SaveChangesAsync();

            return RedirectToPage("/EventList/EventStaffFunctions/EventStaff", new {id = Staffing.EventId});
        }
    }
}
